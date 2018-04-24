using MyCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.MyGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedListX2<int> list = new MyLinkedListX2<int>();
            list.Add(9);
            list.Add(8);
            list.Add(7);
            list.Add(4);
            list.Add(3);
            list.Add(2);
            list.Add(1);
            list.Insert(3, 6);
            list.Insert(4, 5);

            list.Remove(3);
            list.Remove(1);
            list.Remove(9);

            Console.WriteLine(list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
