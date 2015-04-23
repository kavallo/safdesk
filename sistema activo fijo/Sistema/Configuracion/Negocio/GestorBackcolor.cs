using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Sistema.Configuracion.Datos;
using System.Threading.Tasks;

namespace Sistema.Configuracion.Negocio
{
    class GestorBackcolor
    {
        private ConfiguracionBackcolor Back;

        public GestorBackcolor(string value)
        {
            Back = new ConfiguracionBackcolor(value);
        }

        public void AgregarBackcolor(string nombreForm, int empleadoID, string backcolor, string backcolorA, string backcolorR, string backcolorG, string backcolorB)
        {
            Back.NombreFormB = nombreForm;
            Back.empleadoID = empleadoID;
            Back.Backcolor = backcolor;
            Back.BackcolorA = backcolorA;
            Back.BackcolorR = backcolorR;
            Back.BackcolorG = backcolorG;
            Back.BackcolorB = backcolorB;
            Back.agregar_Backcolor();
        }

        public DataTable MostrarBackcolors()
        {
            return Back.mostrar_Backcolors();
        }

        public DataTable BuscarBackcolor(int empleadoID, string nombreForm)
        {
            Back.empleadoID = empleadoID;
            Back.NombreFormB = nombreForm;
            return Back.buscar_Backcolor();
        }
    }
}
