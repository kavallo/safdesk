using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.PERFILUSUARIO.DATOS;

namespace Sistema.PERFILUSUARIO.NEGOCIO
{
    class NUSUARIO
    {
        private DUSUARIO usuario;

        public NUSUARIO(string value)
        {
            usuario = new DUSUARIO(value);
        }
        public void Agregarusuario(int grupoID, string estado, int personalid, string nick, string password)
        {
            
            usuario.grupoid = grupoID;
            usuario.personalid = personalid;
            usuario.estado = estado;
            
            usuario.nick = nick;
            usuario.password = password;
            usuario.agregar_usuario();
        }
        public Boolean Existe_Usuario(string nick, string pass) {
            usuario.nick = nick;
            usuario.password = pass;
            return usuario.existeUsuario(nick, pass);
        }
        public void Actualizarusuario(int usuarioid, int grupoID, string cargo, string estado, string disponibilidad, string nick, string password)
        {
            usuario.usuarioid = usuarioid;
            usuario.grupoid = grupoID;
            usuario.cargo = cargo;
            usuario.estado = estado;
            
            usuario.nick = nick;
            usuario.password = password;
            usuario.actualizar_usuario();
        }
        public void Eliminarusuario(int usuarioid)
        {
            usuario.usuarioid = usuarioid;
            usuario.eliminar_usuario();
        }
        public DataTable Mostrarusuario()
        {
            return usuario.mostrar_usuario();
        }
        public DataTable Buscarusuario(int usuarioid)
        {
            usuario.usuarioid = usuarioid;
            return usuario.buscar_usuario();
        }
        public DataTable BuscarusuarioLike(string nombre)
        {
            return usuario.buscar_usuarioLike(nombre);
        }
        public string BuscarNombreusuario(int usuarioid)
        {
            usuario.usuarioid = usuarioid;
            return usuario.obtener_Nombreusuario();
        }
        public Boolean consultar_Acceso(string nick, string password)
        {
            usuario.nick = nick;
            usuario.password = password;
            return usuario.ConsultarAcceso();
        }
        public int devolverIDEmpleado_Sesion(string nick, string password)
        {
            usuario.nick = nick;
            usuario.password = password;
            return usuario.DevolverID_EmpleadoSesion();
        }
        public int devolverIDEmpleado(string nombre)
        {
            return usuario.DevolverID_Empleado(nombre);
        }
        //public void  RegistrarFinSesion(ByVal Id_sesion As String, ByVal fin As DateTime, ByVal Ci_empleado As String){ 
        //    ses.ID_Sesiones = Id_sesion;
        //    ses.FinS = fin;
        //    ses.ID_Empleados = Ci_empleado;
        //    ses.ActualizarSesion();
        //}
        public DataTable devolverNombreApellido(int id)
        {
            usuario.usuarioid = id;
            return usuario.devolverNombreApellido();
        }
        public int devolverIDGrupo(int id)
        {
            usuario.usuarioid = id;
            return usuario.DevolverID_Grupo();
        }
    }
    
}
