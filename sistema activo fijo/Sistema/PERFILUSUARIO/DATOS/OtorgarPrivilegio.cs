using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Sistema.PERFILUSUARIO.NEGOCIO;
using Sistema.PERFILUSUARIO.PRESENTACION;

namespace Sistema.PERFILUSUARIO.DATOS
{
    class OtorgarPrivilegio
    {

        
        private string cad;
        public string nombre { get; set; }
        public string pass {get; set;}
        private CONEXIONUTIL con;

        public OtorgarPrivilegio(string values)
        {
            cad = values;
        }
        public OtorgarPrivilegio(string nom, string pass)
        {
            this.nombre = nom;
            this.pass = pass;
        }

        public void OtorgarPrivilegio2(String caso, Button[] but, int codigogrupo)
        {
            con = new CONEXIONUTIL(cad);

            //plogin = new PLOGIN();

            //int codigo = plogin.codigogrupo;


            
            int ro = 0;
            for (int i = 0; i < but.Length  && but[i] != null; i++)
            {

                DataTable ta;
                ta = con.ejecutarconsulta("select COUNT(gru.CODGRUPO) from PRIVILEGIOS pri,CASOSDEUSO cu,GRUPODEPRIVILEGIO gpri, GRUPO gru "+
                "where pri.CODIGOCASODEUSO = cu.CODIGOCASODEUSO and gpri.CODPRIVILEGIO = pri.CODPRIVILEGIO and gru.CODGRUPO = gpri.CODGRUPO " +
                   " and pri.Descripcion =" + "'" + but[i].Text.ToString() + "'" + " and cu.Descripcion = " + "'" + caso + "'" + "and gpri .CodGrupo = " + codigogrupo);
                //but[i].Text.Substring(1).ToString() es para cuando haiga aspersan 
                //ta =verificarprivilegios(but[i].Name.ToString, "gestionarprivilegiogrupo", iniciarsesion.getcodgrupo);

                ro = Convert.ToInt32(ta.Rows[0].ItemArray[0].ToString());
                if (ro != 0)
                //if (Convert.ToInt64(ta.Rows[i].ItemArray[0].ToString()) != 0)
                //if ("insertar" == but[i].Text.ToString())
                {
                    but[i].Enabled = true;

                }
                else
                {
                    but[i].Enabled = false;
                }
            }

        }
    }
}
