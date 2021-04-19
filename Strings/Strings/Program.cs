using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HelloApp
    {
        class Program
        {
        static void Main(string[] args)
        {
            int N = 0, M = 0, i = 0, j = 0, k = 0;
            string PathIn = "Inlet.txt";
            string PathOut = "Outlet.txt";
            string[,] Matrix = new string[50, 50];
            string FileString;
            string[] FileMatrix;
            string[] result = new string[50];
            double[] AvverageWords = new double[50];
            int[,] NumberOfSymbols = new int[50, 50];
            string Result = "-1";

            using (var file = new StreamReader(PathIn))
            {
                while (!file.EndOfStream)
                {
                    FileString = file.ReadLine();
                    FileMatrix = FileString.Split(' ');
                    for (j = 0; j < FileMatrix.Length; j++)
                    {
                        Matrix[i, j] = FileMatrix[j];
                    }
                    i++;
                }
            }

            N = i;
            M = j;
            Console.Write("Enter k: ");
            k = Convert.ToInt32(Console.ReadLine());

            for (i = 0; i < N; i++)
            {
                for (j = 0; j < M; j++)
                {
                    int num = 0;
                    for (int n = 0; n < Matrix[i, j].Length; n++)
                    {
                        if (Matrix[i, j].Substring(n, 1) != " ")
                            num++;
                    }
                    NumberOfSymbols[i, j] = num;
                }
            }

            for (i = 0; i < N; i++)
            {
                double SumOfWords = 0;
                for (j = 0; j < M; j++)
                {
                    SumOfWords += NumberOfSymbols[i, j];
                }
                AvverageWords[i] = SumOfWords / M;
            }

            for (i = 0; i < N; i++)
            {
                for (j = 0; j < M; j++)
                {
                    if (Math.Abs(NumberOfSymbols[i, j] - AvverageWords[i]) <= k)
                    {
                        Result = Matrix[i, j];
                        break;
                    }
                }
                result[i] = Result;
            }

            using (var file = new StreamWriter(Path.GetFullPath(PathOut), false))
            {
                for (i = 0; i < N; i++)
                {
                    file.Write($"Result: {result[i]}\n");
                }
            }
            Console.WriteLine("Запись в файл произведена!");
        }
        }
    }

