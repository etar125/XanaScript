using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xanascr
{
    class Globl
    {
        public static string Convert(string text)
        {
            for (int ii = 0; ii < text.Length; ii++)
            {
                if (text[ii] == '%')
                {
                    for (int j = ii + 1; j < text.Length; j++)
                    {
                        if (text[j] == '%')
                        {
                            int startIndex = ii;
                            int endIndex = j;
                            int length = endIndex - startIndex;
                            string var = text.Substring(startIndex + 1, length - 1);
                            text = text.Remove(startIndex, length + 1);
                            if (Program.vars.ContainsKey(var))
                            {
                                text = text.Insert(startIndex, Program.vars[var]);
                            }
                            ii = j;
                            break;
                        }
                    }
                }
            }
            return text;
        }
    }
}
