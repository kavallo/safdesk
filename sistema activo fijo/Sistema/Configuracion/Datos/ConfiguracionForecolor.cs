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
    class ConfiguracionForecolor
    {
        public string NombreForm;
        public int empleadoID;
        public string Forecolor;
        public string ForecolorA;
        public string ForecolorR;
        public string ForecolorG;
        public string ForecolorB;
        private string connectionString;
        private SqlCommand cmd;
        public ConfiguracionForecolor(string value)
        {
            connectionString = value;
        }
        public void agregar_Forecolor()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("insertar_Forecolor", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NombreForm", SqlDbType.VarChar).Value = NombreForm;
            cmd.Parameters.Add("@empleadoID", SqlDbType.Int).Value = empleadoID;
            cmd.Parameters.Add("@Forecolor", SqlDbType.VarChar).Value = Forecolor;
            cmd.Parameters.Add("@ForecolorA", SqlDbType.VarChar).Value = ForecolorA;
            cmd.Parameters.Add("@ForecolorR", SqlDbType.VarChar).Value = ForecolorR;
            cmd.Parameters.Add("@ForecolorG", SqlDbType.VarChar).Value = ForecolorG;
            cmd.Parameters.Add("@ForecolorB", SqlDbType.VarChar).Value = ForecolorB;
            cmd.ExecuteNonQuery();

            conex.Close();
        }

        public DataTable mostrar_Forecolors()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("mostrar_Forecolor", conex);
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

        public DataTable buscar_Forecolor()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("buscar_Forecolor", conex);
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
