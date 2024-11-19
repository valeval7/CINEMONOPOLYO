using Manejador;

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

namespace PROYECTO
{
    public partial class FrmBuscarPrestamos : Form
    {
        ManejadorAdministrador mp;
        int fila = 0, columna = 0;
        public static int IdPelicula = 0, duracion=0;
        public  static string titulo, sinopsis, clasificacion, genero;
        public static decimal precio;

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (fila >= 0)
            {
                IdPelicula = int.Parse(dtgvDatos.Rows[fila].Cells[0].Value.ToString());
                titulo = dtgvDatos.Rows[fila].Cells[1].Value.ToString();
                sinopsis = dtgvDatos.Rows[fila].Cells[2].Value.ToString();
                duracion = int.Parse(dtgvDatos.Rows[fila].Cells[3].Value.ToString());
                clasificacion = dtgvDatos.Rows[fila].Cells[4].Value.ToString();
                genero = dtgvDatos.Rows[fila].Cells[5].Value.ToString();
                precio = decimal.Parse(dtgvDatos.Rows[fila].Cells[6].Value.ToString());
                Close();
                txtBuscar.Focus();
            }
            else
                MessageBox.Show("Por favor, seleccione una fila válida.");
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            IdPelicula = 0; 
            Close();
        }

        public FrmBuscarPrestamos()
        {
            InitializeComponent();
            mp = new ManejadorAdministrador();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dtgvDatos.Visible = true;
            mp.MostrarAdministrador(dtgvDatos, txtBuscar.Text);
        }

        private void dtgvDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
