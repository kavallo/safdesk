using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
[Serializable]

    class Empresa
    {
        public string String_Connection { set; get; }
        public string nombreEmpresa { set; get; }
        public string username { set; get; }
        public string password { set; get; }
        public byte[] logo { set; get; }
        public string direccion { set; get; }
        public int telefono { set; get; }
        public int celular { set; get; }
        public string email { set; get; }
    }
}
