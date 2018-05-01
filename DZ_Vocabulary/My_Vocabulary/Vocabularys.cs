using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace My_Vocabulary
{
    [Serializable]
    public class Vocabularys
    {
        public Dictionary<string, string> v1 = new Dictionary<string, string>();
        public Dictionary<string, string> v2 = new Dictionary<string, string>();
        public Vocabularys()
        {
            FileStream stream = new FileStream("test.bin", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            Vocabularys _vocabularys = (Vocabularys)bf.Deserialize(stream);
            stream.Close();
            this.v1 = _vocabularys.v1;
            this.v2 = _vocabularys.v2;
        }
    }
}
