using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.DEPARTAMENTO.DATOS;

namespace Sistema.DEPARTAMENTO.NEGOCIO
{
    class NDEPARTAMENTO
    {
        
        private DDEPARTAMENTO depa;
        public NDEPARTAMENTO(string value)
        {
            depa = new DDEPARTAMENTO(value);
        }
        public void Insertar_Departamento
            (string descripcion, string nombre)
        {            
            depa.descripcion = descripcion;
            depa.nombre = nombre;
            depa.InsertarDepartamento();
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
        public DataTable MostrarDepartamento()
        {
            return depa.MostrarDepartamento();
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
