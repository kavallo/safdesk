using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.BIEN.DATOS;

namespace Sistema.BIEN.NEGOCIO
{
    class NBIEN
    {
        
        private DBIEN bien;
        public NBIEN(string value)
        {
            bien = new DBIEN(value);
        }
        public void Insertar_Bien
            (string nombre, float preciocompra, int idingreso, int idtipobien)
        {            
            bien.nombre = nombre;
            bien.preciocompra = preciocompra;
            bien.idingresoegreso = idingreso;
            bien.idtipobien = idtipobien;
            bien.InsertarBien();
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
        public DataTable MostrarBien()
        {
            return bien.MostrarBien();
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
