using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xanascr.Variables
{
    class Vars
    {
        public static void Do(string func, string args, int inex)
        {
            if(func == "set")
            {
                string val = "";
                string va = "";
                int m = 0;
                for (int a = 0; a < args.Length; a++)
                {
                    if (args[a] == ' ')
                    {
                        m = a;
                        break;
                    }
                }
                va = args.Substring(0, m);
                val = args.Substring(m + 1);
                if (Program.vars.ContainsKey(va))
                    Program.vars[va] = Globl.Convert(val);
                else
                    Program.vars.Add(va, Globl.Convert(val));
            }
            else if (func == "if")
            {
                string[] sl = Globl.SplitByFirst(args, ' ');
                string name = sl[0];
                string sec1 = sl[1];
                string[] sl2 = Globl.SplitByFirst(sec1, ' ');
                string va = sl2[0];
                string sec2 = sl2[1];
                string[] sl3 = Globl.SplitByFirst(sec2, ' ');
                string oper = sl3[0];
                string val = Globl.Convert(sl3[1]);
                if (oper == "==")
                    if (Program.vars.ContainsKey(va) && Program.vars[va] != val)
                        Program.i = Program.Search(inex, "variable->endif " + name);
                else if (oper == "!=")
                    if (Program.vars.ContainsKey(va) && Program.vars[va] == val)
                        Program.i = Program.Search(inex, "variable->endif " + name);
                else if (oper == "?=")
                    if (Program.vars.ContainsKey(va) && !Program.vars[va].Contains(val))
                        Program.i = Program.Search(inex, "variable->endif " + name);
                else if (oper == "(=")
                    if (Program.vars.ContainsKey(va) && !Program.vars[va].StartsWith(val))
                        Program.i = Program.Search(inex, "variable->endif " + name);
                else if (oper == ")=")
                    if (Program.vars.ContainsKey(va) && !Program.vars[va].EndsWith(val))
                        Program.i = Program.Search(inex, "variable->endif " + name);
            }
        }
    }
}
