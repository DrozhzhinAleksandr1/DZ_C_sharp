using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace My_Vocabulary
{
    public class MyVocabulary
    {
        private Vocabularys _vocabularys = new Vocabularys();
        /// <summary>
        /// save info in document
        /// </summary>
        private void SaveVocabulary()
        {
            FileStream stream = new FileStream("test.bin", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, _vocabularys);
            stream.Close();
        }
        
        /// <summary>
        /// add word to vacabulary
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void Add(string a, string b)
        {
            _vocabularys.v1.Add(a,b);
            _vocabularys.v2.Add(b,a);
            SaveVocabulary();
        }
        /// <summary>
        /// Write key and take translate
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string ReturnValue(string key)
        {
            if (_vocabularys.v1.ContainsKey(key))
            {
                Console.WriteLine(_vocabularys.v1[key]);
                return _vocabularys.v1[key];
            }
            else if (_vocabularys.v2.ContainsKey(key))
            {
                Console.WriteLine(_vocabularys.v2[key]);
                return _vocabularys.v2[key];
            }
            else
            {
                Console.WriteLine("Такого слова не в списке");
                Console.WriteLine("добавте его");
                IfEpsentAdd();
                return null;
            }
        }
        /// <summary>
        /// if word epsent, add it
        /// </summary>
        private void IfEpsentAdd()
        {
            Console.WriteLine("Введите слово");
            string a = Console.ReadLine();
            Console.WriteLine("Введите перевод");
            string b = Console.ReadLine();
            _vocabularys.v2.Add(a, b);
            _vocabularys.v2.Add(b, a);
            SaveVocabulary();
            Console.WriteLine("Слово добавлено");
        }


    }
}
