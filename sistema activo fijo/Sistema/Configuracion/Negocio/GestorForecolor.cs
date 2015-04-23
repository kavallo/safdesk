using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sistema.Configuracion.Datos;
using System.Threading.Tasks;

namespace Sistema.Configuracion.Negocio
{
    class GestorForecolor
    {
        private ConfiguracionForecolor Fore;
        public GestorForecolor(string value)
        {
            Fore = new ConfiguracionForecolor(value);
        }
        public void AgregarForecolor(string nombreForm, int empleadoID, string forecolor, string forecolorA, string forecolorR, string forecolorG, string forecolorB)
        {
            Fore.NombreForm = nombreForm;
            Fore.empleadoID = empleadoID;
            Fore.Forecolor = forecolor;
            Fore.ForecolorA = forecolorA;
            Fore.ForecolorR = forecolorR;
            Fore.ForecolorG = forecolorG;
            Fore.ForecolorB = forecolorB;
            Fore.agregar_Forecolor();
        }
        public DataTable MostrarForecolors()
        {
            return Fore.mostrar_Forecolors();
        }

        public DataTable BuscarForecolor(int empleadoID, string nombrForm)
        {
            Fore.empleadoID = empleadoID;
            Fore.NombreForm = nombrForm;
            return Fore.buscar_Forecolor();
        }
    }
}
