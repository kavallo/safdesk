using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Sistema
{
    class Serializacion
    {
        public void serializar(Empresa empresa)
        {
            String dir = Path.GetFullPath("Config");
            FileStream fs = new FileStream(dir + "\\config.txt", FileMode.Create);
            BinaryFormatter format = new BinaryFormatter();
            format.Serialize(fs, empresa);
            fs.Flush();
            fs.Close();
        }
        public Empresa deserializar(String file)
        {
            FileStream fs = null;
            try
            {

                String dir = Path.GetFullPath("Config");
                fs = new FileStream(dir + "\\" + file, FileMode.Open);
            }
            catch (Exception)
            {
                return null;
            }
            BinaryFormatter format = new BinaryFormatter();
            Empresa empresa = format.Deserialize(fs) as Empresa;
            fs.Flush();
            fs.Close();
            return empresa;
        }
    }
}
