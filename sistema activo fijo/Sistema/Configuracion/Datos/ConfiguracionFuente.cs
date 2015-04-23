using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Sistema.Configuracion.Datos
{
    class ConfiguracionFuente
    {
        public string  NombreForm;
            public int empleadoID;
            public string NombreFuente;
            public string  estiloFuente;
            public string  TamanoFuente;
            public string  unidadFuente;
            public string  charsetFuente;
            public string verticalfontFuente;
            private string connectionString;
            private SqlCommand cmd;
            public ConfiguracionFuente(string value)
            {
                connectionString = value;
            }
         public void agregar_Fuente(){
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("insertar_Fuente", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NombreForm", SqlDbType.VarChar).Value = NombreForm;
            cmd.Parameters.Add("@empleadoID", SqlDbType.Int).Value = empleadoID;
            cmd.Parameters.Add("@NombreFuente", SqlDbType.VarChar).Value = NombreFuente;
            cmd.Parameters.Add("@TamanoFuente", SqlDbType.VarChar).Value= TamanoFuente;
            cmd.Parameters.Add("@unidadFuente", SqlDbType.VarChar).Value = unidadFuente;
            cmd.Parameters.Add("@charsetFuente", SqlDbType.VarChar).Value= charsetFuente;
            cmd.Parameters.Add("@verticalfontFuente", SqlDbType.VarChar).Value= verticalfontFuente;
            cmd.Parameters.Add("@estiloFuente", SqlDbType.VarChar).Value= estiloFuente;
            cmd.ExecuteNonQuery();
            
            conex.Close();
         }

        public DataTable mostrar_Fuentes(){
            SqlConnection conex= new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("mostrar_Fuente", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            try{
                SqlDataAdapter sa =new SqlDataAdapter(cmd);
                DataTable db= new DataTable();
                sa.Fill(db);
                return db;
                sa.Dispose();
            }catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
            conex.Close();
            return null;
        }

        public DataTable buscar_Fuente()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("buscar_Fuente", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmpleadoID", SqlDbType.Int).Value = empleadoID;
            cmd.Parameters.Add("@NombreForm", SqlDbType.VarChar).Value = NombreForm;
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
