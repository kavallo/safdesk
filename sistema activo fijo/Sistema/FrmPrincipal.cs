using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Configuracion.Negocio;
using Sistema;
using System.IO;
using System.Data.SqlClient;


using Sistema.PERFILUSUARIO.PRESENTACION;

using System.Diagnostics;
using Sistema.Bitacora.NEGOCIO;
using Sistema.Perfil_de_Seguridad.Presentacion;
using Sistema.Bitacora.PRESENTACION;
using Sistema.PERSONA.PERSONAL.PRESENTACION;
using Sistema.TIPOBIEN.PRESENTACION;
using Sistema.CATEGORIA.PRESENTACION;
using Sistema.CARGO.PRESENTACION;
using Sistema.DEPARTAMENTO.PRESENTACION;

//using System.Security.Permissions;
//using Sistema.Backup_and_Restore.Negocio;

namespace Sistema
{
    public partial class FrmPrincipal : Form
    {
        private Empresa empresa = new Empresa();
        private Serializacion ser = new Serializacion();
        private ImageUtil img = new ImageUtil();
        private FrmLogin flogin;

        public FrmPrincipal()
        {
            InitializeComponent();
            empresa = ser.deserializar("config.txt");
        }

        private void colorDelFormularioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
                string s, m;
                int n;
                s = colorDialog1.Color.ToString();
                s = s.Substring((s.IndexOf("[")) + 1);
                n = s.Length;
                s = s.Remove(n - 1);
                m = "=";
                if (s.Contains(m) == false)
                {
                    int p, q;
                    string col;
                    p = s.IndexOf("[");
                    q = s.IndexOf("]");
                    col = s.Substring(0);
                    col.Remove(col.Length - 1);
                    GestorBackcolor Backc = new GestorBackcolor(empresa.String_Connection);
                    Backc.AgregarBackcolor("FrmPrincipal", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                //    Backc.AgregarBackcolor("FrmGrupo", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                //    Backc.AgregarBackcolor("Frm_GestionarBateria", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                //    Backc.AgregarBackcolor("Frm_GestionarVehiculo", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                //    Backc.AgregarBackcolor("Frm_GestionarCliente", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                //    Backc.AgregarBackcolor("Frm_AdministrarRepuesto", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                //    Backc.AgregarBackcolor("Frm_GestionarInventario", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                //    Backc.AgregarBackcolor("Frm_GestionarVenta", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                //    Backc.AgregarBackcolor("Frm_ListarProducto", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                //    Backc.AgregarBackcolor("Frm_empleados", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                //    Backc.AgregarBackcolor("Frm_gestionarReserva", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                //    Backc.AgregarBackcolor("Frm_ServicioAuxlio", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                //    Backc.AgregarBackcolor("Frm_ServicioMantenimiento", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                //    Backc.AgregarBackcolor("Frm_ServicioReparacion", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                //    Backc.AgregarBackcolor("Frm_ServicioCliente", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                //    Backc.AgregarBackcolor("Frm_Servicios", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                //    Backc.AgregarBackcolor("Frm_AdministrarPersonal", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                }
                else
                {
                    int i, f;
                    string a, r, g, b;
                    i = s.IndexOf("=");
                    f = s.IndexOf(",");
                    a = s.Substring(i + 1, f - i - 1);
                    s = s.Remove(0, f + 2);

                    i = s.IndexOf("=");
                    f = s.IndexOf(",");
                    r = s.Substring(i + 1, f - i - 1);
                    s = s.Remove(0, f + 2);

                    i = s.IndexOf("=");
                    f = s.IndexOf(",");
                    g = s.Substring(i + 1, f - i - 1);
                    s = s.Remove(0, f + 2);

                    i = s.IndexOf("=");
                    b = s.Substring(i + 1);
                    s = s.Remove(0);

                    GestorBackcolor Backc = new GestorBackcolor(empresa.String_Connection);
                    Backc.AgregarBackcolor("FrmPrincipal", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    //Backc.AgregarBackcolor("FrmGrupo", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    //Backc.AgregarBackcolor("Frm_GestionarBateria", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    //Backc.AgregarBackcolor("Frm_GestionarCliente", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    //Backc.AgregarBackcolor("Frm_GestionarVehiculo", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    //Backc.AgregarBackcolor("Frm_AdministrarRepuestos", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    //Backc.AgregarBackcolor("Frm_GestionarInventario", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    //Backc.AgregarBackcolor("Frm_empleados", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    //Backc.AgregarBackcolor("Frm_GestionarReserva", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    //Backc.AgregarBackcolor("Frm_GestionarServicioAuxilio", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    //Backc.AgregarBackcolor("Frm_GestionarServicioCliente", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    //Backc.AgregarBackcolor("Frm_GestionarServicioMantenimiento", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    //Backc.AgregarBackcolor("Frm_GestionarServicioReparacion", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    //Backc.AgregarBackcolor("Frm_Servicios", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    //Backc.AgregarBackcolor("Frm_GestionarVenta", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    //Backc.AgregarBackcolor("Frm_ListarProducto", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    //Backc.AgregarBackcolor("Frm_AdministrarPersonal", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                }

            }
            CenterToScreen();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            
            this.Text = "Sistema " + empresa.nombreEmpresa;
            pictureBox1.Image = img.toImage(empresa.logo);

            labelNombreEmpresa.Text = labelNombreEmpresa.Text  + " " + empresa.nombreEmpresa;
            labelCelular.Text = labelCelular.Text  + " " + Convert.ToString(empresa.celular);
            labelTelefono.Text = labelTelefono.Text  + " " + Convert.ToString(empresa.telefono);
            labelDireccion.Text = labelDireccion.Text  + " " + empresa.direccion;
            labelEmail.Text = labelEmail.Text  + " " + empresa.email;

            
            DataTable dt = new DataTable();
            DataGrid grid = new DataGrid();
            DataRow dr = dt.NewRow();
            string colorcito;
            int a, r, g, b;
            GestorBackcolor Backc = new GestorBackcolor(empresa.String_Connection);
            grid.DataSource = Backc.BuscarBackcolor(Convert.ToInt32(IDUsuarioTxt.Text), "FrmPrincipal");
            dt = Backc.BuscarBackcolor(Convert.ToInt32(IDUsuarioTxt.Text), "FrmPrincipal");
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
            grid.DataSource = Forec.BuscarForecolor(Convert.ToInt32(IDUsuarioTxt.Text), "FrmPrincipal");
            dt = Forec.BuscarForecolor(Convert.ToInt32(IDUsuarioTxt.Text), "FrmPrincipal");
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
            grid.DataSource = Fuente.BuscarFuente(Convert.ToInt32(IDUsuarioTxt.Text), "FrmPrincipal");
            dt = Fuente.BuscarFuente(Convert.ToInt32(IDUsuarioTxt.Text), "FrmPrincipal");
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
        }

        private void colorDeTextoDelFormularioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.ForeColor = colorDialog1.Color;
                string s;
                int n;
                s = colorDialog1.Color.ToString();
                s = s.Substring((s.IndexOf("[")) + 1);
                n = s.Length;
                s = s.Remove(n - 1);
                string m;
                m = "=";
                if (s.Contains(m) == false)
                {
                    int p, q;
                    string col;
                    p = s.IndexOf("[");
                    q = s.IndexOf("]");
                    col = s.Substring(0);
                    col.Remove(col.Length - 1);
                    GestorForecolor Forec = new GestorForecolor(empresa.String_Connection);
                    Forec.AgregarForecolor("FrmPrincipal", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                    Forec.AgregarForecolor("FrmGrupo", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                    Forec.AgregarForecolor("Frm_GestionarBateria", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                    Forec.AgregarForecolor("Frm_GestionarVehiculo", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                    Forec.AgregarForecolor("Frm_GestionarCliente", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                    Forec.AgregarForecolor("Frm_AdministrarRepuesto", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                    Forec.AgregarForecolor("Frm_GestionarInventario", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                    Forec.AgregarForecolor("Frm_GestionarVenta", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                    Forec.AgregarForecolor("Frm_ListarProducto", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                    Forec.AgregarForecolor("Frm_empleados", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                    Forec.AgregarForecolor("Frm_gestionarReserva", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                    Forec.AgregarForecolor("Frm_ServicioAuxlio", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                    Forec.AgregarForecolor("Frm_ServicioMantenimiento", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                    Forec.AgregarForecolor("Frm_ServicioReparacion", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                    Forec.AgregarForecolor("Frm_ServicioCliente", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                    Forec.AgregarForecolor("Frm_Servicios", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                    Forec.AgregarForecolor("Frm_AdministrarPersonal", Convert.ToInt32(IDUsuarioTxt.Text), col, "nada", "nada", "nada", "nada");
                }
                else
                {
                    int i, f;
                    string a, r, g, b;
                    i = s.IndexOf("=");
                    f = s.IndexOf(",");
                    a = s.Substring(i + 1, f - i - 1);
                    s = s.Remove(0, f + 2);

                    i = s.IndexOf("=");
                    f = s.IndexOf(",");
                    r = s.Substring(i + 1, f - i - 1);
                    s = s.Remove(0, f + 2);

                    i = s.IndexOf("=");
                    f = s.IndexOf(",");
                    g = s.Substring(i + 1, f - i - 1);
                    s = s.Remove(0, f + 2);

                    i = s.IndexOf("=");
                    b = s.Substring(i + 1);
                    s = s.Remove(0);

                    GestorForecolor Forec = new GestorForecolor(empresa.String_Connection);
                    Forec.AgregarForecolor("FrmPrincipal", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    Forec.AgregarForecolor("FrmGrupo", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    Forec.AgregarForecolor("Frm_GestionarBateria", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    Forec.AgregarForecolor("Frm_GestionarCliente", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    Forec.AgregarForecolor("Frm_GestionarVehiculo", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    Forec.AgregarForecolor("Frm_AdministrarRepuestos", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    Forec.AgregarForecolor("Frm_GestionarInventario", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    Forec.AgregarForecolor("Frm_empleados", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    Forec.AgregarForecolor("Frm_GestionarReserva", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    Forec.AgregarForecolor("Frm_GestionarServicioAuxilio", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    Forec.AgregarForecolor("Frm_GestionarServicioCliente", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    Forec.AgregarForecolor("Frm_GestionarServicioMantenimiento", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    Forec.AgregarForecolor("Frm_GestionarServicioReparacion", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    Forec.AgregarForecolor("Frm_Servicios", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    Forec.AgregarForecolor("Frm_GestionarVenta", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    Forec.AgregarForecolor("Frm_ListarProducto", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                    Forec.AgregarForecolor("Frm_AdministrarPersonal", Convert.ToInt32(IDUsuarioTxt.Text), "nada", a.ToString(), r.ToString(), g.ToString(), b.ToString());
                }
            }
            CenterToScreen();
        }

        private void fuenteDelFormularioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Font = fontDialog1.Font;
                string s;
                int n;
                s = fontDialog1.Font.ToString();
                s = s.Substring((s.IndexOf("=")) + 1);
                n = s.Length;
                s = s.Remove(n - 1);
                string name, size, units, gdicharset, gdiverticalfont, style;
                int f;
                f = s.IndexOf(",");
                name = s.Substring(0, f);
                name.Trim();
                s = s.Substring((s.IndexOf("=")) + 1);
                f = s.IndexOf(",");
                size = s.Substring(0, f);
                size.Trim();
                s = s.Substring((s.IndexOf("=")) + 1);
                f = s.IndexOf(",");
                units = s.Substring(0, f);
                units.Trim();
                s = s.Substring((s.IndexOf("=")) + 1);
                f = s.IndexOf(",");
                gdicharset = s.Substring(0, f);
                gdicharset.Trim();
                s = s.Substring((s.IndexOf("=")) + 1);
                f = s.Length;
                gdiverticalfont = s.Substring(0, f);
                gdiverticalfont.Trim();
                style = fontDialog1.Font.Style.ToString();

                GestorFuente Fuente = new GestorFuente(empresa.String_Connection);
                Fuente.Agregarfuente("FrmPrincipal", Convert.ToInt32(IDUsuarioTxt.Text), name, size, units, gdicharset, gdiverticalfont, style);
                //Fuente.Agregarfuente("FrmGrupo", Convert.ToInt32(IDUsuarioTxt.Text), name, size, units, gdicharset, gdiverticalfont, style);
                //Fuente.Agregarfuente("Frm_GestionarBateria", Convert.ToInt32(IDUsuarioTxt.Text), name, size, units, gdicharset, gdiverticalfont, style);
                //Fuente.Agregarfuente("Frm_GestionarVehiculo", Convert.ToInt32(IDUsuarioTxt.Text), name, size, units, gdicharset, gdiverticalfont, style);
                //Fuente.Agregarfuente("Frm_GestionarCliente", Convert.ToInt32(IDUsuarioTxt.Text), name, size, units, gdicharset, gdiverticalfont, style);
                //Fuente.Agregarfuente("Frm_GestionarInventario", Convert.ToInt32(IDUsuarioTxt.Text), name, size, units, gdicharset, gdiverticalfont, style);
                //Fuente.Agregarfuente("Frm_AdministrarRepuestos", Convert.ToInt32(IDUsuarioTxt.Text), name, size, units, gdicharset, gdiverticalfont, style);
                //Fuente.Agregarfuente("Frm_GestionarInventario", Convert.ToInt32(IDUsuarioTxt.Text), name, size, units, gdicharset, gdiverticalfont, style);
                //Fuente.Agregarfuente("Frm_empleados", Convert.ToInt32(IDUsuarioTxt.Text), name, size, units, gdicharset, gdiverticalfont, style);
                //Fuente.Agregarfuente("Frm_GestionarReserva", Convert.ToInt32(IDUsuarioTxt.Text), name, size, units, gdicharset, gdiverticalfont, style);
                //Fuente.Agregarfuente("Frm_GestionarAuxilio", Convert.ToInt32(IDUsuarioTxt.Text), name, size, units, gdicharset, gdiverticalfont, style);
                //Fuente.Agregarfuente("Frm_GestionarCliente", Convert.ToInt32(IDUsuarioTxt.Text), name, size, units, gdicharset, gdiverticalfont, style);
                //Fuente.Agregarfuente("Frm_GestionarMantenimiento", Convert.ToInt32(IDUsuarioTxt.Text), name, size, units, gdicharset, gdiverticalfont, style);
                //Fuente.Agregarfuente("Frm_GestionarReparacion", Convert.ToInt32(IDUsuarioTxt.Text), name, size, units, gdicharset, gdiverticalfont, style);
                //Fuente.Agregarfuente("Frm_Servicios", Convert.ToInt32(IDUsuarioTxt.Text), name, size, units, gdicharset, gdiverticalfont, style);
                //Fuente.Agregarfuente("FrmGestionarVenta", Convert.ToInt32(IDUsuarioTxt.Text), name, size, units, gdicharset, gdiverticalfont, style);
                //Fuente.Agregarfuente("Frm_ListarProducto", Convert.ToInt32(IDUsuarioTxt.Text), name, size, units, gdicharset, gdiverticalfont, style);
                //Fuente.Agregarfuente("Frm_AdministrarPersonal", Convert.ToInt32(IDUsuarioTxt.Text), name, size, units, gdicharset, gdiverticalfont, style);
            }
            CenterToScreen();
        }



        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string namebase=empresa.nombreEmpresa;

            string direc=null;

            SaveFileDialog savefile = new SaveFileDialog();
            DateTime fecha = DateTime.Now;

            savefile.Title = "backup" + fecha + ".bak";

            savefile.ShowDialog();
            direc = savefile.FileName + ".bak";
            MessageBox.Show(direc);
            //

            
            //poner el cursor de relojito mintras respalda
            Cursor.Current = Cursors.WaitCursor;

            
                //conexion a la base de datos
                SqlConnection connect;
                string con = "server=localhost;database="+namebase+";Integrated Security=True;";
                connect = new SqlConnection(con);
                connect.Open();
                //-------------------------------------------------------------------------

                //método aparte para ejecutar comandos SQL---------------
                SqlCommand command;

                //command = new SqlCommand(@"prueba database to disk ='c:\ Respaldo\resp.bak' with init,stats=10", connect);
                command = new SqlCommand(@"BACKUP  database ["+namebase+"] to disk ='"+direc+"' with FORMAT, INIT, STATS = 10", connect);

                command.ExecuteNonQuery();
                //-------------------------------------------------------------------------

                connect.Close();

                MessageBox.Show("El Respaldo de la base de datos fue realizado satisfactoriamente", "Respaldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string namebase = empresa.nombreEmpresa;
            //string direct="";

            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
                                 
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    //MessageBox.Show(openFileDialog1.FileName);
            //    direct = openFileDialog1.FileName;
            //}
            ////poner cursor de relojito
            //Cursor.Current = Cursors.WaitCursor;

            //try
            //{
            //    if (File.Exists(direct))
            //    {
            //        if (MessageBox.Show("¿Está seguro de restaurar?", "Respaldo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            //método aparte de conexion a la base de datos------------
            //            SqlConnection connect;
            //            string con = "Data Source = localhost; Initial Catalog=master ;Integrated Security = True;";
            //            //string con = "server=localhost;database=prueba;Integrated Security=True;";
            //            connect = new SqlConnection(con);
            //            connect.Open();
            //            //--------------------------------------------------------

            //            //método aparte para ejecutar comandos SQL----------------

            //            SqlCommand command;
            //            command = new SqlCommand("use " + namebase + ";", connect);
                       
            //            command.ExecuteNonQuery();
            //            MessageBox.Show(namebase);
            //            command = new SqlCommand("alter database " + namebase + " SET SINGLE_USER with rollback immediate;", connect);
            //            command.ExecuteNonQuery();


            //            command = new SqlCommand("use master;", connect);
            //            command.ExecuteNonQuery();
            //            command = new SqlCommand(@"restore database prueba from disk = '" + direct + "' with REPLACE;", connect);
            //            command.ExecuteNonQuery();

            //            command = new SqlCommand("use " + namebase + ";", connect);
            //            command.ExecuteNonQuery();
            //            command = new SqlCommand("alter database " + namebase + " SET MULTI_USER with rollback immediate;", connect);
            //            command.ExecuteNonQuery();

            //            //--------------------------------------------------------------------------
            //            connect.Close();

            //            MessageBox.Show("Se ha restaurado la base de datos", "Restauración", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //    else
            //        MessageBox.Show(@"No haz hecho ningun respaldo anteriormente (o no está en la ruta correcta)", "Restauracion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}
            //catch (Exception exp)
            //{
            //    MessageBox.Show(exp.Message);
            //}
            if (MessageBox.Show("¿Está seguro de restaurar?", "Respaldo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string abrir = "C:\\ Respaldo\\restore.exe";
                //System.ParamArrayAttribute
                Process.Start(abrir);
                //
                Application.Exit();
            }
        }



        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PGRUPO pg = new PGRUPO();
            pg.IdUsuario.Text = IDUsuarioTxt.Text;

            pg.codigo = Convert.ToInt32(txtcodigo.Text);
            pg.Show();
        }

        private void asignarPrivilegioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PASIGNACIONPRIVILEGIO priv = new PASIGNACIONPRIVILEGIO();
            priv.IdUsuario.Text = IDUsuarioTxt.Text;

            priv.codigo = Convert.ToInt32(txtcodigo.Text);
            priv.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Usuario frm = new Frm_Usuario();
            frm.IdUsuario.Text = IDUsuarioTxt.Text;

            frm.codigo = Convert.ToInt32(txtcodigo.Text);
            frm.Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NBITACORA nbit = new NBITACORA(empresa.String_Connection);
            NBITACORA nbit2 = new NBITACORA(VariableGlobales.CADENA);
            nbit.Actualizar_HoraSalida();
            flogin = new FrmLogin();
            this.Hide();
            //this.Dispose();
            flogin.ShowDialog();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmbitacora frm = new Frmbitacora();
            frm.ShowDialog();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void personalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FPERSONAL frm = new FPERSONAL();
            frm.IdUsuario.Text = IDUsuarioTxt.Text;

            frm.codigo = Convert.ToInt32(txtcodigo.Text);
            frm.Show();
        }

        private void mascotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void atencionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void servicioEsteticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void servicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void tipobienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FTIPOBIEN frm = new FTIPOBIEN();
            frm.IdUsuario.Text = IDUsuarioTxt.Text;

            frm.codigo = Convert.ToInt32(txtcodigo.Text);
            frm.Show();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FCATEGORIA frm = new FCATEGORIA();
            frm.IdUsuario.Text = IDUsuarioTxt.Text;

            frm.codigo = Convert.ToInt32(txtcodigo.Text);
            frm.Show();
        }

        private void cargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FCARGO frm = new FCARGO();
            frm.IdUsuario.Text = IDUsuarioTxt.Text;

            frm.codigo = Convert.ToInt32(txtcodigo.Text);
            frm.Show();
        }

        private void departamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDEPARTAMENTO frm = new FDEPARTAMENTO();
            frm.IdUsuario.Text = IDUsuarioTxt.Text;

            frm.codigo = Convert.ToInt32(txtcodigo.Text);
            frm.Show();
        }
    
    }
}
