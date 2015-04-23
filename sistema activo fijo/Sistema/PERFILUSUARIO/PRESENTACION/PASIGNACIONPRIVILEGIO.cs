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
using Sistema.Configuracion.Negocio;
using Sistema.Bitacora.NEGOCIO;

namespace Sistema.PERFILUSUARIO.PRESENTACION
{
    public partial class PASIGNACIONPRIVILEGIO : Form
    {

        private Empresa empresa = new Empresa();
        private Serializacion ser = new Serializacion();
        private NDetalleBitacora ndb;

        private CONEXIONUTIL con;
        string CADENA = VariableGlobales.CADENA;
        private NASIGNACIONPRIVILEGIO nprivilegio;

        public int codigo;

        public PASIGNACIONPRIVILEGIO(int codgrupo)
        {
            InitializeComponent();

            //nprivilegio = new NASIGNACIONPRIVILEGIO(CADENA);
            nprivilegio = new NASIGNACIONPRIVILEGIO(empresa.String_Connection);
            this.codigo = codgrupo;

        }
        public PASIGNACIONPRIVILEGIO()
        {
            InitializeComponent();

            empresa = ser.deserializar("config.txt");

            FrmPrincipal frm = new FrmPrincipal();
            //FrmPrincipal frm = new FrmPrincipal();

            ndb = new NDetalleBitacora(empresa.String_Connection);

            //nprivilegio = new NASIGNACIONPRIVILEGIO(CADENA);
            nprivilegio = new NASIGNACIONPRIVILEGIO(empresa.String_Connection);
            
        }

       
        public TreeNode GetTreePaquetepru()
        {
            DataTable TablaPa;


            TablaPa = con.ejecutarconsulta("SELECT DESCRIPCIONPAQUETE fROM PAQUETE");
            TreeNode Tree = new TreeNode("SOFTWARE");
            //MessageBox.Show("hello2");
            foreach (DataRow item in TablaPa.Rows)
            {
                //MessageBox.Show(item.ItemArray[1].ToString());
                Tree.Nodes.Add(GetTreeCasoDeUso(item.ItemArray[0].ToString()));

            }
            //MessageBox.Show("adios2");
            for (int i = 0; i < TablaPa.Rows.Count - 1; i++)
            {



                //Tree.Nodes.Add(TablaPa.Rows[i].ToString());



            }
            return Tree;
        }

        public TreeNode GetTreeCasoDeUso(string paquete)
        {
            DataTable TablaPaq2;

            //con = new CONEXIONUTIL(CADENA);
            con = new CONEXIONUTIL(empresa.String_Connection);
            TablaPaq2 = con.ejecutarconsulta("select CASOSDEUSO.DESCRIPCION from PAQUETE, CASOSDEUSO where PAQUETE.CODPAQUETE = CASOSDEUSO.CODPAQUETE and PAQUETE.DESCRIPCIONPAQUETE = " + "'" + paquete + "'");
            //TablaPaq2 = dat2("SELECT CASOSDEUSO.DESCRIPCION FROM  PAQUETE INNER JOIN CASOSDEUSO ON PAQUETE.CODPAQUETE = CASOSDEUSO.CODPAQUETE WHERE  (PAQUETE.DESCRIPCIONPAQUETE = 'ADM_PERSONA')");
            TreeNode Tree = new TreeNode(paquete);
            //MessageBox.Show("hello2");
            foreach (DataRow item2 in TablaPaq2.Rows)
            {
                //MessageBox.Show(item.ItemArray[1].ToString());

                Tree.Nodes.Add(GetTreePrivilegio(item2.ItemArray[0].ToString()));

            }
            //MessageBox.Show("adios2");
            for (int i = 0; i < TablaPaq2.Rows.Count - 1; i++)
            {



                //Tree.Nodes.Add(TablaPa.Rows[i].ToString());



            }
            return Tree;
        }

        public TreeNode GetTreePrivilegio(string casodeuso)
        {
            DataTable Tablapri;
            //con = new CONEXIONUTIL(CADENA);
            con = new CONEXIONUTIL(empresa.String_Connection);
            Tablapri = con.ejecutarconsulta("select PRIVILEGIOS.DESCRIPCION from PRIVILEGIOS, CASOSDEUSO where PRIVILEGIOS.CODIGOCASODEUSO = CASOSDEUSO.CODIGOCASODEUSO and CASOSDEUSO.DESCRIPCION = " + "'" + casodeuso + "'");

            TreeNode Tree = new TreeNode(casodeuso);
            //MessageBox.Show("hello2");

            foreach (DataRow item3 in Tablapri.Rows)
            {
                //MessageBox.Show(item.ItemArray[1].ToString());
                TreeNode treeprivilegio = new TreeNode(item3.ItemArray[0].ToString());
                Tree.Nodes.Add(treeprivilegio);


            }






            return Tree;
        }

