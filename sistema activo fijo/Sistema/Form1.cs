using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.PERFILUSUARIO.DATOS;

namespace Sistema
{
    public partial class Form1 : Form
    {
        ValidarDatos v = new ValidarDatos();
        private Empresa empresa = new Empresa();
        private Serializacion ser = new Serializacion();
        public Form1()
        {
            InitializeComponent();
            //this.Controls.Add(textBox1);
            tabPage1.Controls.Add(textBox1);
            textBox1.KeyPress += new KeyPressEventHandler(jf);
            
            empresa = ser.deserializar("config.txt");

            v.CargarTexto(textBox1);
            v.SoloNumeros(textBox1);
        }




        private void button1_Click(object sender, EventArgs e)
        {
            //this.Controls.Add(textBox1);
            //textBox1.KeyPress += new KeyPressEventHandler(jf);
            
        }

        private void jf(Object o, KeyPressEventArgs e)
        {
            // The keypressed method uses the KeyChar property to check 
            // whether the ENTER key is pressed. 

            // If the ENTER key is pressed, the Handled property is set to true, 
            // to indicate the event is handled.
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                MessageBox.Show("haz presionado enter : "+o.ToString());
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            //if (maskedTextBox1.Text == "mass")
            //{
            //    comboBox1.Text = "menos";
            //}
            //try
            //{
            //    int id = int.Parse(maskedTextBox1.Text);
            //}
            //catch (Exception a)
            //{
            //    Console.WriteLine(a.Message);
                
            //}
            
            
            

        }

        public void validar(MaskedTextBox m)
        {
           
 
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
          
        }

        private void maskedTextBox2_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void maskedTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {


            
            


            
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(maskedTextBox2, "inserte numero");

            }

            else if (char.IsNumber(e.KeyChar)) {
                e.Handled = false;
                errorProvider1.Clear();
            }
        
        }

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show(sender.ToString().Substring(42));
            
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(sender.ToString().Substring(42));
            v.num(e, 2, maskedTextBox1.Text, errorProvider1, maskedTextBox1);
        }
    }
}
