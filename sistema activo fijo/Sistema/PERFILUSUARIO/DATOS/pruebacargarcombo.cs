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
    class pruebacargarcombo
    {
        
        private CONEXIONUTIL con;
        private string pru;
        string CADENA = VariableGlobales.CADENA;

        public pruebacargarcombo(string values)
        {
            pru = values;
        }

        public void cargar(ComboBox combo, string consulta, int indice) {
            //con = new CONEXIONUTIL(CADENA);
            con = new CONEXIONUTIL(pru);
            DataTable dt = con.ejecutarconsulta(consulta);
            foreach (DataRow item in dt.Rows)
            {
                //combo.Items.Add(item[1].ToString());
                combo.Items.Add(item[indice].ToString());
            }
        }

        public int mostrarcodigo(string consulta) {
            string n = string.Empty;
            int d = 0;
            con = new CONEXIONUTIL(CADENA);
            DataTable dt = con.ejecutarconsulta(consulta);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                n = dt.Rows[i].ItemArray[3].ToString();//funciona bien aurita muestra la columa nombreusuario
                MessageBox.Show(n);
            }

            return d = Convert.ToInt32(n);
        }
    }
}
