using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.PERFILUSUARIO.DATOS
{
    class GuardarPrivilegios
    {

        public int grupoID { set; get; }
        public string nombre { set; get; }

        private string connectionString;
        private SqlCommand cmd;
        public GuardarPrivilegios(string value)
        {
            connectionString = value;
        }

        public string getcodgrupo()
        {
            CONEXIONUTIL con;
            Empresa empresa = new Empresa();
            Serializacion ser = new Serializacion();
            empresa = ser.deserializar("config.txt");
            con = new CONEXIONUTIL(empresa.String_Connection);
            //empresa = ser.deserializar("config.txt");
            //con = new CONEXIONUTIL(empresa.String_Connection);
            int n = 0;
            string d = null;
            DataTable da = con.ejecutarconsulta("select max(GRUPO.CODGRUPO) + 1 from GRUPO");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                d = da.Rows[i].ItemArray[0].ToString();
            }
            return d;
        }

        public void RegistrarGrupoPrivilegio(int codgrupo, int codpriv)
        {
            CONEXIONUTIL con;
            Empresa empresa = new Empresa();
            Serializacion ser = new Serializacion();
            empresa = ser.deserializar("config.txt");
            con = new CONEXIONUTIL(empresa.String_Connection);
            //empresa = ser.deserializar("config.txt");
            //con = new CONEXIONUTIL(empresa.String_Connection);
            DataTable da = con.ejecutarconsulta("insert into grupodeprivilegio values " + "(" + codgrupo + "," + "'" + codpriv + "'" + ")");

        }

        public void RegistrarPaquete(string paquete)
        {
            CONEXIONUTIL con;
            Empresa empresa = new Empresa();
            Serializacion ser = new Serializacion();
            empresa = ser.deserializar("config.txt");
            con = new CONEXIONUTIL(empresa.String_Connection);
            //empresa = ser.deserializar("config.txt");
            //con = new CONEXIONUTIL(empresa.String_Connection);
            DataTable da = con.ejecutarconsulta("insert into PAQUETE values " + "(" + "'" + paquete + "'" + ")");

        }

        public void RegistrarCasoDeUso(int codpaquete, string casouso)
        {
            CONEXIONUTIL con;
            Empresa empresa = new Empresa();
            Serializacion ser = new Serializacion();
            empresa = ser.deserializar("config.txt");
            con = new CONEXIONUTIL(empresa.String_Connection);
            //empresa = ser.deserializar("config.txt");
            //con = new CONEXIONUTIL(empresa.String_Connection);
            DataTable da = con.ejecutarconsulta("insert into CASOSDEUSO values " + "(" + codpaquete + "," + "'" + casouso + "'" + ")");

        }

        public void RegistrarPrivilegio(int codcaso, string privilegio)
        {
            CONEXIONUTIL con;
            Empresa empresa = new Empresa();
            Serializacion ser = new Serializacion();
            empresa = ser.deserializar("config.txt");
            con = new CONEXIONUTIL(empresa.String_Connection);
            //empresa = ser.deserializar("config.txt");
            //con = new CONEXIONUTIL(empresa.String_Connection);
            DataTable da = con.ejecutarconsulta("insert into PRIVILEGIOS values " + "(" + codcaso + "," + "'" + privilegio + "'" + ")");

        }

        public int getcodigopa(string paquete)
        {
            CONEXIONUTIL con;
            Empresa empresa = new Empresa();
            Serializacion ser = new Serializacion();
            empresa = ser.deserializar("config.txt");
            con = new CONEXIONUTIL(empresa.String_Connection);
            //empresa = ser.deserializar("config.txt");
            //con = new CONEXIONUTIL(empresa.String_Connection);
            int n = 0;
            string d = null;
            DataTable da = con.ejecutarconsulta("select PAQUETE.CODPAQUETE from PAQUETE where PAQUETE.DESCRIPCIONPAQUETE =  " + "'" + paquete + "'");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                d = da.Rows[i].ItemArray[0].ToString();
            }
            n = Convert.ToInt32(d);
            return n;
        }



        public int getcodigocu(string caso)
        {
            CONEXIONUTIL con;
            Empresa empresa = new Empresa();
            Serializacion ser = new Serializacion();
            empresa = ser.deserializar("config.txt");
            con = new CONEXIONUTIL(empresa.String_Connection);
            //empresa = ser.deserializar("config.txt");
            //con = new CONEXIONUTIL(empresa.String_Connection);
            int n = 0;
            string d = null;
            DataTable da = con.ejecutarconsulta("select CASOSDEUSO.CODIGOCASODEUSO from CASOSDEUSO where casosdeuso.descripcion = " + "'" + caso + "'");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                d = da.Rows[i].ItemArray[0].ToString();
            }
            n = Convert.ToInt32(d);
            return n;
        }

        public int getcodigopriv(string priv)
        {
            CONEXIONUTIL con;
            Empresa empresa = new Empresa();
            Serializacion ser = new Serializacion();
            empresa = ser.deserializar("config.txt");
            con = new CONEXIONUTIL(empresa.String_Connection);
            //empresa = ser.deserializar("config.txt");
            //con = new CONEXIONUTIL(empresa.String_Connection);
            int n = 0;
            string d = null;
            DataTable da = con.ejecutarconsulta("select codprivilegio from privilegios where descripcion = " + "'" + priv + "'");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                d = da.Rows[i].ItemArray[0].ToString();
            }
            n = Convert.ToInt32(d);
            return n;
        }

        //para guardar el treeview


        public void GuardarTree2(TreeView treev) { 
            TreeNode caso, privilegio;
            int codcasodeuso, codpaquete;
            TreeNode paquete = treev.Nodes[0];

                for (int i = 0; i < paquete.Nodes.Count; i++)
                {
                    //MessageBox.Show(paquete.Nodes[i].Text);
                    //aqui va registrar paquete
                    RegistrarPaquete(paquete.Nodes[i].Text);
                    caso = paquete.Nodes[i];
                    codpaquete = getcodigopa(paquete.Nodes[i].Text);
                    //MessageBox.Show(Convert.ToString(caso.Nodes.Count));//contador de cuantos casos tiene un paquete
                        for (int j = 0; j < caso.Nodes.Count; j++)
                        {
                            
                            //MessageBox.Show(caso.Nodes[j].Text);
                            
                            RegistrarCasoDeUso(codpaquete, caso.Nodes[j].Text);
                            privilegio = caso.Nodes[j];
                            //MessageBox.Show(Convert.ToString(caso.Nodes.Count));
                            codcasodeuso = getcodigocu(caso.Nodes[j].Text);
                            for (int k = 0; k < privilegio.Nodes.Count; k++)
                            {

                                RegistrarPrivilegio(codcasodeuso, privilegio.Nodes[k].Text);

                                //para que registre como administrador
                                //int codgrupo = int.Parse(getcodgrupo());
                                int codpriv = getcodigopriv(privilegio.Nodes[k].Text);
                                //como va ser la primera vez se puede poner 1
                                RegistrarGrupoPrivilegio(1, codpriv);
                                
                                //MessageBox.Show(privilegio.Nodes[k].Text);
                                
                                //MessageBox.Show(Convert.ToString("cantidad de priv: "+privilegio.Nodes.Count));
                            }
                            
                            

                        }
                    }
                }

        public void GuardarTree(TreeView treev) { 
            TreeNode caso, privilegio;
            int codcasodeuso, codpaquete;
            foreach (TreeNode paquete in treev.Nodes)
            {
                for (int i = 0; i < paquete.Nodes.Count; i++)
                {
                    MessageBox.Show(paquete.Nodes[i].Text);
                    //aqui va registrar paquete
                    RegistrarPaquete(paquete.Nodes[i].Text);
                    caso = paquete.Nodes[i];
                    codpaquete = getcodigopa(paquete.Nodes[i].Text);
                    //MessageBox.Show(Convert.ToString(caso.Nodes.Count));//contador de cuantos casos tiene un paquete
                        for (int j = 0; j < caso.Nodes.Count; j++)
                        {
                            
                            MessageBox.Show(caso.Nodes[j].Text);
                            
                            RegistrarCasoDeUso(codpaquete, caso.Nodes[j].Text);
                            privilegio = caso.Nodes[j];
                            //MessageBox.Show(Convert.ToString(caso.Nodes.Count));
                            codcasodeuso = getcodigocu(caso.Nodes[j].Text);
                            for (int k = 0; k < privilegio.Nodes.Count; k++)
                            {

                                RegistrarPrivilegio(codcasodeuso, privilegio.Nodes[k].Text);                              
                                
                                MessageBox.Show(privilegio.Nodes[k].Text);
                                
                                //MessageBox.Show(Convert.ToString("cantidad de priv: "+privilegio.Nodes.Count));
                            }
                            
                            

                        }
                    }
                }



                //cargartree(treeView1.Nodes[0]);
            }
    }
}
