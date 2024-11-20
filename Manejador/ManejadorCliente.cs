using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AccesoDatos;
using static System.Net.Mime.MediaTypeNames;

namespace Manejador
{
    public class ManejadorCliente
    {
        Base b = new Base("localhost", "root", "", "cinemonopolyo");
        public static decimal Precio, precio, total;
        private List<Button> asientosSeleccionados = new List<Button>();
        private string metodoPago = "EFECTIVO";
        public static int cantidad=0;


        public void InicializarFormulario(ComboBox cmbProductos, ComboBox cmbPeliculas, ComboBox cmbHorarios, Panel pnlAsientos, Button btnConfirmar, FlowLayoutPanel pnlResumen, Label lblSala, Label lblHorario, Label lblUser, Label lblTotal)
        {
            CargarDatosDePrueba(cmbProductos, cmbPeliculas, cmbHorarios, lblSala, lblHorario);
            ConfigurarSala(pnlAsientos);
            ConfigurarEventos(cmbPeliculas, cmbHorarios, btnConfirmar, pnlAsientos, pnlResumen, lblTotal);
            lblUser.Text = ManejadorLogin.UserId.ToString();
        }

        private void CargarDatosDePrueba(ComboBox cmbProductos, ComboBox cmbPeliculas, ComboBox cmbHorarios, Label lblSala, Label lblHorario)
        {
            cmbPeliculas.Items.Clear();
            cmbHorarios.Items.Clear();

            try
            {
                DataTable productos = b.Consultar("SELECT id, nombre FROM Productos", "Productos").Tables[0];
                foreach (DataRow row in productos.Rows)
                {
                    cmbProductos.Items.Add(new { Producto = row["nombre"].ToString() });
                }

                DataTable peliculas = b.Consultar("SELECT id, titulo, precio FROM Peliculas", "Peliculas").Tables[0];
                foreach (DataRow row in peliculas.Rows)
                {
                    cmbPeliculas.Items.Add(new { Titulo = row["titulo"].ToString(), Precio= row["precio"], Id = row["id"]});
                }


                cmbPeliculas.SelectedIndexChanged += (sender, e) =>
                {
                    if (cmbPeliculas.SelectedItem != null)
                    {
                        dynamic peliculaSeleccionada = cmbPeliculas.SelectedItem;
                        int peliculaId = peliculaSeleccionada.Id;
                        Precio = peliculaSeleccionada.Precio;

                        cmbHorarios.Items.Clear();

                        DataTable datosHorarios = b.Consultar(
                            $"SELECT id, sala_id, fecha_hora FROM Horarios WHERE pelicula_id = {peliculaId}",
                            "Horarios"
                        ).Tables[0];

                        if (datosHorarios.Rows.Count > 0)
                        {
                            int horarioId = Convert.ToInt32(datosHorarios.Rows[0]["id"]);
                            lblHorario.Text = $"{horarioId}";
                            int salaId = Convert.ToInt32(datosHorarios.Rows[0]["sala_id"]);
                            lblSala.Text = $"{salaId}";
                            foreach (DataRow row in datosHorarios.Rows)
                            {
                                DateTime fechaHora = Convert.ToDateTime(row["fecha_hora"]);
                                cmbHorarios.Items.Add(fechaHora.ToString("dd/MM/yyyy HH:mm"));
                            }
                        }
                        else
                        {
                            lblSala.Text = "Sala: No disponible";
                            MessageBox.Show("No se encontraron horarios para esta película.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }


                    }
                };
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarSala(Panel pnlAsientos)
        {

            pnlAsientos.Controls.Clear();
            int filas = 9;
            int columnas = 16;
            int tamanoBoton = 40;
            int espaciado = 5;


            var posicionesVacias = new HashSet<(int fila, int columna)>
        {
            (0,0), (0,1), (0,14), (0,15),
            (1,0), (1,1), (1,14), (1,15),
            (2,0), (2,1), (2,14), (2,15),
            (3,0), (3,1), (3,14), (3,15),
            (4,0), (4,1), (4,14), (4,15),
            (5,0), (5,1), (5,14), (5,15),
            (6,0), (6,1), (6,14), (6,15),
            (7,0), (7,1), (7,14), (7,15),

            (0,5), (0,6), (0,7), (0,8), (0,9), (0,10),
            (1,5), (1,6), (1,7), (1,8), (1,9), (1,10)
        };

            Panel panelPantalla = new Panel
            {
                Size = new Size(columnas * (tamanoBoton + espaciado), 40),
                Location = new Point(20, 0),
                BackColor = Color.DarkBlue
            };

            Label lblPantalla = new Label
            {
                Text = "PANTALLA",
                ForeColor = Color.White,
                AutoSize = false,
                Size = panelPantalla.Size,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            panelPantalla.Controls.Add(lblPantalla);
            pnlAsientos.Controls.Add(panelPantalla);
            for (int fila = 0; fila < filas; fila++)
            {
                for (int columna = 0; columna < columnas; columna++)
                {

                    if (posicionesVacias.Contains((fila, columna)))
                    {
                        continue;
                    }

                    Button btnAsiento = new Button
                    {
                        Size = new Size(tamanoBoton, tamanoBoton),
                        Location = new Point(columna * (tamanoBoton + espaciado) + 20,
                                          fila * (tamanoBoton + espaciado) + 60), // +60 para dejar espacio para la pantalla
                        Text = $"{(char)(65 + fila)}{columna + 1}",
                        BackColor = Color.LightGreen,
                        Tag = "disponible",
                        Font = new Font("Arial", 8)
                    };
                    btnAsiento.Click += (sender, e) => AsientoClick(sender, e);
                    pnlAsientos.Controls.Add(btnAsiento);
                }
                pnlAsientos.AutoScroll = true;
            }
        }

        public string GuardarVentasBoletos(int horarioId, int cantidad, List<Button> asientosSeleccionados, string metodoPago, string estado)
        {
            try
            {
                if (horarioId <= 0 || cantidad <= 0 || asientosSeleccionados == null || asientosSeleccionados.Count == 0)
                {
                    return "Error: Datos de entrada inválidos";
                }
                string asientos = string.Join(", ", asientosSeleccionados.Select(a => a.Text));
                asientos = asientos.Replace("'", "''");
                metodoPago = metodoPago.Replace("'", "''");
                estado = estado.Replace("'", "''");
                string query = $"INSERT INTO VentasBoletos (horario_id, cantidad, asiento, metodo_pago, estado) " +
                              $"VALUES ({horarioId}, {cantidad}, '{asientos}', '{metodoPago}', '{estado}')";
                return b.Comando(query);
            }
            catch (Exception ex)
            {
                return $"Error al insertar: {ex.Message}";
            }
        }

        public static string Ventas_Id = "";

        public int ObtenerUltimoId(string tabla)
        {
            try
            {
                DataTable dt = b.Consultar($"SELECT id FROM {tabla} ORDER BY id DESC LIMIT 1", tabla).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["id"]);
                }
                else
                {
                    throw new Exception("No se encontraron registros en la tabla.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el último ID de la tabla {tabla}: {ex.Message}");
            }
        }

        public string DetallesVenta(int ventasBoletosId, int usuarioId, decimal Total)
        {
            try
            {
                if (ventasBoletosId <= 0 || usuarioId <= 0 || Total <= 0)
                {
                    return "Error: Datos de entrada inválidos";
                }

                // Usamos cultura invariante para asegurar el formato correcto del decimal
                string totalFormateado = Total.ToString(System.Globalization.CultureInfo.InvariantCulture);

                string query = $"INSERT INTO DetallesVenta (VentasBoletos_id, VentasProductos_id, usuario_id, Total) " +
                              $"VALUES ({ventasBoletosId}, NULL, {usuarioId}, {totalFormateado})";
                return b.Comando(query);
            }
            catch (Exception ex)
            {
                return $"Error al insertar: {ex.Message}";
            }
        }


        public void Resumen(Label lblHorarioId, ComboBox cmbHorarios, ComboBox cmbPeliculas,
                           Panel pnlAsientos, FlowLayoutPanel pnlResumen, Label lblSalaId, Label lblTotal)
        {
            try
            {
                if (asientosSeleccionados.Count == 0)
                {
                    MessageBox.Show("No has seleccionado asientos. Por favor selecciona asientos antes de confirmar.",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbHorarios.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, selecciona un horario.",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string metodoPago = "TARJETA DE CREDITO";
                string estado = "Pagado";

                // Guardar la venta de boletos
                string resultadoVenta = GuardarVentasBoletos(
                    int.Parse(lblHorarioId.Text),
                    cantidad,
                    asientosSeleccionados,
                    metodoPago,
                    estado
                );

                if (resultadoVenta.StartsWith("Error"))
                {
                    MessageBox.Show(resultadoVenta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener el ID de la venta recién creada
                Ventas_Id = ObtenerUltimoId("VentasBoletos").ToString();

                // Calcular el total
                decimal total = cantidad * Precio;

                // Guardar los detalles de la venta
                string resultadoDetalles = DetallesVenta(
                    int.Parse(Ventas_Id),
                    ManejadorLogin.UserId, // Asegúrate de tener el ID del usuario actual
                    total
                );

                if (resultadoDetalles.StartsWith("Error"))
                {
                    MessageBox.Show(resultadoDetalles, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show(
                    $"¡Compra realizada con éxito!\n" +
                    $"Total pagado: ${total:F2}",
                    "Confirmación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LimpiarSelecciones(cmbPeliculas, cmbHorarios, pnlAsientos, pnlResumen, lblHorarioId, lblSalaId, lblTotal);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al confirmar la compra: {ex.Message}",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarSelecciones(ComboBox cmbPeliculas, ComboBox cmbHorarios,
                                      Panel pnlAsientos, FlowLayoutPanel pnlResumen, Label lblHorarioId, Label lblSalaId, Label lblTotal)
        {
            asientosSeleccionados.Clear();
            lblHorarioId.Text = "";
            lblSalaId.Text = "";
            lblTotal.Text = "";
            cmbPeliculas.SelectedIndex = -1;
            cmbHorarios.SelectedIndex = -1;
            ConfigurarSala(pnlAsientos);
            ActualizarResumen(cmbPeliculas, cmbHorarios, pnlResumen, lblTotal);
        }


        private void ConfigurarEventos(ComboBox cmbPeliculas, ComboBox cmbHorarios, Button btnConfirmar, Panel pnlAsientos, FlowLayoutPanel pnlResumen, Label lblTotal)
        {
            cmbPeliculas.SelectedIndexChanged += (s, e) =>
            {
                cmbHorarios.Enabled = cmbPeliculas.SelectedIndex != -1;
                ActualizarResumen(cmbPeliculas, cmbHorarios, pnlResumen, lblTotal);
            };

            cmbHorarios.SelectedIndexChanged += (s, e) =>
            {
                ActualizarResumen(cmbPeliculas, cmbHorarios, pnlResumen, lblTotal);
            };

            
        }

        private void AsientoClick(object sender, EventArgs e)
        {
            Button btnAsiento = (Button)sender;
            if (btnAsiento.Tag.ToString() == "disponible")
            {
                ActualizarResumen(null, null, null, null);

                if (!EstaAsientoOcupado(btnAsiento.Text))
                {
                    btnAsiento.BackColor = Color.Orange;
                    btnAsiento.Tag = "seleccionado";
                    asientosSeleccionados.Add(btnAsiento);
                    ActualizarResumen(null, null, null, null); 
                }
                else
                {
                    MessageBox.Show("Este asiento ya está ocupado", "Asiento no disponible",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnAsiento.BackColor = Color.Red;
                    btnAsiento.Tag = "ocupado";
                }
            }
            else if (btnAsiento.Tag.ToString() == "seleccionado")
            {
                btnAsiento.BackColor = Color.LightGreen;
                btnAsiento.Tag = "disponible";
                asientosSeleccionados.Remove(btnAsiento);
                ActualizarResumen(null, null, null, null);
            }
        }

        private bool EstaAsientoOcupado(string numeroAsiento)
        {
            try
            {
                string query = $@"
                SELECT COUNT(*) FROM VentasBoletos 
                WHERE asiento LIKE '%{numeroAsiento}%' 
                AND estado = 'Pagado'";

                DataTable resultado = b.Consultar(query, "VentasBoletos").Tables[0];
                return Convert.ToInt32(resultado.Rows[0][0]) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void ActualizarResumen(ComboBox cmbPeliculas, ComboBox cmbHorarios, FlowLayoutPanel pnlResumen, Label lblTotal)
        {
            if (pnlResumen == null) return;

            pnlResumen.Controls.Clear();

            // Agregar encabezado
            pnlResumen.Controls.Add(new Label
            {
                Text = "Resumen de Compra",
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Margin = new Padding(0, 0, 0, 10)
            });

            // Mostrar película seleccionada
            if (cmbPeliculas?.SelectedItem != null)
            {
                dynamic pelicula = cmbPeliculas.SelectedItem;
                pnlResumen.Controls.Add(new Label
                {
                    Text = $"Película: {pelicula.Titulo}",
                    AutoSize = true,
                    Margin = new Padding(0, 0, 0, 5)
                });
            }

            // Mostrar horario seleccionado
            if (cmbHorarios?.SelectedItem != null)
            {
                pnlResumen.Controls.Add(new Label
                {
                    Text = $"Horario: {cmbHorarios.SelectedItem}",
                    AutoSize = true,
                    Margin = new Padding(0, 0, 0, 5)
                });
            }

            // Mostrar asientos seleccionados
            if (asientosSeleccionados.Count > 0)
            {
                pnlResumen.Controls.Add(new Label
                {
                    Text = "Asientos seleccionados:",
                    AutoSize = true,
                    Margin = new Padding(0, 10, 0, 5)
                });

                foreach (Button asiento in asientosSeleccionados)
                {
                    pnlResumen.Controls.Add(new Label
                    {
                        Text = $"Asiento {asiento.Text}: ${Precio:F2}",
                        AutoSize = true,
                        Margin = new Padding(10, 0, 0, 5)
                    });
                }
                cantidad = asientosSeleccionados.Count;
                precio= Precio;
                lblTotal.Text = $"{cantidad*precio}";

                // Mostrar total
                pnlResumen.Controls.Add(new Label
                {
                    Text = $"Total a pagar: ${asientosSeleccionados.Count * Precio:F2}",
                    AutoSize = true,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    Margin = new Padding(0, 10, 0, 0)
                });

            }
    }
    }
}
