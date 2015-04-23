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

namespace Sistema.Bitacora.PRESENTACION
{
    public partial class Frmbitacora : Form
    {
        private NBITACORA nbt;
        private Empresa empresa;
        private Serializacion serializacion;

        public Frmbitacora()
        {
            InitializeComponent();
            empresa = new Empresa();
            serializacion = new Serializacion();
            empresa = serializacion.deserializar("config.txt");
        }

        private void Frmbitacora_Load(object sender, EventArgs e)
        {
            //nbt = new NBITACORA(empresa.String_Connection);
            nbt = new NBITACORA(VariableGlobales.CADENA);

            dataGridView1.DataSource = nbt.Mostrar_bitacora();
        }
    }
}
