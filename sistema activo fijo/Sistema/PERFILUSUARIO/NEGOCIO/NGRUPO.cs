using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Sistema.PERFILUSUARIO.DATOS;

namespace Sistema.PERFILUSUARIO.NEGOCIO
{
    class NGRUPO
    {
        private DGRUPO grupo;
        public NGRUPO(string value)
        {
            grupo = new DGRUPO(value);
        }
        public void Insertar_Grupo(string nombre)
        {

            grupo.nombre = nombre;
            grupo.InsertarGrupo();
        }
        public void Actualizar_Grupo(int id, string nombre)
        {
            grupo.grupoID = id;
            grupo.nombre = nombre;
            grupo.ActualizarGrupo();
        }
        public void Eliminar_Grupo(int Id_grupo)
        {
            grupo.grupoID = Id_grupo;
            grupo.EliminarGrupo();
        }
        public DataTable ListarGrupo()
        {
            return grupo.MostrarGrupo();
        }
        public DataTable Buscar_Grupo(int idGrupo)
        {
            grupo.grupoID = idGrupo;
            return grupo.BuscarGrupo();
        }
        public int ObtenerGrupo(string descripcion)
        {
            grupo.nombre = descripcion;
            return grupo.ObtenerId_Grupo();
        }
        public string ObtenerGrupoNombre(int Id_grupo)
        {
            grupo.grupoID = Id_grupo;
            return grupo.ObtenerNombre_Grupo();
        }
        public int obtenerIDGrupo(int ci_empleado)
        {
            return grupo.ObtenerID_Grupo_CIEmpleado(ci_empleado);
        }
    }
}
