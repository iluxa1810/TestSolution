using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
          var asm=  Assembly.LoadFile(@"D:\Projects\TestSolution\ClassLibrary1\bin\Debug\netcoreapp3.0\ClassLibrary1.dll");
            var types = asm.GetTypes();
        }
    }
}
