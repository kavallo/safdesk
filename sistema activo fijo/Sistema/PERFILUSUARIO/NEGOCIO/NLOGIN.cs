using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Sistema.PERFILUSUARIO.DATOS;
using System.Windows.Forms;

namespace Sistema.PERFILUSUARIO.NEGOCIO
{
    class NLOGIN
    {
        private DLOGIN dlogin;
        public NLOGIN(string value)
        {
            dlogin = new DLOGIN(value);
        }

        public int Verificar_Usuario(string nombre, string pass)
        {
            dlogin.nombre = nombre;
            dlogin.password = pass;
            return dlogin.VerificarExisteUsuario();
        }

        public int Get_Codigo_Grupo(string nombre, string pass)
        {
            dlogin.nombre = nombre;
            dlogin.password = pass;
            return dlogin.GetCodGrupo();
        }

    }
}
