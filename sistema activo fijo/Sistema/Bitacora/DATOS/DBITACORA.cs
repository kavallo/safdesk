
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace Sistema.Bitacora.DATOS
{
    class DBITACORA
    {

       public string nombre { get; set; }
        public int codigo { get; set; }

         private string connectionString;
        private SqlCommand cmd;
        public DBITACORA(string value)
        {
            connectionString = value;
        }
        public void InsertarBitacora()
        {

            SqlConnection mycon = new SqlConnection(connectionString);
            mycon.Open();
            cmd = new SqlCommand("Insertar_Bitacora", mycon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@codusuario ", SqlDbType.Int).Value = codigo;
           
            cmd.ExecuteNonQuery();
            mycon.Close();
        }


        public void ActualizarHoraSalidaBitacora()
        {


            SqlConnection mycon = new SqlConnection(connectionString);
            mycon.Open();
            try
            {

                cmd = new SqlCommand("ActualizarHoraSalidaBitacora", mycon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                MessageBox.Show("error " + ex.ToString());
            }
         finally {
                mycon.Close();    
            }

            
        }



        public int ObtenerCod_Usuario()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            int s = 0;
            cmd = new SqlCommand("BuscarCodusario", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombreuser", SqlDbType.VarChar).Value = nombre;
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

        public DataTable MostrarBitacora()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("Mostrar_Bitacora", conex);
            
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                DataTable db = new DataTable();
                sa.Fill(db);
                return db;
                sa.Dispose();
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
