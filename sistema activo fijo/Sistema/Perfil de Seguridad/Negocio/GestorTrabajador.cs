using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Sistema.Perfil_de_Seguridad.Datos;

namespace Sistema.Perfil_de_Seguridad.Negocio
{
    class GestorTrabajador
    {
        private Trabajador trabajador;

        public GestorTrabajador(string value)
        {
            trabajador = new Trabajador(value);
        }
        public void AgregarTrabajador(int empleadoID, int grupoID, string cargo, string estado, string disponibilidad, string nick, string password)
        {
            trabajador.empleadoID = empleadoID;
            trabajador.grupoID = grupoID;
            trabajador.cargo = cargo;
            trabajador.estado = estado;
            trabajador.disponibilidad = disponibilidad;
            trabajador.nick = nick;
            trabajador.password = password;
            trabajador.agregar_Trabajador();
        }
        public void ActualizarTrabajador(int empleadoID, int grupoID, string cargo, string estado, string disponibilidad, string nick, string password)
        {
            trabajador.empleadoID = empleadoID;
            trabajador.grupoID = grupoID;
            trabajador.cargo = cargo;
            trabajador.estado = estado;
            trabajador.disponibilidad = disponibilidad;
            trabajador.nick = nick;
            trabajador.password = password;
            trabajador.actualizar_Trabajador();
        }
        public void EliminarTrabajador(int empleadoID)
        {
            trabajador.empleadoID = empleadoID;
            trabajador.eliminar_Trabajador();
        }
        public DataTable MostrarTrabajadores()
        {
            return trabajador.mostrar_Trabajadores();
        }
        public DataTable BuscarTrabajador(int empleadoID)
        {
            trabajador.empleadoID = empleadoID;
            return trabajador.buscar_Trabajador();
        }
        public DataTable BuscarTrabajadorLike(string nombre)
        {
            return trabajador.buscar_TrabajadorLike(nombre);
        }
        public string BuscarNombreTrabajador(int empleadoID)
        {
            trabajador.empleadoID = empleadoID;
            return trabajador.obtener_NombreTrabajador();
        }
        public Boolean consultar_Acceso(string nick, string password)
        {
            trabajador.nick = nick;
            trabajador.password = password;
            return trabajador.ConsultarAcceso();
        }
        public int devolverIDEmpleado_Sesion(string nick, string password)
        {
            trabajador.nick = nick;
            trabajador.password = password;
            return trabajador.DevolverID_EmpleadoSesion();
        }
        public int devolverIDEmpleado(string nombre)
        {
            return trabajador.DevolverID_Empleado(nombre);
        }
        //public void  RegistrarFinSesion(ByVal Id_sesion As String, ByVal fin As DateTime, ByVal Ci_empleado As String){ 
        //    ses.ID_Sesiones = Id_sesion;
        //    ses.FinS = fin;
        //    ses.ID_Empleados = Ci_empleado;
        //    ses.ActualizarSesion();
        //}
        public DataTable devolverNombreApellido(int id)
        {
            trabajador.empleadoID = id;
            return trabajador.devolverNombreApellido();
        }
        public int devolverIDGrupo(int id)
        {
            trabajador.empleadoID = id;
            return trabajador.DevolverID_Grupo();
        }
    }
}
