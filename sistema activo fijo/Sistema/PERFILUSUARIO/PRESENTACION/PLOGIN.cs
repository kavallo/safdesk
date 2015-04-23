using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sistema.PERFILUSUARIO.NEGOCIO;
using Sistema.PERFILUSUARIO.DATOS;

namespace Sistema.PERFILUSUARIO.PRESENTACION
{
    public partial class PLOGIN : Form
    {
        string CADENA = "Data Source=acer-pc;Initial Catalog=pruebaadmin;Integrated Security=True";
        private Empresa empresa = new Empresa();
        private Serializacion ser = new Serializacion();
        private NLOGIN nlogin;
        public string nombre { set; get; }
        public string pass { set; get; }
        public int codigogrupo { set; get; }

        

        public PLOGIN()
        {
            InitializeComponent();
            
        }

   

        public PLOGIN(string nom, string pa) {
            this.nombre = nom;
            this.pass = pa;
        }

        

        private void PLOGIN_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        public int getcod(string nombre, string pass)
        {
            nlogin = new NLOGIN(CADENA);
            return nlogin.Get_Codigo_Grupo(nombre, pass);
        }


        //private OtorgarPrivilegio ot;

        private void button1_Click(object sender, EventArgs e)
        {
            nlogin = new NLOGIN(CADENA);
            
            
            if (nlogin.Verificar_Usuario(textBox1.Text, textBox2.Text) > 0)
            {
                //ot = new OtorgarPrivilegio(textBox1.Text, textBox2.Text);




                codigogrupo = nlogin.Get_Codigo_Grupo(textBox1.Text, textBox2.Text);
                this.Hide();

                MessageBox.Show("existe usuario");

                PASIGNACIONPRIVILEGIO p = new PASIGNACIONPRIVILEGIO();

                
                
                p.ShowDialog();

                //this.Dispose();

                //this.Dispose();


            }
            else
            {
                MessageBox.Show("error usuario");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nlogin = new NLOGIN(CADENA);
            MessageBox.Show(nlogin.Get_Codigo_Grupo(textBox1.Text, textBox2.Text).ToString());
        }
    }
}
