using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sistema.PERFILUSUARIO.DATOS
{
    class DLOGIN
    {
        public string nombre {set; get;}
        public string password { set; get;}
        public int codigo { set; get; }

        
        private string connectionString;
        private SqlCommand cmd;
        public DLOGIN(string value)
        {
            connectionString = value;
            
        }

        public int VerificarExisteUsuario()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            int s = 0;
            cmd = new SqlCommand("VerificarUsuario", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
            cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            try
            {
                s = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conex.Close();
            return s;
        }

        public int GetCodGrupo()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            int s = 0;
            cmd = new SqlCommand("GetCodigoGrupo", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
            cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            try
            {
                s = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conex.Close();
            return s;
        }
    }
}
