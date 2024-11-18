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

namespace Cinemonopylo_YJSG_VMG
{
    public partial class Peliculas : Form
    {
        int fila = 0, columna = 0;
        public static int Id = 0, duracion=0;
        public static string titulo = "", sinopsis = "", clasificacion = "", genero = "";
        public static decimal precio = 0;


        public Peliculas()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Id = 0; titulo = ""; sinopsis = ""; clasificacion = ""; duracion =0; genero = ""; precio = 0;
            FrmAgregarPeliculas dm = new FrmAgregarPeliculas();
            dm.ShowDialog();
            txtBuscar.Focus();
        }
    }
}
