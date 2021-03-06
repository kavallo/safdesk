﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Sistema.PERFILUSUARIO.DATOS
{
    class DUSUARIO
    {
         private string connectionString;
        private SqlCommand cmd;
        public int usuarioid { set; get; }
        public string nick { set; get; }
        public string password { set; get; }
        public string estado { set; get; }
        public string cargo { set; get; }
        public int grupoid { set; get; }
        public int personalid { set; get; }

        public DUSUARIO(string value)
        {
            connectionString = value;
        }
        public void agregar_usuario()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("Insertar_Usuario", conex);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@codgrupo", SqlDbType.Int).Value = grupoid;
            cmd.Parameters.Add("@codpersonal", SqlDbType.Int).Value = personalid;
            cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = estado;
            cmd.Parameters.Add("@nick", SqlDbType.VarChar).Value = nick;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            cmd.ExecuteNonQuery();
            conex.Close();
        }
        public Boolean existeUsuario(string username, string pass)
        {
            string str;
            SqlConnection myConn = new SqlConnection(connectionString);
            str = "SELECT * FROM usuario WHERE NOMBREUSUARIO = '" + username + "' AND DECRYPTBYPASSPHRASE ('clave',CONTRASENIA ) = '" + pass + "'";
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
        public void actualizar_usuario()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("actualizar_Empleado", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@usuarioid", SqlDbType.Int).Value = usuarioid;
            cmd.Parameters.Add("@grupoID", SqlDbType.Int).Value = grupoid;
            cmd.Parameters.Add("@cargo", SqlDbType.VarChar).Value = cargo;
            cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = estado;
            
            cmd.Parameters.Add("@nick", SqlDbType.VarChar).Value = nick;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            cmd.ExecuteNonQuery();
            conex.Close();
        }
        public DataTable mostrar_usuario()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("select codusuario, nombreusuario from usuario", conex);
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
        public DataTable devolverNombreApellido()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("MostrarNombre_Apellido_Empleado", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@cipersona", SqlDbType.Int).Value = usuarioid;
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
        public DataTable buscar_usuario()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("buscar_Trabajador1", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@usuarioid", SqlDbType.Int).Value = usuarioid;
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
        public DataTable buscar_usuarioLike(string nombre)
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

        public void eliminar_usuario()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("eliminar_Empleado", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@usuarioid", SqlDbType.Int).Value = usuarioid;
            cmd.ExecuteNonQuery();
            conex.Close();
        }
        public string obtener_Nombreusuario()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            string s = "";
            cmd = new SqlCommand("buscar_TrabajadorNombre", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@usuarioid", SqlDbType.Int).Value = usuarioid;
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
            cmd.Parameters.Add("@ciempleado", SqlDbType.Int).Value = usuarioid;
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
