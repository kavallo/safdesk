using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.EGRESO_INGRESO.DATOS
{
    class DEGRESO_INGRESO
    {
        public int idingresoegreso { set; get; }
        public string tipoingreso { set; get; }
       public string tipoegreso { set; get; }
        

        private string connectionString;
        private SqlCommand cmd;
        public DEGRESO_INGRESO(string value)
        {
            connectionString = value;
        }
        public void InsertarIngreso()
        {
            SqlConnection mycon = new SqlConnection(connectionString);
            mycon.Open();
            cmd = new SqlCommand("Insertar_Ingreso_egreso", mycon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tipoingreso", SqlDbType.VarChar).Value = tipoingreso;
            cmd.Parameters.Add("@tipoegreso", SqlDbType.VarChar).Value = "";

            cmd.ExecuteNonQuery();
            mycon.Close();
        }


        public void InsertarEgreso()
        {
            SqlConnection mycon = new SqlConnection(connectionString);
            mycon.Open();
            cmd = new SqlCommand("Insertar_Ingreso_egreso", mycon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tipoingreso", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@tipoegreso", SqlDbType.VarChar).Value = tipoegreso;

            cmd.ExecuteNonQuery();
            mycon.Close();
        }
        public DataTable MostrarIngreso()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("select * from ingresoegreso ", conex);
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
