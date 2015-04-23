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
    class CONEXIONUTIL
    {
        private string connectionString;
        

        public CONEXIONUTIL(string value)
        {
            connectionString = value;
        }

        public DataTable ejecutarconsulta(String sql)
        {
            //String sql = "SELECT DESCRIPCIONPAQUETE fROM PAQUETE";
            DataSet ds = new DataSet();
            SqlDataAdapter sd = new SqlDataAdapter(sql, connectionString);

            sd.Fill(ds, "consulta");
            
           

            

            return ds.Tables["consulta"];



        }
    }
}
