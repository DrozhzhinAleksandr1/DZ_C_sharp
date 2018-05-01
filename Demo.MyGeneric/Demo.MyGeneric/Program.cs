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
            MyTree<int, int> tree = new MyTree<int, int>();
            tree.Add(5, 6);
            tree[5] = 24;
            Console.WriteLine($"{tree[5]} = 24");
            //Console.WriteLine($"{tree[4]} = 3");
            //Console.WriteLine($"{tree[2]} = 9");
        }
    }
}
