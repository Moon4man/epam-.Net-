using System;

namespace Operator
{
    class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        // Длина векторов
        private double length;
        public double Length
        {
            get
            {
                return Math.Round(Math.Sqrt(X * X + Y * Y + Z * Z), 2);
            }
            set
            {
                length = value;
            }
        }

        // Угол между векторам (cos)
        public double Angle(Vector v)
        {
            double cos = Math.Round((X * v.X + Y * v.Y + Z * v.Z) / (this.Length * v.Length), 4);
            return cos;
        }

        // Сложение векторов
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        // Вычитание векторов
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        // Скалярное умножение
        public static double operator *(Vector v1, Vector v2)
        {
            return Math.Round(v1.Length * v2.Length * v1.Angle(v2), 2);
        }

        // Переопределение метода ToString()
        public override string ToString()
        {
            return String.Format("({0}, {1}, {2})", X, Y, Z);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Vector a = new Vector(3, 1, 2);
            Vector b = new Vector(0, 4, 6);

            Console.WriteLine("Дано: вектор а{0} и вектор b{1}", a.ToString(), b.ToString());
            Console.WriteLine("Сумма векторов = {0}", a + b);
            Console.WriteLine("Разность векторов = {0}", a - b);
            Console.WriteLine("Скалярное произведение векторов = {0}", a * b);
            Console.ReadKey();
        }
    }
}
