using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xanascr.Consol
{
    class Base
    {
        public static void Do(string func, string args)
        {
            if (func == "println")
                Console.WriteLine(Globl.Convert(args));
            else if (func == "print")
                Console.Write(Globl.Convert(args));
            else if (func == "title")
                Console.Title = Globl.Convert(args);
            else if (func == "getkey")
            {
                ConsoleKeyInfo k = Console.ReadKey();
                if (Program.vars.ContainsKey(args))
                    Program.vars[args] = k.Key.ToString();
                else
                    Program.vars.Add(args, k.Key.ToString());
            }
            else if (func == "getline")
            {
                string k = Console.ReadLine();
                if (Program.vars.ContainsKey(args))
                    Program.vars[args] = k;
                else
                    Program.vars.Add(args, k);
            }
            //Globl.met = Globl.Status.Complete;
        }
    }
}
