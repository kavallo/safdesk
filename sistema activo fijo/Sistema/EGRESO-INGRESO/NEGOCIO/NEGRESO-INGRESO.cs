using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.EGRESO_INGRESO.DATOS;

namespace Sistema.EGRESO_INGRESO.NEGOCIO
{
    class NEGRESO_INGRESO
    {
        
        private DEGRESO_INGRESO ing;
        public NEGRESO_INGRESO(string value)
        {
            ing = new DEGRESO_INGRESO(value);
        }
        public void Insertar_Ingreso
            (string tipoingreso)
        {            
            ing.tipoingreso = tipoingreso;
            
            ing.InsertarIngreso();
        }

        public void Insertar_Egreso
    (string tipoegreso)
        {
            ing.tipoegreso = tipoegreso;
            
            ing.InsertarEgreso();
        }
        //public void Actualizar_Grupo(int id, string nombre)
        //{
        //    grupo.grupoID = id;
        //    grupo.nombre = nombre;
        //    grupo.ActualizarGrupo();
        //}
        //public void Eliminar_Grupo(int Id_grupo)
        //{
        //    grupo.grupoID = Id_grupo;
        //    grupo.EliminarGrupo();
        //}
        public DataTable MostrarIngreso()
        {
            return ing.MostrarIngreso();
        }
        //public DataTable Buscar_Grupo(int idGrupo)
        //{
        //    grupo.grupoID = idGrupo;
        //    return grupo.BuscarGrupo();
        //}
        //public int ObtenerGrupo(string descripcion)
        //{
        //    grupo.nombre = descripcion;
        //    return grupo.ObtenerId_Grupo();
        //}
        //public string ObtenerGrupoNombre(int Id_grupo)
        //{
        //    grupo.grupoID = Id_grupo;
        //    return grupo.ObtenerNombre_Grupo();
        //}
        //public int obtenerIDGrupo(int ci_empleado)
        //{
        //    return grupo.ObtenerID_Grupo_CIEmpleado(ci_empleado);
        //}

    }
}
