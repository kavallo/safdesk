using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.CATEGORIA.DATOS
{
    class DCATEGORIA
    {
        public int idcategoria { set; get; }
        public string descripcion { set; get; }
       
        

        private string connectionString;
        private SqlCommand cmd;
        public DCATEGORIA(string value)
        {
            connectionString = value;
        }
        public void InsertarCategoria()
        {
            SqlConnection mycon = new SqlConnection(connectionString);
            mycon.Open();
            cmd = new SqlCommand("Insertar_Categoria", mycon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion;

            cmd.ExecuteNonQuery();
            mycon.Close();
        }
   
        public DataTable MostrarCategoria()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("select * from categoria", conex);
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
