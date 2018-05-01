using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using My_Vocabulary;

namespace DZ_Vocabulary
{
    class Program
    {        
        static void Main(string[] args)
        {
            MyVocabulary vc = new MyVocabulary();
            vc.ReturnValue("мама");
            vc.ReturnValue("dad");
        }
    }
}
