using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculation
{
    //Абстрактный класс, определяющий доступные операции в нашем калькуляторе
    public abstract class MyOperation
    {
        //символ, определяющий операцию
        protected char symbol;
        //приоритет операции(чем выше, тем раньше она выполнится)
        protected int level;
        //операция
        public abstract double Operation(double x, double y);

        public char Symbol
        {
            get
            {
                return symbol;
            }
        }
        public int Level
        {
            get
            {
                return level;
            }
        }
    }
    //Сложение
    class OPlus : MyOperation
    {
        public OPlus()
        {
            level = 1;
            symbol = '+';
        }
        public override double Operation(double x, double y)
        {
            return (x + y);
        }
    }
    //Вычитание
    class OMinus : MyOperation
    {
        public OMinus()
        {
            level = 1;
            symbol = '-';
        }
        public override double Operation(double x, double y)
        {
            return (x - y);
        }
    }
    //Деление
    class ODivede : MyOperation
    {
        public ODivede()
        {
            level = 2;
            symbol = '/';
        }
        public override double Operation(double x, double y)
        {
            return (x / y);
        }
    }
    //Умножение
    class OMultyply : MyOperation
    {
        public OMultyply()
        {
            level = 2;
            symbol = '*';
        }
        public override double Operation(double x, double y)
        {
            return (x * y);
        }
    }

    //Лист доступных операций
    public class ListMyOper : List<MyOperation>
    {
        public ListMyOper()
        {
            Add(new OPlus());
            Add(new OMinus());
            Add(new ODivede());
            Add(new OMultyply());
        }

        //Узнать приоритет операции
        public int GetLevelOper(char oper)
        {
            foreach (MyOperation o in this)
            {
                if (o.Symbol.Equals(oper)) return (o.Level);
            }
            return (-1);
        }
        //Совершить операцию
        public double Operation(char oper, double x, double y)
        {
            foreach (MyOperation o in this)
            {
                if (o.Symbol.Equals(oper)) return (o.Operation(x, y));
            }
            return (0);
        }
        //Проверить доступность операции
        public bool CheckOper(char oper)
        {
            foreach (MyOperation o in this)
            {
                if (o.Symbol.Equals(oper)) return (true);
            }
            return (false);
        }

        public static void WriteAcceptOperation()
        {
            Console.Write("Доступные операции: ");
            ListMyOper p = new ListMyOper();
            foreach (MyOperation o in p)
            {
                Console.Write("{0},",o.Symbol);
            }
            Console.WriteLine();
        }
    }
}
