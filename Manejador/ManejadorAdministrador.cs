using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;

namespace Manejador
{
    public class ManejadorAdministrador
    {
        Base b = new Base("localhost", "root", "", "cinemonopolyo");

        public string GuardarPeliculas(TextBox titulo, TextBox sinopsis, TextBox duracion, ComboBox clasificacion, TextBox genero, TextBox precio)
        {
            try
            {
                string campos = "titulo, sinopsis, duracion, clasificacion, genero, precio";
                string valores = $"'{titulo.Text}', '{sinopsis.Text}', '{duracion.Text}', '{clasificacion.Text}', '{genero.Text}', '{precio.Text}'";
                return b.Comando($"CALL p_InsertarGenerico('Peliculas', '{campos}', '{valores}')");
            }
            catch (Exception)
            {
                return "Error de valor";
            }
        }
        public void MostrarAdministrador(DataGridView Tabla, string filtro)
        {
            Tabla.Columns.Clear();
            DataTable datos = b.Consultar($"SELECT * FROM Peliculas WHERE titulo LIKE '%{filtro}%'", "Peliculas").Tables[0];
            Tabla.DataSource = datos;
            Tabla.AutoResizeColumns();
            Tabla.AutoResizeRows();
        }

      

        public void ModificarPeliculas(int Id, TextBox titulo, TextBox sinopsis, TextBox duracion, ComboBox clasificacion, TextBox genero, TextBox precio)
        {
            string campos = "Id, titulo, sinopsis, duracion, clasificacion, genero, precio";
            string valores = $"{Id}, '{titulo.Text}', '{sinopsis.Text}', '{duracion.Text}', '{clasificacion.Text}', '{genero.Text}', '{precio.Text}'";
            b.Comando($"CALL p_ModificarGenerico('Peliculas', '{campos}', '{valores}')");
            MessageBox.Show("Registro Modificado", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void EliminarPeliculas(int Id, string Dato)
        {
            DialogResult rs = MessageBox.Show($"Está seguro de borrar {Dato}", "!Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string condicion = $"id = {Id}";
                b.Comando($"CALL p_EliminarGenerico('Peliculas', '{condicion}')");
                MessageBox.Show("Registro Eliminado");
            }
        }

        public string GuardarHorarios(int peliculaId, TextBox txtSalaId, string fechaHora, TextBox txtCantidad)
        {
            try
            {
                string campos = "pelicula_id, sala_id, fecha_hora, boletos_existentes";
                string valores = $"'{peliculaId}', '{txtSalaId.Text}', '{fechaHora}', '{txtCantidad.Text}'";
                return b.Comando($"CALL p_InsertarGenerico('Horarios', '{campos}', '{valores}')");
            }
            catch (Exception)
            {
                return "Error de valor";
            }
        }

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

        public void CargarSala(ComboBox cmbSala, TextBox txtSalaId)
        {
            cmbSala.Items.Clear();
            try
            {
                DataTable datosSala = b.Consultar("SELECT id, nombre, ubicacion FROM Salas", "Salas").Tables[0];
                foreach (DataRow row in datosSala.Rows)
                {
                    cmbSala.Items.Add(new { Id = row["id"], Nombre = row["nombre"].ToString(), Ubicacion = row["ubicacion"].ToString() });
                    cmbSala.SelectedIndexChanged += (sender, e) =>
                    {
                        if (cmbSala.SelectedItem != null)
                        {
                            dynamic sala = cmbSala.SelectedItem;
                            int salaId = sala.Id;


                            DataTable datos = b.Consultar(
                                $"SELECT id FROM Salas WHERE id = {salaId}",
                                "Salas"
                            ).Tables[0];

                            if (datos.Rows.Count > 0)
                            {

                                int salaId1 = Convert.ToInt32(datos.Rows[0]["id"]);
                                txtSalaId.Text = $"{salaId1}";

                            }
                            else
                            {
                                txtSalaId.Text = "Sala: No disponible";
                            }
                        }

                    };
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






    }

}
