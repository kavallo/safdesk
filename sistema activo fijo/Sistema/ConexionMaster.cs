using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sistema
{
    class ConexionMaster
    {
        private string StrSql;
        private SqlConnection cn;
        private SqlCommand cmd;
        public ConexionMaster()
        {
            cn = new SqlConnection();
            StrSql = "Data Source=(local);Initial Catalog=master;Integrated Security=True";
        }
        public void Conectar()
        {
            cn = new SqlConnection();
            try
            {
                cn.ConnectionString = StrSql;
                cn.Open();
                MessageBox.Show("Conectado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Boolean Abrir()
        {
            cn = new SqlConnection();
            Boolean sw = false;
            try
            {
                cn.ConnectionString = StrSql;
                cn.Open();
                sw = true;
            }
            catch (Exception ex)
            {
                sw = false;
                MessageBox.Show(ex.Message);
            }
            return sw;
        }
        public void Desconectar()
        {
            try
            {
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public SqlConnection ObtConexion()
        {
            return cn;
        }
    }
}
