using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Sistema.PERSONA.PERSONAL.DATOS
{
    class DPERSONAL
    {
        public int idpersona { set; get; }
        public int ci { set; get; }
        public string nombre { set; get; }
        public string direccion { set; get; }
        public int idcargo { set; get; }
        public int iddepartamento { set; get; }

        

        private string connectionString;
        private SqlCommand cmd;
        public DPERSONAL(string value)
        {
            connectionString = value;
        }
        public void InsertarPersonal()
        {
            SqlConnection mycon = new SqlConnection(connectionString);
            mycon.Open();
            cmd = new SqlCommand("Insertar_Personal", mycon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ci", SqlDbType.Int).Value = ci;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = direccion;
            cmd.Parameters.Add("@idcargo ", SqlDbType.Int).Value = idcargo;
            cmd.Parameters.Add("@iddepartamento", SqlDbType.Int).Value = iddepartamento;
            cmd.ExecuteNonQuery();
            mycon.Close();
        }
   
        public DataTable MostrarGrupo()
        {
            SqlConnection conex = new SqlConnection(connectionString);
            conex.Open();
            cmd = new SqlCommand("select * from persona, personal where idpersonal = idpersona", conex);
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
            finally {
                conex.Close();
            } 
            return null;
        }


    
    }
    }

