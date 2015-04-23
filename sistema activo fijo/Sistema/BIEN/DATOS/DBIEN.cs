using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.BIEN.DATOS
{
    class DBIEN
    {
        public int idbien { set; get; }
        public int idtipobien { set; get; }
        public int idingresoegreso { set; get; }
        public string nombre { set; get; }
        public float preciocompra{set; get;}
        public float precioactual{set; get;}

        public string fechaingreso{set; get;}
        public string fechaegreso{set; get;}
       
        

        private string connectionString;
        private SqlCommand cmd;
        public DBIEN(string value)
        {
            connectionString = value;
        }
        public void InsertarBien()
        {
            SqlConnection mycon = new SqlConnection(connectionString);
            mycon.Open();
            cmd = new SqlCommand("Insertar_Bien", mycon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
            cmd.Parameters.Add("@preciocompra", SqlDbType.Float).Value = preciocompra;
            cmd.Parameters.Add("@idingreso", SqlDbType.Int).Value = idingresoegreso;
            cmd.Parameters.Add("@idtipobien", SqlDbType.Int).Value = idtipobien;
            

            cmd.ExecuteNonQuery();
            mycon.Close();
        }
   
        public DataTable MostrarBien()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("select idbien, nombre, preciocompra, precioactual, idingreso, idtipobien, fechaingreso from bien", conex);
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
