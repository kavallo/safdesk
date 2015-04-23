using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Sistema.Perfil_de_Seguridad.Datos;

namespace Sistema.Perfil_de_Seguridad.Negocio
{
    class GestorPersona
    {
        private Persona persona;

        public GestorPersona(string value)
        {
            persona = new Persona(value);
        }
        public void AgregarPersona(int ci, string nombre, string apellido, string direccion, char sexo, string tipo)
        {
            persona.personaID = ci;
            persona.nombres = nombre;
            persona.apellidos = apellido;
            persona.direccion = direccion;
            persona.sexo = sexo;
            persona.tipo = tipo;
            persona.agregar_Persona();
        }
        public void ActualizarPersona(int ci, string nombre, string apellido, string direccion, char sexo, string tipo)
        {

            persona.personaID = ci;
            persona.nombres = nombre;
            persona.apellidos = apellido;
            persona.direccion = direccion;
            persona.sexo = sexo;
            persona.tipo = tipo;
            persona.actualizar_Persona();
        }
        public void EliminarPersona(int ci)
        {
            persona.personaID = ci;
            persona.eliminar_Persona();
        }
        public DataTable MostrarPersona()
        {
            return persona.mostrar_Personas();
        }
        public DataTable BuscarPersona(int ci)
        {
            persona.personaID = ci;
            return persona.buscar_Persona();
        }
    }
}
