using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Manejador
{
    public class ManejadorUsuarios
    {
        Base b = new Base("localhost", "root", "", "cinemonopolyo");

        public string GuardarUser(TextBox Nombre, TextBox ApellidoP, TextBox ApellidoM, TextBox Email, TextBox NickName, TextBox Clave, ComboBox Tipo)
        {
            try
            {
                string campos = "Nombre, ApellidoPaterno, ApellidoMaterno, email, username, password, rol";
                string valores = $"'{Nombre.Text}', '{ApellidoP.Text}', '{ApellidoM.Text}', '{Email.Text}', '{NickName.Text}', '{Sha1(Clave.Text)}', '{Tipo.SelectedItem}'";
                return b.Comando($"CALL p_InsertarGenerico('Usuarios', '{campos}', '{valores}')");
            }
            catch (Exception)
            {
                return "Error de valor";
            }
        }

        public void MostrarAdministrador(DataGridView Tabla, string filtro)
        {
            Tabla.Columns.Clear();
            DataTable datos = b.Consultar($"SELECT * FROM Usuarios WHERE rol LIKE '%{filtro}%' OR Nombre LIKE '%{filtro}%' AND ApellidoPaterno LIKE '%{filtro}%'", "Usuarios").Tables[0];
            Tabla.DataSource = datos;
            Tabla.AutoResizeColumns();
            Tabla.AutoResizeRows();
        }

        public void Modificar(int Id, TextBox Nombre, TextBox ApellidoP, TextBox ApellidoM, TextBox Email, TextBox NickName, TextBox Clave, ComboBox Tipo)
        {
            string campos = "Id, Nombre, ApellidoPaterno, ApellidoMaterno, email, username, password, rol";
            string valores = $"{Id},'{Nombre.Text}', '{ApellidoP.Text}', '{ApellidoM.Text}', '{Email.Text}', '{NickName.Text}', '{Sha1(Clave.Text)}', '{Tipo.SelectedItem}'";
            b.Comando($"CALL p_ModificarGenerico('Usuarios', '{campos}', '{valores}')");
            MessageBox.Show("Registro Modificado", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Eliminar(int Id, string Dato)
        {
            DialogResult rs = MessageBox.Show($"Está seguro de borrar {Dato}", "!Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string condicion = $"id = {Id}";
                b.Comando($"CALL p_EliminarGenerico('Usuarios', '{condicion}')");
                MessageBox.Show("Registro Eliminado");
            }
        }

        public static string Sha1(string texto)
        {
            SHA1 sha1 = SHA1CryptoServiceProvider.Create();
            byte[] textOriginal = Encoding.Default.GetBytes(texto);
            byte[] hash = sha1.ComputeHash(textOriginal);
            StringBuilder cadena = new StringBuilder();
            foreach (byte i in hash)
            {
                cadena.AppendFormat("{0:x2}", i);
            }
            return cadena.ToString();
        }
    }
}
