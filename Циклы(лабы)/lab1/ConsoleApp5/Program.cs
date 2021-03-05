using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            double factorial = 1;
            double sum = 0;
            Console.Write("Введите число N: ");
            int N = Int32.Parse(Console.ReadLine());
            Console.Write("Введите число x: ");
            int x = Int32.Parse(Console.ReadLine());
            for (int i = 1; i <= N; i++)
            {
                factorial *= 2 * i;
            }
            if (N > 0)
            {
                for(int i = 1; i <= N; i++)
                {
                    sum += Math.Pow(-1, i + 1)*(1/factorial)*Math.Pow((x/3), 4 * i);
                }
                Console.WriteLine($"Полученная сумма ряда: {sum}");
            }
            else
            {
                Console.WriteLine("Было введено отрицательное число или 0!");
            }
            Console.ReadKey();
        }
    }
}
