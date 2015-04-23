using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sistema
{
    class Conexion
    {
        string stringConecction;
        public Conexion(string value)
        {
            this.stringConecction = value;
        }
        public SqlConnection getConecction()
        {
            return new SqlConnection(stringConecction);
        }
    }
}
