using System;
using System.IO;

namespace ExceptionHandling
{
    class WrongMatrixException : Exception
    {
        public WrongMatrixException(Matrix M1, Matrix M2)
        {
            Length1 = M1.Length;
            Width1 = M1.Width;
            Length2 = M2.Length;
            Width2 = M2.Width;
            PrintData();
        }

        private int Length1;
        private int Width1;
        private int Length2;
        private int Width2;

        private string data
        {
            get
            {
                return $"Матрица №1:\nКоличество строк: {Length1}" +
                       $" \nКоличество столбцов: {Width1}\n" +
                       $"Матрица №2:\nКоличество строк: {Length2}" +
                       $" \nКоличество столбцов: {Width2}";
            }
        }

        private void PrintData()
        {
            Console.WriteLine(data);
        }
    }

    class Matrix
    {
        private int[,] _Matrix;
        private int M;
        private int N;

        public int Length { get; set; }
        public int Width { get; set; }

        public Matrix(int[,] Matrix, int M, int N)
        {
            _Matrix = Matrix;
            this.M = M;
            this.N = N;
            Length = M;
            Width = N;
        }

        public static Matrix Sum(Matrix M1, Matrix M2)
        {
            Matrix ResultMatrix;
            int[,] ResMatrix = new int[M1.M, M1.N];

            for (int i = 0; i < M1.M; i++)
            {
                for (int j = 0; j < M2.N; j++)
                {
                    try
                    {
                        ResMatrix[i, j] = M1._Matrix[i, j] + M2._Matrix[i, j];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Нельзя складывать матрицы разной размерности!");
                        return M1;
                    }
                }
            }
            ResultMatrix = new Matrix(ResMatrix, M1.M, M1.N);
            return ResultMatrix;
        }

        public static Matrix Diff(Matrix M1, Matrix M2)
        {
            Matrix ResultMatrix;
            int[,] ResMatrix = new int[M1.M, M1.N];

            for (int i = 0; i < M1.M; i++)
            {
                for (int j = 0; j < M2.N; j++)
                {
                    try
                    {
                        ResMatrix[i, j] = M1._Matrix[i, j] - M2._Matrix[i, j];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Нельзя вычитать матрицы разной размерности!");
                        return M1;
                    }
                }
            }
            ResultMatrix = new Matrix(ResMatrix, M1.M, M1.N);
            return ResultMatrix;
        }

        public static Matrix Multipication(Matrix M1, Matrix M2)
        {
            if (M1.N != M2.M)
            {
                Console.WriteLine("Вызван Exceptoin!");
                throw new WrongMatrixException(M1, M2);
            }

            Matrix ResultMatrix;
            int[,] ResMatrix = new int[M1.M, M2.N];

            for (int i = 0; i < M1.M; i++)
            {
                for (int j = 0; j < M2.N; j++)
                {
                    ResMatrix[i, j] = 0;

                    for (int k = 0; k < M1.N; k++)
                    {
                        ResMatrix[i, j] += M1._Matrix[i, k] * M2._Matrix[k, j];
                    }
                }
            }

            ResultMatrix = new Matrix(ResMatrix, M1.M, M2.N);
            return ResultMatrix;
        }

        public static Matrix GetEmpty(int Length, int Width)
        {
            int[,] Matrix = new int[Length, Width];
            return new Matrix(Matrix, Length, Width);
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < this.M; i++)
            {
                for (int j = 0; j < this.N; j++)
                {
                    Console.Write(this._Matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int i = 0, j = 0;
            int n = 0, m = 0;
            int[,] Matrix_1 = new int[50, 50];
            int[,] Matrix_2 = new int[50, 50];
            string PathIn_1 = "Inlet_1.txt";
            string PathIn_2 = "Inlet_2.txt";
            string FileString;
            string[] FileMatrix;
            int M1, N1, M2, N2;

            using (var file1 = new StreamReader(PathIn_1))
            {
                while (!file1.EndOfStream)
                {
                    FileString = file1.ReadLine();
                    FileMatrix = FileString.Split(' ');
                    for (j = 0; j < FileMatrix.Length; j++)
                    {
                        Matrix_1[i, j] = int.Parse(FileMatrix[j]);
                    }
                    i++;
                }
            }

            M1 = i;
            N1 = j;

            using (var file2 = new StreamReader(PathIn_2))
            {
                while (!file2.EndOfStream)
                {
                    FileString = file2.ReadLine();
                    FileMatrix = FileString.Split(' ');
                    for (m = 0; m < FileMatrix.Length; m++)
                    {
                        Matrix_2[n, m] = int.Parse(FileMatrix[m]);
                    }
                    n++;
                }
            }

            M2 = n;
            N2 = m;

            Matrix Matrix1 = new Matrix(Matrix_1, M1, N1);
            Matrix Matrix2 = new Matrix(Matrix_2, M2, N2);
            Matrix MatrixSum, MatrixMultiplication, MatrixDifference;
            MatrixSum = Matrix.Sum(Matrix1, Matrix2);
            MatrixDifference = Matrix.Diff(Matrix1, Matrix2);
            MatrixMultiplication = Matrix.Multipication(Matrix1, Matrix2);
            Console.WriteLine("Sum:");
            MatrixSum.PrintMatrix();
            Console.WriteLine("\nDifference:");
            MatrixDifference.PrintMatrix();
            Console.WriteLine("\nMultiplication:");
            MatrixMultiplication.PrintMatrix();
        }
    }
}