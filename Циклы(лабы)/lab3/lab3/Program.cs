using System;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {

            double sum = 0;
            int n = 0;

            Console.Write("Введите число x: ");
            double x = Double.Parse(Console.ReadLine());
            Console.Write("Введите точность eps: ");
            double eps = Double.Parse(Console.ReadLine());

            while ((Math.Pow(-1, n) * (n + 1) * Math.Pow(x, n) / Math.Pow(3,n)) > eps)
            {
                sum += Math.Pow(-1, n) * (n + 1) * Math.Pow(x, n) / Math.Pow(3, n);
                n++;
            }
            Console.WriteLine(sum);
        }
    }
}
