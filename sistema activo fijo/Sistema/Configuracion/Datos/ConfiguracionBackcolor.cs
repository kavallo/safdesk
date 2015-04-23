using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Configuracion.Datos
{
    class ConfiguracionBackcolor
    {
        public string NombreFormB { set; get; }
        public int empleadoID { set; get; }
        public string Backcolor { set; get; }
        public string BackcolorA { set; get; }
        public string BackcolorR { set; get; }
        public string BackcolorG { set; get; }
        public string BackcolorB { set; get; }

        private string connectionString;

        private SqlCommand cmd;

        public ConfiguracionBackcolor(string value)
        {
            connectionString = value;
        }

        public void agregar_Backcolor()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("insertar_Backcolor", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NombreForm", SqlDbType.VarChar).Value = NombreFormB;
            cmd.Parameters.Add("@empleadoID", SqlDbType.Int).Value = empleadoID;
            cmd.Parameters.Add("@Backcolor", SqlDbType.VarChar).Value = Backcolor;
            cmd.Parameters.Add("@BackcolorA", SqlDbType.VarChar).Value = BackcolorA;
            cmd.Parameters.Add("@BackcolorR", SqlDbType.VarChar).Value = BackcolorR;
            cmd.Parameters.Add("@BackcolorG", SqlDbType.VarChar).Value = BackcolorG;
            cmd.Parameters.Add("@BackcolorB", SqlDbType.VarChar).Value = BackcolorB;
            cmd.ExecuteNonQuery();
            conex.Close();
        }

        public DataTable mostrar_Backcolors()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("mostrar_Backcolor", conex);
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

        public DataTable buscar_Backcolor()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("buscar_Backcolor", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmpleadoID", SqlDbType.Int).Value = empleadoID;
            cmd.Parameters.Add("@NombreForm", SqlDbType.VarChar).Value = NombreFormB;
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
