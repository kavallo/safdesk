using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Bitacora.NEGOCIO;
using Sistema.Configuracion.Negocio;
using Sistema.PERFILUSUARIO.DATOS;
using Sistema.PERFILUSUARIO.NEGOCIO;
using Sistema.PERSONA.PERSONAL.NEGOCIO;



namespace Sistema.PERFILUSUARIO.PRESENTACION
{
    public partial class Frm_Usuario : Form
    {

        private Empresa empresa = new Empresa();
        private Serializacion ser = new Serializacion();
        private NDetalleBitacora ndb;


        private NGRUPO grupo;
        private NPERSONAL personal;
        
        string CADENA = VariableGlobales.CADENA;
        public int codigo;
        NUSUARIO usuario;

        CONEXIONUTIL con; 
        public Frm_Usuario()
        {
            InitializeComponent();

            empresa = ser.deserializar("config.txt");

            FrmPrincipal frm = new FrmPrincipal();
            //FrmPrincipal frm = new FrmPrincipal();

            ndb = new NDetalleBitacora(empresa.String_Connection);
            //ndb = new NDetalleBitacora(CADENA);

            


            //grupo = new NGRUPO(CADENA);
            //personal = new NPERSONAL(CADENA);
            //usuario = new NUSUARIO(CADENA);

            //con = new CONEXIONUTIL(CADENA);

            grupo = new NGRUPO(empresa.String_Connection);
            personal = new NPERSONAL(empresa.String_Connection);
            usuario = new NUSUARIO(empresa.String_Connection);

            con = new CONEXIONUTIL(empresa.String_Connection);
        }

        private Button[] but;

        private void cargarbotones()
        {
            but = new Button[4];
            but[0] = button1;
            but[1] = button2;
            but[2] = button3;
        }

        private void Frm_Usuario_Load(object sender, EventArgs e)
        {


            DataTable dt = new DataTable();
            DataGrid grid = new DataGrid();
            DataRow dr = dt.NewRow();
            string colorcito;
            int a, r, g, b;
            GestorBackcolor Backc = new GestorBackcolor(empresa.String_Connection);
            grid.DataSource = Backc.BuscarBackcolor(Convert.ToInt32(IdUsuario.Text), "FrmPrincipal");
            dt = Backc.BuscarBackcolor(Convert.ToInt32(IdUsuario.Text), "FrmPrincipal");
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
                colorcito = Convert.ToString(dr["backcolor"]);
                if (colorcito != "nada")
                {
                    BackColor = Color.FromName(colorcito);
                }
                else
                {
                    a = Convert.ToInt32(dr["backcolorA"]);
                    r = Convert.ToInt32(dr["backcolorR"]);
                    g = Convert.ToInt32(dr["backcolorG"]);
                    b = Convert.ToInt32(dr["backcolorB"]);
                    BackColor = Color.FromArgb(Convert.ToInt32(a), Convert.ToInt32(r), Convert.ToInt32(g), Convert.ToInt32(b));
                }
            }

            GestorForecolor Forec = new GestorForecolor(empresa.String_Connection);
            grid.DataSource = Forec.BuscarForecolor(Convert.ToInt32(IdUsuario.Text), "FrmPrincipal");
            dt = Forec.BuscarForecolor(Convert.ToInt32(IdUsuario.Text), "FrmPrincipal");
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
                colorcito = Convert.ToString(dr["forecolor"]);
                if (colorcito != "nada")
                {
                    ForeColor = Color.FromName(colorcito);
                }
                else
                {
                    a = Convert.ToInt32(dr["forecolorA"]);
                    r = Convert.ToInt32(dr["forecolorR"]);
                    g = Convert.ToInt32(dr["forecolorG"]);
                    b = Convert.ToInt32(dr["forecolorB"]);
                    ForeColor = Color.FromArgb(Convert.ToInt32(a), Convert.ToInt32(r), Convert.ToInt32(g), Convert.ToInt32(b));
                }
            }

