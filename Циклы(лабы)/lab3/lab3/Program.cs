﻿using System;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число x: ");
            double x = Double.Parse(Console.ReadLine());
            Console.WriteLine("Введите точность eps: ");
            double eps = Double.Parse(Console.ReadLine());

            double temp = 1, sum = 0; //temp - слагаемое
            int n = 0;
            while (Math.Pow(-1, n) * (n + 1) * temp > eps) 
            {
                sum += Math.Pow(-1, n) * (n + 1) * temp;
                temp *= x / 3;
                n++;
            }
            Console.Write(sum);
        }
    }
}