using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Sistema.PERSONA.PERSONAL.DATOS;

namespace Sistema.PERSONA.PERSONAL.NEGOCIO
{
    class NPERSONAL
    {
        private DPERSONAL personal;
        public NPERSONAL(string value)
        {
            personal = new DPERSONAL(value);
        }
        public void Insertar_Grupo(int ci, string nombre, string direccion, int idcargo, int iddepartamento)
        {
            personal.ci = ci;
            personal.nombre = nombre;
            personal.direccion = direccion;
            personal.idcargo = idcargo;
            personal.iddepartamento = iddepartamento;
            personal.InsertarPersonal();
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
        public DataTable ListarGrupo()
        {
            return personal.MostrarGrupo();
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