            string nombre, tamano, unidad, gdicharset, gdiverticalfont, estilo;
            GestorFuente Fuente = new GestorFuente(empresa.String_Connection);
            grid.DataSource = Fuente.BuscarFuente(Convert.ToInt32(IdUsuario.Text), "FrmPrincipal");
            dt = Fuente.BuscarFuente(Convert.ToInt32(IdUsuario.Text), "FrmPrincipal");
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
                nombre = Convert.ToString(dr["nombre"]);
                tamano = Convert.ToString(dr["tamano"]);
                unidad = Convert.ToString(dr["unidad"]);
                gdicharset = Convert.ToString(dr["gdicharset"]);
                gdiverticalfont = Convert.ToString(dr["gdiverticalfont"]);
                estilo = Convert.ToString(dr["estilo"]);
                if ((estilo.Contains("Bold") == true) && (estilo.Contains("Regular") == false) && (estilo.Contains("Strikeout") == false) && (estilo.Contains("Underline") == false) && (estilo.Contains("Italic") == false))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Bold, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));
                }
                else if ((estilo.Contains("Bold") == false) && (estilo.Contains("Regular") == true) && (estilo.Contains("Strikeout") == false) && (estilo.Contains("Underline") == false) && (estilo.Contains("Italic") == false))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Regular, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));
                }
                else if ((estilo.Contains("Bold") == false) && (estilo.Contains("Regular") == false) && (estilo.Contains("Strikeout") == true) && (estilo.Contains("Underline") == false) && (estilo.Contains("Italic") == false))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Strikeout, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));
                }
                else if ((estilo.Contains("Bold") == false) && (estilo.Contains("Regular") == false) && (estilo.Contains("Strikeout") == false) && (estilo.Contains("Underline") == true) && (estilo.Contains("Italic") == false))
                {
                    Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Underline, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));
                }
                else if ((estilo.Contains("Bold") == false) && (estilo.Contains("Regular") == false) && (estilo.Contains("Strikeout") == false) && (estilo.Contains("Underline") == false) && (estilo.Contains("Italic") == true))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Italic, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));
                }
                else if ((estilo.Contains("Bold") == true) && (estilo.Contains("Regular") == true) && (estilo.Contains("Strikeout") == false) && (estilo.Contains("Underline") == false) && (estilo.Contains("Italic") == false))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Bold | FontStyle.Regular, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));
                }
                else if ((estilo.Contains("Bold") == true) && (estilo.Contains("Regular") == false) && (estilo.Contains("Strikeout") == true) && (estilo.Contains("Underline") == false) && (estilo.Contains("Italic") == false))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Bold | FontStyle.Strikeout, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));
                }
                else if ((estilo.Contains("Bold") == true) && (estilo.Contains("Regular") == false) && (estilo.Contains("Strikeout") == false) && (estilo.Contains("Underline") == true) && (estilo.Contains("Italic") == false))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));

                }
                else if ((estilo.Contains("Bold") == true) && (estilo.Contains("Regular") == false) && (estilo.Contains("Strikeout") == false) && (estilo.Contains("Underline") == false) && (estilo.Contains("Italic") == true))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));

                }
                else if ((estilo.Contains("Bold") == false) && (estilo.Contains("Regular") == true) && (estilo.Contains("Strikeout") == true) && (estilo.Contains("Underline") == false) && (estilo.Contains("Italic") == false))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Regular | FontStyle.Strikeout, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));

                }
                else if ((estilo.Contains("Bold") == false) && (estilo.Contains("Regular") == true) && (estilo.Contains("Strikeout") == false) && (estilo.Contains("Underline") == true) && (estilo.Contains("Italic") == false))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Regular | FontStyle.Underline, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));

                }
                else if ((estilo.Contains("Bold") == false) && (estilo.Contains("Regular") == true) && (estilo.Contains("Strikeout") == false) && (estilo.Contains("Underline") == false) && (estilo.Contains("Italic") == true))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Regular | FontStyle.Italic, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));

                }
                else if ((estilo.Contains("Bold") == false) && (estilo.Contains("Regular") == false) && (estilo.Contains("Strikeout") == true) && (estilo.Contains("Underline") == true) && (estilo.Contains("Italic") == false))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Strikeout | FontStyle.Underline, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));

                }
                else if ((estilo.Contains("Bold") == false) && (estilo.Contains("Regular") == false) && (estilo.Contains("Strikeout") == true) && (estilo.Contains("Underline") == false) && (estilo.Contains("Italic") == true))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Strikeout | FontStyle.Italic, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));

                }
                else if ((estilo.Contains("Bold") == false) && (estilo.Contains("Regular") == false) && (estilo.Contains("Strikeout") == false) && (estilo.Contains("Underline") == true) && (estilo.Contains("Italic") == true))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Underline | FontStyle.Italic, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));

                }
                else if ((estilo.Contains("Bold") == true) && (estilo.Contains("Regular") == true) && (estilo.Contains("Strikeout") == true) && (estilo.Contains("Underline") == false) && (estilo.Contains("Italic") == false))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Regular | FontStyle.Strikeout, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));

                }
                else if ((estilo.Contains("Bold") == true) && (estilo.Contains("Regular") == false) && (estilo.Contains("Strikeout") == true) && (estilo.Contains("Underline") == true) && (estilo.Contains("Italic") == false))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Bold | FontStyle.Strikeout | FontStyle.Underline, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));

                }
                else if ((estilo.Contains("Bold") == true) && (estilo.Contains("Regular") == false) && (estilo.Contains("Strikeout") == false) && (estilo.Contains("Underline") == true) && (estilo.Contains("Italic") == true))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Bold | FontStyle.Underline | FontStyle.Italic, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));

                }
                else if ((estilo.Contains("Bold") == false) && (estilo.Contains("Regular") == true) && (estilo.Contains("Strikeout") == true) && (estilo.Contains("Underline") == true) && (estilo.Contains("Italic") == false))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Regular | FontStyle.Strikeout | FontStyle.Underline, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));

                }
                else if ((estilo.Contains("Bold") == false) && (estilo.Contains("Regular") == true) && (estilo.Contains("Strikeout") == false) && (estilo.Contains("Underline") == true) && (estilo.Contains("Italic") == true))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Regular | FontStyle.Underline | FontStyle.Italic, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));

                }
                else if ((estilo.Contains("Bold") == false) && (estilo.Contains("Regular") == false) && (estilo.Contains("Strikeout") == true) && (estilo.Contains("Underline") == true) && (estilo.Contains("Italic") == true))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Strikeout | FontStyle.Underline | FontStyle.Italic, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));
                }
                else if ((estilo.Contains("Bold") == true) && (estilo.Contains("Regular") == true) && (estilo.Contains("Strikeout") == false) && (estilo.Contains("Underline") == true) && (estilo.Contains("Italic") == false))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Bold | FontStyle.Regular | FontStyle.Underline, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));

                }
                else if ((estilo.Contains("Bold") == true) && (estilo.Contains("Regular") == true) && (estilo.Contains("Strikeout") == false) && (estilo.Contains("Underline") == false) && (estilo.Contains("Italic") == true))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Bold | FontStyle.Regular | FontStyle.Italic, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));

                }
                else if ((estilo.Contains("Bold") == true) && (estilo.Contains("Regular") == false) && (estilo.Contains("Strikeout") == true) && (estilo.Contains("Underline") == false) && (estilo.Contains("Italic") == true))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Bold | FontStyle.Strikeout | FontStyle.Italic, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));

                }
                else if ((estilo.Contains("Bold") == false) && (estilo.Contains("Regular") == true) && (estilo.Contains("Strikeout") == true) && (estilo.Contains("Underline") == false) && (estilo.Contains("Italic") == true))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Regular | FontStyle.Strikeout | FontStyle.Italic, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));

                }
                else if ((estilo.Contains("Bold") == true) && (estilo.Contains("Regular") == true) && (estilo.Contains("Strikeout") == true) && (estilo.Contains("Underline") == true) && (estilo.Contains("Italic") == false))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Bold | FontStyle.Regular | FontStyle.Strikeout | FontStyle.Underline, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));

                }
                else if ((estilo.Contains("Bold") == true) && (estilo.Contains("Regular") == true) && (estilo.Contains("Strikeout") == false) && (estilo.Contains("Underline") == true) && (estilo.Contains("Italic") == true))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Bold | FontStyle.Regular | FontStyle.Underline | FontStyle.Italic, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));

                }
                else if ((estilo.Contains("Bold") == true) && (estilo.Contains("Regular") == false) && (estilo.Contains("Strikeout") == true) && (estilo.Contains("Underline") == true) && (estilo.Contains("Italic") == true))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Bold | FontStyle.Strikeout | FontStyle.Underline | FontStyle.Italic, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));

                }
                else if ((estilo.Contains("Bold") == false) && (estilo.Contains("Regular") == true) && (estilo.Contains("Strikeout") == true) && (estilo.Contains("Underline") == true) && (estilo.Contains("Italic") == true))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Regular | FontStyle.Strikeout | FontStyle.Underline | FontStyle.Italic, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));

                }
                else if ((estilo.Contains("Bold") == true) && (estilo.Contains("Regular") == true) && (estilo.Contains("Strikeout") == true) && (estilo.Contains("Underline") == true) && (estilo.Contains("Italic") == true))
                {
                    this.Font = new Font(nombre, Convert.ToSingle(tamano), FontStyle.Bold | FontStyle.Strikeout | FontStyle.Underline | FontStyle.Italic, GraphicsUnit.Pixel, Convert.ToByte(gdicharset), Convert.ToBoolean(gdiverticalfont));

                }
            }
            

            //pruebacargarcombo pc = new pruebacargarcombo(CADENA);
            pruebacargarcombo pc = new pruebacargarcombo(empresa.String_Connection);

            pc.cargar(comboBoxGrupo, "select * from grupo", 1);
            comboBoxGrupo.Text = "Seleccione un grupo";

            pc.cargar(comboBox1, "select * from personal, persona where idpersona = idpersonal", 5);
            comboBox1.Text = "Seleccione un pesonal";

            comboBoxEstado.Text = "Seleccione un estado";

            if (!idgrupo.Text.Equals(""))
            {
                comboBoxGrupo.Enabled = false;
            }

            dataGridView1.DataSource = usuario.Mostrarusuario();

            cargarbotones();
            //OtorgarPrivilegio ot = new OtorgarPrivilegio(CADENA);
            OtorgarPrivilegio ot = new OtorgarPrivilegio(empresa.String_Connection);
            ot.OtorgarPrivilegio2("Usuarios", but, codigo);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                //DataTable datagrupo = con.ejecutarconsulta("select * from grupo where descripcion = '" + comboBoxGrupo.Text + "'");
                DataTable datapersonal = con.ejecutarconsulta("select * from personal, persona where nombre = '" + comboBox1.Text + "'" + " and PERSONA.idpersona = PERSONAL.idpersonal");
                //string codgrupo = datagrupo.Rows[0].ItemArray[0].ToString();
                string idpersonal = datapersonal.Rows[0].ItemArray[0].ToString();

                usuario.Agregarusuario(Convert.ToInt32(idgrupo.Text), comboBoxEstado.Text, Convert.ToInt32(idpersonal), textBoxUsername.Text, textBoxPassword.Text);
                dataGridView1.DataSource = usuario.Mostrarusuario();


                ndb.Insertar_Detalle_Bitacora(sender.ToString().Substring(35) + " " + "Usuario");
            }
            catch (Exception)
            {

                Console.WriteLine("error");
            }
            
        }

        private void comboBoxGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataG = con.ejecutarconsulta("select * from grupo where descripcion = '" + comboBoxGrupo.Text + "'");
            string codgrupo = dataG.Rows[0].ItemArray[0].ToString();
            idgrupo.Text = codgrupo.ToString();
        }

        private void idgrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!idgrupo.Text.Equals(""))
            {
                comboBoxGrupo.Enabled = true;
            }
        }
    }
}
