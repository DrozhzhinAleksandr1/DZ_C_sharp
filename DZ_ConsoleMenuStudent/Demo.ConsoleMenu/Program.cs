using DZ_educationalProcess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Demo.ConsoleMenu
{
    class Program
    {
        static void Main(string[] args)
        {            
            MyMenu menu = new MyMenu();
            menu.Run(new object());
        }
    }
}