        // the current Node in AfterSelect
        private TreeNode currentNode;

        // flag to prevent recursion
        private bool dontRecurse;

        // boolean used in testing if all child nodes are checked
        private bool isChecked;

        public void alternativo(TreeViewEventArgs e)
        {
            //
            // Se remueve el evento para evitar que se ejecute nuevamente por accion de cambio de estado 
            // en esta operacion
            //


            //treeView1.AfterCheck -= treeView1_AfterCheck;

            //
            // Se valida si el nodo marcado tiene presedente
            // en caso de tenerlo se debe evaluar los nodos al mismo nivel para determinar si todos estan marcados, 
            // si lo estan se marca tambien el nodo padre
            //
            if (e.Node.Parent != null)
            {
                bool result = true;
                foreach (TreeNode node in e.Node.Parent.Nodes)
                {
                    if (!node.Checked)
                    {
                        result = false;
                        break;
                    }
                }

                e.Node.Parent.Checked = result;

            }

            //
            // Se valida si el nodo tiene hijos
            // si los tiene se recorren y asignan el estado del nodo que se esta evaluando
            //
            if (e.Node.Nodes.Count > 0)
            {
                foreach (TreeNode node in e.Node.Nodes)
                {
                    node.Checked = e.Node.Checked;
                }
            }


            //treeView1.AfterCheck += treeView1_AfterCheck;
        }



        private void PASIGNACIONPRIVILEGIO_Load(object sender, EventArgs e)
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
            
            //con = new CONEXIONUTIL(CADENA);
            con = new CONEXIONUTIL(empresa.String_Connection);
            //treeView1.Nodes.Clear();

            //treeView1.Nodes.Add(GetTreePaquetepru());
            //treeView1.Nodes.Add(GetTreePaquetepru());
            
            treeView1.Nodes[0].Expand();

            //pruebacargarcombo pc = new pruebacargarcombo(CADENA);
            pruebacargarcombo pc = new pruebacargarcombo(empresa.String_Connection);
            pc.cargar(comboBox1, "select * from grupo", 1);
            //comboBox1.Text = "Seleccione un grupo";
            //comboBox1.SelectedItem = comboBox1.Items[0];

            //pc.mostrarcodigo("select * from usuarios");


            cargarbotones();
            //OtorgarPrivilegio ot = new OtorgarPrivilegio(CADENA);
            OtorgarPrivilegio ot = new OtorgarPrivilegio(empresa.String_Connection);
            ot.OtorgarPrivilegio2("Privilegios", but, codigo);

           
        }

        private Button[] but;

        private void cargarbotones()
        { 
            but = new Button[4];
            but[0] = button1;
            but[1] = button2;
            but[2] = button3;
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            
            nprivilegio.Registrar_Privilegio(comboBox1.Text, treeView1.Nodes[0]);

            ndb.Insertar_Detalle_Bitacora(sender.ToString().Substring(35) + " " + "AsignacionPrivilegio");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            nprivilegio.Quitar_Privilegio(Convert.ToInt32(textBox1.Text));
            ndb.Insertar_Detalle_Bitacora(sender.ToString().Substring(35) + " " + "AsignacionPrivilegio");
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox1.SelectedItem.ToString());//esto si funciona
            //textBox1.Text = Convert.ToString( comboBox1.SelectedIndex + 1); solo le suma al index 1
            DataTable datagrupo = con.ejecutarconsulta("select * from grupo where descripcion = '" + comboBox1.Text + "'");
            string codgrupo = datagrupo.Rows[0].ItemArray[0].ToString();
            textBox1.Text = codgrupo;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox1.SelectedItem.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Frm_Usuario usuario = new Frm_Usuario();
            usuario.codigo = this.codigo;
            usuario.idgrupo.Text = textBox1.Text;

            usuario.IdUsuario.Text = this.IdUsuario.Text;
            usuario.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GuardarPrivilegios g = new GuardarPrivilegios(empresa.String_Connection);
            g.GuardarTree2(treeView1);
        }
    }
}
