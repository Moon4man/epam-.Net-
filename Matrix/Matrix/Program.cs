using System;
using System.IO;
using System.Text;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 0, M = 0, i = 0, j = 0, k = 0;
            string PathIn = "Inlet.txt";
            string PathOut = "Outlet.txt";
            int[,] Matrix = new int[50, 50];
            string FileString;
            string[] FileMatrix;
            int result = 0;
            int p;

            using (var file = new StreamReader(PathIn))
            {
                while (!file.EndOfStream)
                {
                        FileString = file.ReadLine();
                        FileMatrix = FileString.Split(' ');
                        for (j = 0; j < FileMatrix.Length; j++)
                        {
                            Matrix[i, j] = int.Parse(FileMatrix[j]);
                        }
                        i++;
                }
            }

            N = i;
            M = j;

            Console.Write("\nk: ");
            k = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("-----------------------------------");

            for (i = 0; i < N; i++)
            {
                for (j = 0; j < M; j++)
                {
                    p = i * M + j;
                    if (p % k == 0)
                    {
                        result += Matrix[i, j];
                    }
                }
            }
            using (var file = new StreamWriter(Path.GetFullPath(PathOut), false))
                file.Write($"Сумма элементов массива, приведенные индексы которых делятся на k: {result}");
            Console.WriteLine("Запись в файл произведена!");
        }
    }
}
