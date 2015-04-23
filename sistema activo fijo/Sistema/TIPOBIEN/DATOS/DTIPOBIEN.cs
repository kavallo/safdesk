using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.TIPOBIEN.DATOS
{
    class DTIPOBIEN
    {
        public int idtipobien { set; get; }
        public int idcategoria { set; get; }
        public string descripcion { set; get; }
       
        

        private string connectionString;
        private SqlCommand cmd;
        public DTIPOBIEN(string value)
        {
            connectionString = value;
        }
        public void InsertarTipobien()
        {
            SqlConnection mycon = new SqlConnection(connectionString);
            mycon.Open();
            cmd = new SqlCommand("Insertar_Tipobien", mycon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion;
            cmd.Parameters.Add("@idtipobien", SqlDbType.Int).Value = idcategoria;

            cmd.ExecuteNonQuery();
            mycon.Close();
        }
   
        public DataTable MostrarTipobien()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("select * from tipobien", conex);
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
