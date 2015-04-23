using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Sistema.Perfil_de_Seguridad.Datos
{
    class Trabajador
    {
        private string connectionString;
        private SqlCommand cmd;
        public int empleadoID { set; get; }
        public string nick { set; get; }
        public string password { set; get; }
        public string estado { set; get; }
        public string cargo { set; get; }
        public string disponibilidad { set; get; }
        public int grupoID { set; get; }

        public Trabajador(string value)
        {
            connectionString = value;
        }
        public void agregar_Trabajador()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("insertar_Empleado", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empleadoID", SqlDbType.Int).Value = empleadoID;
            cmd.Parameters.Add("@grupoID", SqlDbType.Int).Value = grupoID;
            cmd.Parameters.Add("@cargo", SqlDbType.VarChar).Value = cargo;
            cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = estado;
            cmd.Parameters.Add("@disponibilidad", SqlDbType.VarChar).Value = disponibilidad;
            cmd.Parameters.Add("@nick", SqlDbType.VarChar).Value = nick;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            cmd.ExecuteNonQuery();
            conex.Close();
        }
        public Boolean existUsuario(string username, string pass)
        {
            string str;
            SqlConnection myConn = new SqlConnection(connectionString);
            str = "SELECT * FROM Empleado WHERE nick = '" + username + "' AND DECRYPTBYPASSPHRASE ('clave',password ) = '" + pass + "'";
            SqlCommand myCommand = new SqlCommand(str, myConn);
            SqlDataReader reader = null;
            try
            {
                myConn.Open();
                reader = myCommand.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
            return false;
        }
        public void actualizar_Trabajador()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("actualizar_Empleado", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empleadoID", SqlDbType.Int).Value = empleadoID;
            cmd.Parameters.Add("@grupoID", SqlDbType.Int).Value = grupoID;
            cmd.Parameters.Add("@cargo", SqlDbType.VarChar).Value = cargo;
            cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = estado;
            cmd.Parameters.Add("@disponibilidad", SqlDbType.VarChar).Value = disponibilidad;
            cmd.Parameters.Add("@nick", SqlDbType.VarChar).Value = nick;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            cmd.ExecuteNonQuery();
            conex.Close();
        }
        public DataTable mostrar_Trabajadores()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("mostrar_Trabajadores1", conex);
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
        public DataTable devolverNombreApellido()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("MostrarNombre_Apellido_Empleado", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@cipersona", SqlDbType.Int).Value = empleadoID;
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
        public DataTable buscar_Trabajador()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("buscar_Trabajador1", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empleadoID", SqlDbType.Int).Value = empleadoID;
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
        public DataTable buscar_TrabajadorLike(string nombre)
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("Buscar_TrabajadorLike", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
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

        public void eliminar_Trabajador()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("eliminar_Empleado", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empleadoID", SqlDbType.Int).Value = empleadoID;
            cmd.ExecuteNonQuery();
            conex.Close();
        }
        public string obtener_NombreTrabajador()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            string s = "";
            cmd = new SqlCommand("buscar_TrabajadorNombre", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empleadoID", SqlDbType.Int).Value = empleadoID;
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
        public Boolean ConsultarAcceso()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            Boolean sw = false;
            cmd = new SqlCommand("Mostrar_empleadopass", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nick", SqlDbType.VarChar).Value = nick;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            try
            {
                string id = Convert.ToString(cmd.ExecuteScalar());
                if (id != "")
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
        public int DevolverID_EmpleadoSesion()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            int id2 = 0;
            cmd = new SqlCommand("ID_empleadoSesion", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nick", SqlDbType.VarChar).Value = nick;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            try
            {
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                if (id > 0)
                {
                    id2 = id;
                }
                else
                {
                    MessageBox.Show("no existe empleado registrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conex.Close();
            return id2;

        }
        public int DevolverID_Empleado(string nombre)
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            int id2 = 0;
            cmd = new SqlCommand("devolverIDEmpleado", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
            try
            {
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                if (id > 0)
                {
                    id2 = id;
                }
                else
                {
                    MessageBox.Show("no existe empleado registrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conex.Close();
            return id2;
        }
        public int DevolverID_Grupo()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            int id2 = 0;
            cmd = new SqlCommand("devolverIDGrupo", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ciempleado", SqlDbType.Int).Value = empleadoID;
            try
            {
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                if (id > 0)
                {
                    id2 = id;
                }
                else
                {
                    MessageBox.Show("no existe empleado registrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conex.Close();
            return id2;
        }
    }
}
