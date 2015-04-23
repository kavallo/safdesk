using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    class ValidarDatos
    {

        
        public void num(KeyPressEventArgs e, int longitud, String text, ErrorProvider error, Control d)
        {
            String dato = text;
            int c = dato.Length;
            
            if (c < longitud || char.IsControl(e.KeyChar))
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                    error.SetError(d, "solo numero");

                }

                else if (char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                    error.Clear();
                }
            }
            else {
                e.Handled = true;
                Console.WriteLine("demasiado largo");
                error.SetError(d, "demasiado largo");
                MessageBox.Show("demasiado largo");
            }

        }
        public void CargarTexto(TextBox text)
        {
            text.KeyPress += text_KeyPress;

        }

        void text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                MessageBox.Show("haz presionado enter");
            }
        }

        public void SoloNumeros(TextBox text)
        { 
            text.KeyPress += numero;
        }

        private void numero(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                

            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else {
                e.Handled = true;
            }
        }
    }
}
