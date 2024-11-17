using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Manejador
{
    public class ManejadorCliente
    {
        private const decimal PRECIO_BOLETO = 80.00M;
        private List<Button> asientosSeleccionados = new List<Button>();

        public void InicializarFormulario(ComboBox cmbPeliculas, ComboBox cmbHorarios, Panel pnlAsientos, Button btnConfirmar, FlowLayoutPanel pnlResumen)
        {
            CargarDatosDePrueba(cmbPeliculas, cmbHorarios);
            ConfigurarSala(pnlAsientos);
            ConfigurarEventos(cmbPeliculas, cmbHorarios, btnConfirmar, pnlAsientos, pnlResumen);
        }

        private void CargarDatosDePrueba(ComboBox cmbPeliculas, ComboBox cmbHorarios)
        {
            cmbPeliculas.Items.AddRange(new string[]
            {
                "Dune: Parte 2",
                "Kung Fu Panda 4",
                "Ghostbusters: Imperio Helado"
            });

            cmbHorarios.Items.AddRange(new string[]
            {
                "14:30",
                "17:00",
                "19:30",
                "22:00"
            });
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

        private void ConfigurarEventos(ComboBox cmbPeliculas, ComboBox cmbHorarios, Button btnConfirmar, Panel pnlAsientos, FlowLayoutPanel pnlResumen)
        {
            cmbPeliculas.SelectedIndexChanged += (s, e) =>
            {
                cmbHorarios.Enabled = cmbPeliculas.SelectedIndex != -1;
                ActualizarResumen(cmbPeliculas, cmbHorarios, pnlResumen);
            };

            cmbHorarios.SelectedIndexChanged += (s, e) =>
            {
                ActualizarResumen(cmbPeliculas, cmbHorarios, pnlResumen);
            };

            btnConfirmar.Click += (s, e) =>
            {
                if (asientosSeleccionados.Count > 0)
                {
                    MessageBox.Show($"¡Compra realizada con éxito!\n" +
                                  $"Total pagado: ${asientosSeleccionados.Count * PRECIO_BOLETO:F2}",
                                  "Confirmación",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);

                    asientosSeleccionados.Clear();
                    cmbPeliculas.SelectedIndex = -1;
                    cmbHorarios.SelectedIndex = -1;
                    ConfigurarSala(pnlAsientos);
                    ActualizarResumen(cmbPeliculas, cmbHorarios, pnlResumen);
                }
            };
        }

        private void AsientoClick(object sender, EventArgs e)
        {
            Button btnAsiento = (Button)sender;
            if (btnAsiento.Tag.ToString() == "disponible")
            {
                btnAsiento.BackColor = Color.Orange;
                btnAsiento.Tag = "seleccionado";
                asientosSeleccionados.Add(btnAsiento);
            }
            else if (btnAsiento.Tag.ToString() == "seleccionado")
            {
                btnAsiento.BackColor = Color.LightGreen;
                btnAsiento.Tag = "disponible";
                asientosSeleccionados.Remove(btnAsiento);
            }
        }

        private void ActualizarResumen(ComboBox cmbPeliculas, ComboBox cmbHorarios, FlowLayoutPanel pnlResumen)
        {
            pnlResumen.Controls.Clear();

            Label lblResumenTitulo = new Label
            {
                Text = "Resumen de Compra",
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 10)
            };
            pnlResumen.Controls.Add(lblResumenTitulo);

            if (cmbPeliculas.SelectedIndex != -1)
            {
                pnlResumen.Controls.Add(new Label
                {
                    Text = $"Película: {cmbPeliculas.SelectedItem}",
                    AutoSize = true,
                    Margin = new Padding(0, 0, 0, 5)
                });
            }

            if (cmbHorarios.SelectedIndex != -1)
            {
                pnlResumen.Controls.Add(new Label
                {
                    Text = $"Horario: {cmbHorarios.SelectedItem}",
                    AutoSize = true,
                    Margin = new Padding(0, 0, 0, 5)
                });
            }

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
                        Text = $"Asiento {asiento.Text}: ${PRECIO_BOLETO:F2}",
                        AutoSize = true,
                        Margin = new Padding(10, 0, 0, 5)
                    });
                }
            }
        }
    }
}
