using Manejador;
using Presentacion_TallerAutomotiz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Cinemonopylo_YJSG_VMG
{
    public partial class Peliculas : Form
    {
        private ManejadorAdministrador MM;
        private int fila;
        public static int Id;
        private string titulo, sinopsis, clasificacion, genero;
        private int duracion;
        private decimal precio;
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Id = int.Parse(dtgvAdministrador.Rows[fila].Cells[0].Value.ToString());
            MM.EliminarPeliculas(Id, dtgvAdministrador.Rows[fila].Cells[1].Value.ToString());
            Limpiar();
            txtBuscar.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Id = 0; titulo = ""; sinopsis = ""; clasificacion = ""; genero = ""; duracion = 0; precio = 0;
            FrmAgregarPeliculas dm = new FrmAgregarPeliculas();
            dm.ShowDialog();
            txtBuscar.Focus();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dtgvAdministrador.Visible = true;
            MM.MostrarAdministrador(dtgvAdministrador, txtBuscar.Text);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgvAdministrador != null && fila >= 0 && fila < dtgvAdministrador.Rows.Count)
                {
                    var filaSeleccionada = dtgvAdministrador.Rows[fila];
                    Id = int.Parse(filaSeleccionada.Cells[0].Value?.ToString() ?? "0");
                    titulo = filaSeleccionada.Cells[1].Value?.ToString() ?? string.Empty;
                    sinopsis = filaSeleccionada.Cells[2].Value?.ToString() ?? string.Empty;
                    duracion = int.Parse(filaSeleccionada.Cells[3].Value?.ToString() ?? "0");
                    clasificacion = filaSeleccionada.Cells[4].Value?.ToString() ?? string.Empty;
                    genero = filaSeleccionada.Cells[5].Value?.ToString() ?? string.Empty;
                    precio = decimal.Parse(filaSeleccionada.Cells[6].Value?.ToString() ?? "0");

                    FrmAgregarPeliculas dm = new FrmAgregarPeliculas();
                    dm.ShowDialog();
                    Limpiar();
                    txtBuscar.Focus();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una fila válida para modificar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        void Limpiar()
        {
            dtgvAdministrador.Visible = false;
        }

        public Peliculas()
        {
            InitializeComponent();
            try
            {
                MM = new ManejadorAdministrador();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar ManejadorAdministrador: " + ex.Message);
            }
        }

       
    }
}
