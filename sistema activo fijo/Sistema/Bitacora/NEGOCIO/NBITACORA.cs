using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;
using System.Threading.Tasks;
using Sistema.Bitacora.DATOS;

namespace Sistema.Bitacora.NEGOCIO
{
    class NBITACORA
    {

        private DBITACORA Dbit;
        public NBITACORA(string value)
        {
            Dbit = new DBITACORA(value);
        }
        public void Insertar_Bitacora(int codigo)
        {
            Dbit.codigo = codigo;
            Dbit.InsertarBitacora();
        }


        public void Actualizar_HoraSalida()
        {
            Dbit.ActualizarHoraSalidaBitacora();

        }

        public int Obtener_CodUsuario(String nombre) 
        {
            Dbit.nombre = nombre;
            return Dbit.ObtenerCod_Usuario();
          
        }

        public DataTable Mostrar_bitacora()
        {
           return Dbit.MostrarBitacora();
        
        }


    }
}
