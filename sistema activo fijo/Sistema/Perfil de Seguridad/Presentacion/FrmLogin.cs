using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Sistema.Servicios;
using Sistema.Perfil_de_Seguridad.Negocio;
using Sistema.Perfil_de_Seguridad.Datos;
//using Sistema.Configuracion.Negocio;
using Sistema;
using Sistema.PERFILUSUARIO.NEGOCIO;
using Sistema.Bitacora.NEGOCIO;

namespace Sistema.Perfil_de_Seguridad.Presentacion
{
    public partial class FrmLogin : Form
    {
        private Empresa empresa = new Empresa();
        private Serializacion ser= new Serializacion ();
        private GestorTrabajador emp;
        private NBITACORA nbit; 

        public FrmLogin()
        {
            InitializeComponent();            
            empresa = ser.deserializar("config.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                //Trabajador trabajador = new Trabajador(empresa.String_Connection);
                NUSUARIO usuario = new NUSUARIO(empresa.String_Connection);
                
                if (usuario.Existe_Usuario(textBoxNick.Text, textBoxPass.Text))
                {
                    
                    
                    
                    int IdDelUsuario;
                    //GestorBackcolor Backc = new GestorBackcolor(empresa.String_Connection);
                    //GestorForecolor Forec = new GestorForecolor(empresa.String_Connection);
                    //GestorFont Fuente = new GestorFont(empresa.String_Connection);
                    IdDelUsuario = usuario.devolverIDEmpleado_Sesion(textBoxNick.Text, textBoxPass.Text);
                    FrmPrincipal frm = new FrmPrincipal();
                    NLOGIN nlogin = new NLOGIN(empresa.String_Connection);
                    frm.txtcodigo.Text = nlogin.Get_Codigo_Grupo(textBoxNick.Text, textBoxPass.Text).ToString();
                    FrmGrupo grupo = new FrmGrupo();
                    frm.IDUsuarioTxt.Text = Convert.ToString(IdDelUsuario);

                    nbit = new NBITACORA(empresa.String_Connection);

                    nbit.Insertar_Bitacora(IdDelUsuario);

                    

                    NBITACORA nb = new NBITACORA(VariableGlobales.CADENA);
                    nb.Insertar_Bitacora(1);


                    //nb.Insertar_Bitacora(2);

                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Datos invalidos");
                }
            }
        }

        public bool validar()
        {
            if (textBoxNick.Text.Equals(""))
            {
                return false;
            }
            if (textBoxPass.Text.Equals(""))
            {
                return false;
            }
            return true;
        }

        private void textBoxNick_TextChanged(object sender, EventArgs e)
        {

        }

        }
    }
