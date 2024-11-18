using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Cinemonopylo_YJSG_VMG
{
    public partial class FrmMenuTaquilla : Form
    {
        public FrmMenuTaquilla()
        {
            InitializeComponent();
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            FrmComprar_Boletos a = new FrmComprar_Boletos();
            a.MdiParent = this;
            a.Show();
        }





    }
}
