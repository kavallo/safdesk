using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.DEPARTAMENTO.DATOS
{
    class DDEPARTAMENTO
    {
        public int iddepartamento { set; get; }
        public string descripcion { set; get; }
        public string nombre { set; get; }
       
        

        private string connectionString;
        private SqlCommand cmd;
        public DDEPARTAMENTO(string value)
        {
            connectionString = value;
        }
        public void InsertarDepartamento()
        {
            SqlConnection mycon = new SqlConnection(connectionString);
            mycon.Open();
            cmd = new SqlCommand("Insertar_Departamento", mycon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;

            cmd.ExecuteNonQuery();
            mycon.Close();
        }
   
        public DataTable MostrarDepartamento()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("select * from departamento", conex);
            cmd.CommandType = CommandType.Text;
            try
            {
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                DataTable db = new DataTable();
                sa.Fill(db);
                sa.Dispose();
                return db;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conex.Close();
            return null;
        }
    }
}
