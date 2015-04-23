using Sistema.CATEGORIA.DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.CATEGORIA.NEGOCIO
{
    class NCATEGORIA
    {

        private DCATEGORIA categoria;
        public NCATEGORIA(string value)
        {
            categoria = new DCATEGORIA(value);
        }
        public void Insertar_Categoria
            (string descripcion)
        {            
            categoria.descripcion = descripcion;
            categoria.InsertarCategoria();
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
        public DataTable MostrarCategoria()
        {
            return categoria.MostrarCategoria();
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
