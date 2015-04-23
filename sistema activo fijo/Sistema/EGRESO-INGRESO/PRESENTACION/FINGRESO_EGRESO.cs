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
using Sistema.EGRESO_INGRESO.NEGOCIO;
using Sistema.PERFILUSUARIO.DATOS;

namespace Sistema.EGRESO_INGRESO.PRESENTACION
{
    public partial class FINGRESO_EGRESO : Form
    {

        private NEGRESO_INGRESO ing;

        public int codigo;

        private Empresa empresa = new Empresa();
        private Serializacion ser = new Serializacion();
        private NDetalleBitacora ndb;

        string CADENA = VariableGlobales.CADENA;
        public FINGRESO_EGRESO()
        {
            InitializeComponent();

            empresa = ser.deserializar("config.txt");

            FrmPrincipal frm = new FrmPrincipal();
            //FrmPrincipal frm = new FrmPrincipal();

            //ndb = new NDetalleBitacora(empresa.String_Connection);
            ndb = new NDetalleBitacora(CADENA);
        }

        private Button[] but;

        private void cargarbotones()
        {
            but = new Button[4];
            but[0] = button1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                
                string tipo = maskedTextBox4.Text;
                
                dataGridView1.DataSource = ing.MostrarIngreso();


            }
            catch (Exception)
            {


            }
        }

        private void FINGRESO_EGRESO_Load(object sender, EventArgs e)
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



            //cliente = new NCLIENTE(CADENA);
            depa = new NDEPARTAMENTO(empresa.String_Connection);
            dataGridView1.DataSource = depa.MostrarDepartamento();

            cargarbotones();
            //OtorgarPrivilegio ot = new OtorgarPrivilegio(CADENA);
            OtorgarPrivilegio ot = new OtorgarPrivilegio(empresa.String_Connection);
            //ot.OtorgarPrivilegio2("Cliente", but, codigo);
        }
    }
}
