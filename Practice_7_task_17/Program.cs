using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_7_task_17
{
    class Program
    {
        static int ReadInt(string msg)
        {// Ввод натурального числа с проверкой
            int number; bool ok;// переменная для проверки
            do
            {
                Console.Write(msg);
                ok = int.TryParse(Console.ReadLine(), out number);
                if ((!ok) || (number <= 0)) Console.WriteLine("Неверный ввод!");
                if ((ok) && (number <= 0)) ok = false;
            } while (!ok);// конец проверки
            return (number);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Генерация сочетаний из N элементов по K с повторениями");
            int N;
            int K;
            do
            {
                N = ReadInt("Введите число N: ");
                if (N > 36) Console.WriteLine("N не должно превышать 32");
            } while (N > 36);
            do
            {
                K = ReadInt("Введите число K: ");
                if (K > 10) Console.WriteLine("K не должно превышать 10");
            } while (K > 10);

            char[] masN = new char[N];//массив значений N
            char[] masK = new char[K];//массив значений K
            int j = (int)'A';
            for (int i=0; i<N; i++)
            {
                if (i <= 9) masN[i] = Char.Parse(i.ToString());
                else
                {
                    masN[i] = (char)j;
                    j++;
                }
            }
            for (int i=0; i<N; i++)
            {
                Console.Write(masN[i]);
            }
            Console.ReadLine();
        }
    }
}
