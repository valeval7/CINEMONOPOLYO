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
            mu.CargarSala(cmbSala, txtSalaId);
            groupBox3.Visible = true;
            groupBox1.Visible = false;
        }
        int peliculaId=0;

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Peliculas.Id > 0)
                {
                    mu.ModificarPeliculas(Peliculas.Id, txtNombre, txtSinopsis, txtDuracion, cmbClasificacion, txtGenero, txtPrecio);
                    MessageBox.Show("Película modificada correctamente.");
                    Peliculas.Id = 0;
                }
                else
                {
                    string resultadoPelicula = mu.GuardarPeliculas(txtNombre, txtSinopsis, txtDuracion, cmbClasificacion, txtGenero, txtPrecio);
                    MessageBox.Show(resultadoPelicula);

                    if (resultadoPelicula.ToLower().Contains("éxito"))
                    {
                        peliculaId = mu.ObtenerUltimoId("Peliculas");
                        var fecha_hora = $"{dtpFecha.Value:yyyy-MM-dd} {dtpHora.Value:HH:mm:ss}";
                        MessageBox.Show(mu.GuardarHorarios(peliculaId, txtSalaId, fecha_hora, txtCantidad));
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
            dtpFecha.Value = DateTime.Now;
            dtpHora.Value = DateTime.Now;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox1.Visible = true;
        }

        private void btnExistente_Click(object sender, EventArgs e)
        {
            FrmBuscarPrestamos b = new FrmBuscarPrestamos();
            b.ShowDialog();
            if (FrmBuscarPrestamos.IdPelicula > 0)
            {
                peliculaId = FrmBuscarPrestamos.IdPelicula;
                txtNombre.Text = FrmBuscarPrestamos.titulo.ToString();
                txtSinopsis.Text = FrmBuscarPrestamos.sinopsis.ToString();
                txtDuracion.Text = FrmBuscarPrestamos.duracion.ToString();
                cmbClasificacion.Text = FrmBuscarPrestamos.clasificacion.ToString();
                txtGenero.Text = FrmBuscarPrestamos.genero.ToString();
                txtPrecio.Text = FrmBuscarPrestamos.precio.ToString();
                groupBox3.Visible = false;
                groupBox1.Visible = true;
            }
            txtNombre.Focus();
            txtSinopsis.Focus();
            txtDuracion.Focus();
            cmbClasificacion.Focus();
            txtGenero.Focus();
            txtPrecio.Focus();
        }
    }
}
