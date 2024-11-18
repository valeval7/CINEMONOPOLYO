using AccesoDatos;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Manejador
{
    public class ManejadorLogin
    {
        Base b = new Base("localhost", "root", "", "cinemonopolyo");
        public static string Tipo = "";
        public static int UserId = 0;

        public string Validar(TextBox NickName, TextBox Clave)
        {
            DataSet ds = b.Consultar($"call p_ValidarU('{NickName.Text}', '{Sha1(Clave.Text)}')", "usuarios");
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0 && dt.Rows[0]["rs"].ToString().Equals("C0rr3cto"))
            {
                Tipo = dt.Rows[0]["rol"].ToString();
                UserId = Convert.ToInt32(dt.Rows[0]["id"]);

                return "C0rr3cto";
            }
            else
            {
                return "Error";
            }
        }

        public string CrearUsuarioInvitado()
        {
            try
            {
                // Call the new stored procedure
                DataSet ds = b.Consultar("CALL p_CrearUsuarioInvitado()", "usuarios");
                DataTable dt = ds.Tables[0];

                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["rs"].ToString() == "C0rr3cto")
                {
                    // Set the static variables just like in regular login
                    Tipo = dt.Rows[0]["rol"].ToString();
                    UserId = Convert.ToInt32(dt.Rows[0]["id"]);

                    return "C0rr3cto";
                }
                else
                {
                    return "Error al crear usuario invitado";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear usuario invitado: " + ex.Message);
                return "Error";
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
