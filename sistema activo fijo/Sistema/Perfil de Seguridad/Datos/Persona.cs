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
    class Persona
    {
        public int personaID { set; get; }
        public string nombres { set; get; }
        public string apellidos { set; get; }
        public string direccion { set; get; }
        public char sexo { set; get; }
        public string tipo { set; get; }

        private string connectionString;
        private SqlCommand cmd;
        public Persona(string value)
        {
            connectionString = value;
        }
        public void agregar_Persona()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("insertar_Persona", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@personaID", SqlDbType.Int).Value = personaID;
            cmd.Parameters.Add("@nombres", SqlDbType.VarChar).Value = nombres;
            cmd.Parameters.Add("@apellidos", SqlDbType.VarChar).Value = apellidos;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = direccion;
            cmd.Parameters.Add("@sexo", SqlDbType.Char).Value = sexo;
            cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo; cmd.ExecuteNonQuery();
            conex.Close();
        }
        public void actualizar_Persona()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("actualizar_Persona", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@personaID", SqlDbType.Int).Value = personaID;
            cmd.Parameters.Add("@nombres", SqlDbType.VarChar).Value = nombres;
            cmd.Parameters.Add("@apellidos", SqlDbType.VarChar).Value = apellidos;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = direccion;
            cmd.Parameters.Add("@sexo", SqlDbType.Char).Value = sexo;
            cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
            cmd.ExecuteNonQuery();
            conex.Close();
        }
        public DataTable mostrar_Personas()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("mostrar_Personas", conex);
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
        public DataTable buscar_Persona()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("buscar_Persona", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@personaID", SqlDbType.Int).Value = personaID;
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
        public void eliminar_Persona()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("eliminar_Persona", conex);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@personaID", SqlDbType.Int).Value = personaID;

            cmd.ExecuteNonQuery();
            conex.Close();
        }
    }
}
