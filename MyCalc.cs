using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculation
{
    //класс связи чисел друг с другом
    public class MyNumber
    {
        //значение
        double value;
        //операции слева и справа('1' - операция начала и конца строки)
        char left, right;
        
        public MyNumber(double value, char left, char right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }
        public double Value
        {
            get
            {
                return value;
            }
        }
        public char Left
        {
            get
            {
                return left;
            }
        }
        public char Right
        {
            get
            {
                return right;
            }
        }        
    }

    //Лист чисел со связями
    public class ListMyNumber : List<MyNumber>
    {
        //доступные операции
        ListMyOper operation;

        public ListMyNumber()
        {
            operation = new ListMyOper();
        }

        int LevelLeft(int Index)
        {
            return operation.GetLevelOper(this[Index].Left);
        }
        int LevelRight(int Index)
        {
            return operation.GetLevelOper(this[Index].Right);
        }

        //Добавление в лист с проверкой наличия операции
        public bool AddWithCheck(double value, char left, char right)
        {
            if ((!operation.CheckOper(left)&left!='1') || (!operation.CheckOper(right)&right!='1')) return false;
            Add(new MyNumber(value, left, right));
            return true;
        }
        //Операция между текущей позицией и предыдущей со смещением
        void Operation(int IndexCurrent)
        {
            this[IndexCurrent - 1] = new MyNumber(operation.Operation(this[IndexCurrent].Left, this[IndexCurrent - 1].Value, this[IndexCurrent].Value), this[IndexCurrent-1].Left, this[IndexCurrent].Right);
            for (int i = IndexCurrent; i < Count - 1; i++)
            {
                this[i] = this[i + 1];
            }
            this.Remove(this.Last());
        }

        public void Mathematic()
        {
            while (Count > 1)
            {
                int levelleft = -1;
                for (int i = 1; i < Count; i++)
                {
                    int level = LevelLeft(i);
                    if (level < levelleft || level < LevelRight(i)) { levelleft = level; continue; }
                    levelleft = level;
                    //операция
                    Operation(i);
                }
            }
        }

        //Вывод на консоль листа
        public void Writeln()
        {
            for (int i = 0; i < Count; i++)
                Console.WriteLine("Число: {0}, левая операция: {1}, правая операция: {2}", this[i].Value, this[i].Left, this[i].Right);
        }
    }
    //статический класс вычисления
    public class MyCalc
    { 
        //операция вызова класса для вычисления        
        public static string Answer(string input)
        {
            double answer = 0;
            bool except = false;
            if (input != "") answer = MyMath(input, ref except);
            if (except) return "";
            else return answer.ToString();
        }
        //рекурсивная функция вычисления
        static double MyMath(string input, ref bool exception)
        {
            //Вычисляем сначало выражения в скобках
            int indexin;
            do
            {
                indexin = input.IndexOf('(');
                int indexout = input.IndexOf(')');
                int nextindexin = input.IndexOf('(', indexin + 1);
                while (indexout > nextindexin && nextindexin != -1)
                {
                    indexout = input.IndexOf(')', indexout + 1);
                    nextindexin = input.IndexOf('(', nextindexin + 1);
                }

                if (indexin != -1 && indexout != -1)
                {
                    //вычисляем значение в подстроке
                    string tmp = input.Substring(indexin + 1, indexout - indexin - 1);
                    double answer = MyMath(tmp, ref exception);
                    if (exception) return 0;
                    //обрезаем строку
                    tmp = "(" + tmp + ")";
                    string tmp2 = answer.ToString();
                    if (indexin != 0 && ParseClass.CheckValid(input[indexin - 1])) tmp2 = "*" + tmp2;
                    input = input.Replace(tmp, tmp2);
                }
            } while (indexin != -1);
            //
            //Разбираем строку
            ListMyNumber lnum = ParseClass.ParseList(input);
            if (lnum.Count == 0)
            {
                exception = true;
                return 0;
            }
            //Выполняем операции в зависимости от их уровня
            lnum.Mathematic();          
            return lnum[0].Value;
        }
    }
}
