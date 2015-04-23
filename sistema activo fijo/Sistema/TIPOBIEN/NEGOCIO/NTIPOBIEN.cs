using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.TIPOBIEN.DATOS;

namespace Sistema.TIPOBIEN.NEGOCIO
{
    class NTIPOBIEN
    {
        
        private DTIPOBIEN tipobien;
        public NTIPOBIEN(string value)
        {
            tipobien = new DTIPOBIEN(value);
        }
        public void Insertar_Tipobien
            (string descripcion, int idcategoria)
        {            
            tipobien.descripcion = descripcion;
            tipobien.idcategoria = idcategoria;
            tipobien.InsertarTipobien();
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
        public DataTable MostrarTipobien()
        {
            return tipobien.MostrarTipobien();
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
