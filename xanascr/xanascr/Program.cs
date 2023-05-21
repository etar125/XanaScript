using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xanascr.Consol;
using System.IO;

namespace xanascr
{
    class Program
    {
        public static Dictionary<string, string> vars = new Dictionary<string, string> { };
        public static Dictionary<string, string> temp = new Dictionary<string, string> { };

        static void Main(string[] args)
        {
            string file = "main.xs";
            foreach (string s in args)
                if (File.Exists(s) && s.EndsWith(".xs"))
                    file = s;
            if (File.Exists(file))
            {
                string[] ln = File.ReadAllLines(file);
                for(int i = 0; i < ln.Length; i++)
                {
                    string tk = ln[i];
                    try
                    {
                        int m = 0;
                        for (int a = 0; a < tk.Length; a++)
                        {
                            if (tk[a] == ' ')
                            {
                                m = a;
                                break;
                            }
                        }
                        string first = tk.Substring(0, m);
                        string ars = tk.Substring(m + 1);
                        string[] ll = first.Split(new string[] { "->" }, StringSplitOptions.None);
                        if (ll[0] == "console")
                        {
                            Base.Do(ll[1], ars);
                            //while (Globl.met != Globl.Status.Complete) { }
                        }
                        //Globl.met = Globl.Status.Work;
                    }
                    catch (Exception e) { Console.WriteLine("Line::" + i + "\nText::" + tk + "\nError::" + e.Message); Console.ReadKey(true); Environment.Exit(0); }
                }
            }
        }
    }
}
