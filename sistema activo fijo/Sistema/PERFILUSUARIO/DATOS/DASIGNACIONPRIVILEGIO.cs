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
    class DASIGNACIONPRIVILEGIO
    {

        public string grupo {set; get;}
        public int codigo { set; get; }

        private string connectionString;
        private SqlCommand cmd;
        public DASIGNACIONPRIVILEGIO(string value)
        {
            connectionString = value;
        }


        public void RegistrarPrivilegio()
        {
            //aca hay un error que no me deja meter llave duplicada
            SqlConnection mycon = new SqlConnection(connectionString);
            mycon.Open();

            try
            {
                cmd = new SqlCommand("RegistrarAsignacionPrivilegio", mycon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Grupo", SqlDbType.VarChar).Value = grupo;
                cmd.Parameters.Add("@CodPrivilegio", SqlDbType.Int).Value = codigo;

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                Console.WriteLine("privilegio repetido");
            }

                mycon.Close();


        }

        public void QuitarPrivilegio()
        {
            SqlConnection mycon = new SqlConnection(connectionString);
            mycon.Open();

            cmd = new SqlCommand("Eliminar_grupoprivilegio", mycon);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@codgrupos", SqlDbType.Int).Value = codigo;

            cmd.ExecuteNonQuery();
            mycon.Close();


        }
    }
}
