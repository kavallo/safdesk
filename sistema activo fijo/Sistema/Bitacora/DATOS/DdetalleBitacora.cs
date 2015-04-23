using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Sistema.Bitacora.DATOS
{
    class DdetalleBitacora
    {
        public String operacion { get; set; }

          private string connectionString;
        private SqlCommand cmd;
        public DdetalleBitacora(string value)
        {
            connectionString = value;
        }
        public void InsertarDetalleBitacora()
        {
            SqlConnection mycon = new SqlConnection(connectionString);
            mycon.Open();
            cmd = new SqlCommand("Insertar_DetalleBitacora", mycon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@operacion ", SqlDbType.VarChar).Value = operacion;
           
            cmd.ExecuteNonQuery();
            mycon.Close();
        }

    }
}
