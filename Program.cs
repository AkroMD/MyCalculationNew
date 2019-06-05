using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculation
{
    class Program
    {
        
        static void Main(string[] args)
        {
            bool repeat = false;
            do
            {
                Console.WriteLine("Калькулятор будущего, приветствует вас!");
                ListMyOper.WriteAcceptOperation();
                Console.WriteLine("Введите мат.выражение");
                string inputText = Console.ReadLine();
                inputText = inputText.Replace(" ", "");
                Console.WriteLine(MyCalc.Answer(inputText));
                Console.WriteLine("Повторить? (Y - да, любой другой символ - нет");
                repeat = Console.ReadLine() == "Y";
            } while (repeat);
        }
    }
}
