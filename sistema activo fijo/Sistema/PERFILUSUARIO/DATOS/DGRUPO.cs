using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sistema.PERFILUSUARIO.DATOS
{
    class DGRUPO
    {
        public int grupoID { set; get; }
        public string nombre { set; get; }

        private string connectionString;
        private SqlCommand cmd;
        public DGRUPO(string value)
        {
            connectionString = value;
        }
        public void InsertarGrupo()
        {
            SqlConnection mycon = new SqlConnection(connectionString);
            mycon.Open();
            cmd = new SqlCommand("Insertar_Grupo", mycon);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@idgrupo ", SqlDbType.Int).Value = grupoID;
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = nombre;
            cmd.ExecuteNonQuery();
            mycon.Close();
        }
        public void ActualizarGrupo()
        {
            SqlConnection mycon = new SqlConnection(connectionString);
            mycon.Open();
            cmd = new SqlCommand("Actualizar_Grupo", mycon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idgrupo ", SqlDbType.Int).Value = grupoID;
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = nombre;
            cmd.ExecuteNonQuery();
            mycon.Close();
        }
        public DataTable MostrarGrupo()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("Buscar_Grupo", conex);
            cmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable BuscarGrupo()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("Buscar_Grupo", conex);
            cmd.Parameters.Add("@idgrupo", SqlDbType.Int).Value = grupoID;
            cmd.CommandType = CommandType.StoredProcedure;
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

        public void EliminarGrupo()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("Eliminar_Grupo", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idgrupo ", SqlDbType.Int).Value = grupoID;
            cmd.ExecuteNonQuery();
            conex.Close();
        }
        public Boolean Existe_Grupo()
        {

            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            Boolean sw = false;
            cmd = new SqlCommand("Existe_Grupo", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = nombre;
            try
            {
                int id = Convert.ToInt32(cmd.ExecuteScalar());

                if (id > 0)
                {
                    sw = true;
                }
                else
                {
                    sw = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conex.Close();
            return sw;
        }
        public int ObtenerId_Grupo()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            int s = 0;
            cmd = new SqlCommand("ObtenerId_grupo", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = nombre;
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
        public string ObtenerNombre_Grupo()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            string s = "";
            cmd = new SqlCommand("ObtenerNombre_grupo", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id_grupo", SqlDbType.Int).Value = grupoID;
            try
            {
                s = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conex.Close();
            return s;
        }
        public int ObtenerID_Grupo_CIEmpleado(int ci_empleado)
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            int s = 0;
            cmd = new SqlCommand("obtenerGrupo_Ciempleado", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ci_empleado", SqlDbType.Int).Value = ci_empleado;
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
    
    }
    
}
