using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Perfil_de_Seguridad.Presentacion;
using Sistema.Perfil_de_Seguridad.Negocio;
using Sistema.PERFILUSUARIO.NEGOCIO;
using Sistema.PERSONA.PERSONAL.NEGOCIO;

namespace Sistema
{
    public partial class FrmEmpresa : Form
    {
        public FrmEmpresa()
        {
            InitializeComponent();
        }



        public void insertarUsuario()
        {
            try
            {
                Utilidad3 u = new Utilidad3(textBoxNombre.Text);
                NPERSONAL personal = new NPERSONAL(u.stringConecction());             
                NGRUPO ngrupo = new NGRUPO(u.stringConecction());
                NUSUARIO usu = new NUSUARIO(u.stringConecction());
                ngrupo.Insertar_Grupo("Administrador");
                
                //insertar grupos de privilegios   lo comente pero parece que no fue nada
                //ngrupo.Cargar_GrupoPriv();

                personal.Insertar_Grupo(int.Parse(textBoxCI.Text), textBoxNombres.Text + " " + textBoxApellidos.Text, textBoxDireccion.Text, 1, 1);

                usu.Agregarusuario(1, "habilitado", 1, textBoxNick.Text, textBoxPass.Text);
  
                MessageBox.Show("se inserto usuario");
            }
            catch (Exception ex)
            {
                MessageBox.Show("no se inserto usuario");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog BuscarImagen = new OpenFileDialog();
            BuscarImagen.Filter = "Archivos de Imagen|*.jpg";
            //Aquí incluiremos los filtros que queramos.
            BuscarImagen.FileName = "";
            BuscarImagen.Title = "Titulo del Dialogo";
            BuscarImagen.InitialDirectory = "C:\\";

            if (BuscarImagen.ShowDialog() == DialogResult.OK)
            {
                String Direccion = BuscarImagen.FileName;
                this.pictureBox1.ImageLocation = Direccion;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Utilidad3 u = new Utilidad3(textBoxNombre.Text);
            ImageUtil img = new ImageUtil();
            Serializacion ser = new Serializacion();
            u.createDB();
            u.crearTables();
            u.insDatos();
            u.insPA();
            //u.addPA();
            insertarUsuario();
            Empresa empresa = new Empresa();
            empresa.nombreEmpresa = textBoxNombre.Text;
            empresa.celular = Convert.ToInt32(textBoxCelular.Text);
            empresa.telefono = Convert.ToInt32(textBoxTelefono.Text);
            empresa.email = textBoxEmail.Text;
            empresa.direccion = textBoxDireccion.Text;
            Image i = Image.FromFile(pictureBox1.ImageLocation);
            empresa.logo = img.toArrayByte(i);
            empresa.username = textBoxNick.Text;
            empresa.password = textBoxPass.Text;
            empresa.String_Connection = u.stringConecction();
            ser.serializar(empresa);
            this.Hide();
            new FrmLogin().ShowDialog();
            this.Close();
        }
    }
}
