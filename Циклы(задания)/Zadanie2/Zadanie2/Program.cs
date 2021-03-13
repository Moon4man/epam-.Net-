using System;

namespace Zadanie2
{
    class Program
    {
        static void BinaryCode()
        {
            Console.Write("Введите число: ");
            int n = Int32.Parse(Console.ReadLine());

            string BinaryCode = Convert.ToString(n, 2);

            Console.WriteLine($"Двоичное представление: {BinaryCode}");
            Console.WriteLine("-----------");
        }

        static void BinaryCode2()
        {
            Console.Write("Введите число: ");
            int N = Int32.Parse(Console.ReadLine());
            int a;
            int i = 0;

            int[] BinaryCode2 = new int[10];

            while (N >= 1)
            {
                a = N % 2;
                BinaryCode2[i] = a;
                i++;

                N = N / 2;
            }

            for (i = (BinaryCode2.Length - 1); i >= 0; i--)
            {
                Console.Write(BinaryCode2[i]);
            }
        }
        static void Main()
        {
            BinaryCode();
            BinaryCode2();
            Console.ReadKey();
        }
    }
}
