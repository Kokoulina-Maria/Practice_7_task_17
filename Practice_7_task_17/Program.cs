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

        static void WriteMas(char[] masK)
        {
            for (int i = 0; i < masK.Length; i++)
            {
                Console.Write(masK[i] + " ");
            }
            Console.WriteLine();
        }

        static int Index(char[] masN, char x)
        {
            int i = 0;
            while (masN[i] != x)
            {
                i++;
            } 
            return i;
        }

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Генерация сочетаний из N элементов по K с повторениями");
                int N;
                int K;
                do
                {
                    N = ReadInt("Введите число N: ");
                    if ((N > 36) || (N == 1)) Console.WriteLine("N не должно превышать 32 и должно быть больше 1");
                } while ((N > 36) || (N == 1));
                do
                {
                    K = ReadInt("Введите число K: ");
                    if (K > 10) Console.WriteLine("K не должно превышать 10");
                } while (K > 10);

                char[] masN = new char[N];//массив значений N
                char[] masK = new char[K];//массив значений K
                int j = (int)'A';
                for (int i = 0; i < N; i++)//заполняем массив N значениями
                {
                    if (i <= 9) masN[i] = Char.Parse(i.ToString());
                    else
                    {
                        masN[i] = (char)j;
                        j++;
                    }
                }
                for (int i = 0; i < K; i++)//Заполняем массив K нулями
                    masK[i] = '0';

                Console.WriteLine("ОТВЕТ:");

                WriteMas(masK);
                int k = K - 1;
                int min = 1;
                do
                {
                    for (int l = min; l < N; l++)
                    {
                        masK[k] = masN[l];
                        WriteMas(masK);
                    }
                    for (int i = 1; i <= k; i++)
                    {
                        if (masK[i] == masN[N - 1])
                        {
                            masK[i - 1] = masN[Index(masN, masK[i - 1]) + 1];
                            min = Index(masN, masK[i - 1]);
                            for (int f = i; f <= k; f++)
                                masK[f] = masN[min];
                            break;
                        }
                    }
                } while ((masK[0] != masN[N - 1]));
                if (K > 1) WriteMas(masK);

                Console.ReadLine();
            } while (true);
        }
    }
}
