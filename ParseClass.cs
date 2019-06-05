using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculation
{
    public class ParseClass
    {
        static char[] numberSymbols = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '9', '.', ',' };

        public static void WriteWarning()
        {
            Console.WriteLine("Неверные данные");
        }

        public static bool CheckValid(char c)
        {
            return numberSymbols.Contains(c);
        }

        public static ListMyNumber ParseList(string input)
        {
            string tmp = "";
            char leftoper = '1';
            char rightoper = '1';
            ListMyNumber lnum = new ListMyNumber();
            try
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if ((!numberSymbols.Contains(input[i]) && !(i == 0 && input[i] == '-')) || (i == input.Length - 1))
                    {
                        if (i == input.Length - 1) 
                        {                            
                            tmp += input[i];
                            rightoper = '1';
                        }
                        else rightoper = input[i];

                        tmp = tmp.Replace('.', ',');
                        if (!lnum.AddWithCheck(Convert.ToDouble(tmp), leftoper, rightoper))
                        {
                            WriteWarning();
                            lnum.Clear();
                            break;
                        }
                        tmp = "";
                        leftoper = input[i];
                    } 
                    else tmp += input[i];
                }
            }
            catch
            {
                WriteWarning();
                lnum.Clear();
            }
            return lnum;
        }
    }
}
