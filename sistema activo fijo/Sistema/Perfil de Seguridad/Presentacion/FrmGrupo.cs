using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Perfil_de_Seguridad.Negocio;
//using TallerElectrico.Configuracion.Negocio;

namespace Sistema.Perfil_de_Seguridad.Presentacion
{
    public partial class FrmGrupo : Form
    {
        private Empresa empresa = new Empresa();
        private Serializacion ser = new Serializacion();
        private GestorGrupo grupo;

        public FrmGrupo()
        {
            InitializeComponent();
            empresa = ser.deserializar("config.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                GestorGrupo grupo = new GestorGrupo(empresa.String_Connection);
                grupo.Insertar_Grupo(Convert.ToInt32(textBox1.Text), textBox2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                grupo = new GestorGrupo(empresa.String_Connection);
                grupo.Actualizar_Grupo(Convert.ToInt32(textBox1.Text), textBox2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            grupo = new GestorGrupo(empresa.String_Connection);
            dataGridView1.DataSource = grupo.Buscar_Grupo(Convert.ToInt32(textBox1.Text));
            int i = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value + "";
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value + "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            grupo = new GestorGrupo(empresa.String_Connection);
            grupo.Eliminar_Grupo(Convert.ToInt32(textBox1.Text));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            grupo = new GestorGrupo(empresa.String_Connection);
            dataGridView1.DataSource = grupo.ListarGrupo();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            dataGridView1.DataSource = null;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
