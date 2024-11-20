using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion_TallerAutomotiz;
using Manejador;
using PROYECTO;

namespace Cinemonopylo_YJSG_VMG
{
    public partial class FrmAgregarPeliculas : Form
    {

        ManejadorAdministrador mu;
        public FrmAgregarPeliculas()
        {
            InitializeComponent();
            mu = new ManejadorAdministrador();
            groupBox3.Visible = true;
            groupBox1.Visible = false;
            mu.CargarSala(cmbSala, txtSalaId);
        }
        int peliculaId=0;

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string fechaHora = $"{txtFecha.Text} {txtHora.Text}";

                // Si es una película existente (se seleccionó de la búsqueda)
                if (Peliculas.Id > 0)
                {
                    // Solo guardamos el horario usando el ID de la película seleccionada
                    string resultadoHorario = mu.GuardarHorarios(Peliculas.Id, txtSalaId, fechaHora, txtCantidad);
                    MessageBox.Show(resultadoHorario);
                }
                else // Si es una película nueva
                {
                    // Primero guardamos la película
                    string resultadoPelicula = mu.GuardarPeliculas(txtNombre, txtSinopsis, txtDuracion, cmbClasificacion, txtGenero, txtPrecio);

                    if (resultadoPelicula.ToLower().Contains("correcto"))
                    {
                        // Si la película se guardó correctamente, obtenemos su ID
                        int peliculaId = mu.ObtenerUltimoId("Peliculas");

                        // Y luego guardamos el horario con el ID de la película nueva
                        string resultadoHorario = mu.GuardarHorarios(peliculaId, txtSalaId, fechaHora, txtCantidad);
                        MessageBox.Show(resultadoHorario);
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar la película: " + resultadoPelicula);
                    }
                }

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtSinopsis.Clear();
            txtDuracion.Clear();
            cmbClasificacion.SelectedIndex = -1;
            txtGenero.Clear();
            txtPrecio.Clear();
            txtSalaId.Clear();
            txtCantidad.Clear();
            txtFecha.Clear();
            txtHora.Clear();
            peliculaId = 0;

        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox1.Visible = true;
            peliculaId = 0;
        }

        private void btnExistente_Click(object sender, EventArgs e)
        {
            FrmBuscarPrestamos buscar = new FrmBuscarPrestamos();
            buscar.ShowDialog();

            // Validar si se seleccionó una película en el formulario de búsqueda
            if (FrmBuscarPrestamos.IdPelicula > 0)
            {
                peliculaId = FrmBuscarPrestamos.IdPelicula; // Asignar ID de la película seleccionada
                txtNombre.Text = FrmBuscarPrestamos.titulo;
                txtSinopsis.Text = FrmBuscarPrestamos.sinopsis;
                txtDuracion.Text = FrmBuscarPrestamos.duracion.ToString();
                cmbClasificacion.Text = FrmBuscarPrestamos.clasificacion;
                txtGenero.Text = FrmBuscarPrestamos.genero;
                txtPrecio.Text = FrmBuscarPrestamos.precio.ToString();

                groupBox3.Visible = false;
                groupBox1.Visible = true; // Mostrar los campos para editar/guardar horario
            }
            else
            {
                MessageBox.Show("No se seleccionó ninguna película.");
            }
        }
    }
}
