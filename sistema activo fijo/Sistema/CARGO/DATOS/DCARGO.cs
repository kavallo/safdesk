using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.CARGO.DATOS
{
    class DCARGO
    {

        public int idcargo { set; get; }
        public string descripcion { set; get; }
       
        

        private string connectionString;
        private SqlCommand cmd;
        public DCARGO(string value)
        {
            connectionString = value;
        }
        public void InsertarCargo()
        {
            SqlConnection mycon = new SqlConnection(connectionString);
            mycon.Open();
            cmd = new SqlCommand("Insertar_Cargo", mycon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion;

            cmd.ExecuteNonQuery();
            mycon.Close();
        }
   
        public DataTable MostrarCargo()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("select * from cargo", conex);
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
