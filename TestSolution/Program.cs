using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace TestSolution
{
    class Program
    {
        static  void Main(string[] args)
        {
            var obj = new object();
            lock(obj)
            {
                Task.Run(() => {
                    lock (obj)
                    {
                        Console.WriteLine(3);
                        //Monitor.Pulse(obj);
                        Console.WriteLine(4);
                    }
                
                });
                Console.WriteLine(1);
                Monitor.Wait(obj);
                Console.WriteLine(2);
            }
        }

       static void Test()
        {

        }
    }
}
