using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using System.Data;
using System.Threading.Tasks;
using Sistema.Bitacora.DATOS;

namespace Sistema.Bitacora.NEGOCIO
{
    class NDetalleBitacora
    {

                private DdetalleBitacora Ddbit;
         public NDetalleBitacora(string value)
        {
            Ddbit = new DdetalleBitacora(value);
        }
        public void Insertar_Detalle_Bitacora(String operacion)
        {
            Ddbit.operacion = operacion;
            Ddbit.InsertarDetalleBitacora();
        }

 

    }
}
