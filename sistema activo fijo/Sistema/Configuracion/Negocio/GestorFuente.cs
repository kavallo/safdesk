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
    class GestorFuente
    {
        private ConfiguracionFuente Font;
        public GestorFuente(string value){
            Font= new ConfiguracionFuente(value);
        }
         public void Agregarfuente(string nombreForm,int empleadoID,string fuente,string tamano,string unidad,string charset,string verticalfont, string estilo){
            Font.NombreForm = nombreForm;
            Font.empleadoID = empleadoID;
            Font.NombreFuente = fuente;
            Font.TamanoFuente = tamano;
            Font.unidadFuente = unidad;
            Font.charsetFuente = charset;
            Font.verticalfontFuente = verticalfont;
            Font.estiloFuente = estilo;
            Font.agregar_Fuente();
         }
        public DataTable MostrarFuentes(){
            return Font.mostrar_Fuentes();
        }

        public DataTable BuscarFuente(int empleadoID,string nombreForm){
            Font.empleadoID = empleadoID;
            Font.NombreForm = nombreForm;
            return Font.buscar_Fuente();
        }
    }
}
