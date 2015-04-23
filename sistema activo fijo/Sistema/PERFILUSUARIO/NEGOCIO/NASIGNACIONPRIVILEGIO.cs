using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Sistema.PERFILUSUARIO.DATOS;
using System.Windows.Forms;

namespace Sistema.PERFILUSUARIO.NEGOCIO
{
    class NASIGNACIONPRIVILEGIO
    {
        private DASIGNACIONPRIVILEGIO privilegio;
        private CONEXIONUTIL con;
        string CADENA = VariableGlobales.CADENA;
        public NASIGNACIONPRIVILEGIO(string value)
        {
            privilegio = new DASIGNACIONPRIVILEGIO(value);
        }

        public int getcodigo(string paquete)
        {
            con = new CONEXIONUTIL(CADENA);
            int n = 0;
            string d = null;
            DataTable da = con.ejecutarconsulta("select CASOSDEUSO.CODIGOCASODEUSO from CASOSDEUSO where casosdeuso.descripcion = " + "'" + paquete + "'");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                d = da.Rows[i].ItemArray[0].ToString();
            }
            n = Convert.ToInt32(d);
            return n;
        }

        public int getcodigoprivilegio(string paquete, int caso)
        {
            
            
            con = new CONEXIONUTIL(CADENA);
            int n = 0;
            string d = null;
            DataTable da = con.ejecutarconsulta("select PRIVILEGIOS.CODPRIVILEGIO from PRIVILEGIOS, CASOSDEUSO where PRIVILEGIOS.CODIGOCASODEUSO = CASOSDEUSO.CODIGOCASODEUSO and CASOSDEUSO.CODIGOCASODEUSO = " + caso + " and PRIVILEGIOS.DESCRIPCION =" + "'" + paquete + "'");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                d = da.Rows[i].ItemArray[0].ToString();
            }
            n = Convert.ToInt32(d);
            return n;
        }

        public void Registrar_Privilegio(String grupo, TreeNode treen)
        {
            TreeNode tree_paquete, tree_caso_uso, operacion;
            for (int i = 0; i < treen.Nodes.Count; i++)
            {
                tree_paquete = treen.Nodes[i];
                for (int j = 0; j < tree_paquete.Nodes.Count; j++)
                {
                    tree_caso_uso = tree_paquete.Nodes[j];

                    for (int k = 0; k < tree_caso_uso.Nodes.Count; k++)
                    {
                        operacion = tree_caso_uso.Nodes[k];
                        int codcasodeuso, codoperacion;
                        codcasodeuso = getcodigo(tree_paquete.Nodes[j].Text);
                        codoperacion = getcodigoprivilegio(tree_caso_uso.Nodes[k].Text, codcasodeuso);
                        if (tree_caso_uso.Nodes[k].Checked == true)
                        {
                            //registrarprivilegio(grupo, codoperacion);aca debe estar el procedimiento
                            //almacenado registrarprivilegios
                            privilegio.grupo = grupo;
                            privilegio.codigo = codoperacion;
                            privilegio.RegistrarPrivilegio();
                        }
                    }
                }
            }
        }

        public void Quitar_Privilegio(int codigo)
        {
            privilegio.codigo = codigo;
            privilegio.QuitarPrivilegio();
        }
        
    }
}
