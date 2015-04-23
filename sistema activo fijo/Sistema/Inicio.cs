using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using Sistema;
using Sistema.Perfil_de_Seguridad.Presentacion;


namespace Sistema
{
    class Inicio
    {
        public Inicio()
        {
            Serializacion ser = new Serializacion();
            Empresa e = ser.deserializar("config.txt");
            if (e == null)
            {
                Application.Run(new FrmEmpresa());
            }
            else
            {
                Application.Run(new FrmLogin());
            }
           // Application.Run(new Form1());
                       
        }
    }
}
