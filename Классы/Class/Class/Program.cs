using System;

namespace Class
{
    abstract class GeometrFigure
    {
        public abstract double Squere();
        public abstract double Perimetr();
    }
        class FigureStar : GeometrFigure
        {
        private double a;

        public double A
        {
            get { return a; }
            set {
                if (value < 0)
                {
                    Console.WriteLine("Неверные данные! Введите положительное число!");
                }
                else
                {
                    a = value;
                }
            }
        }

        public override double Squere()
            {
                return (4 *((Math.Pow(a, 2) * Math.Sqrt(3)) / 2)) + Math.Pow(a,2); // площадь правильной четырехконечной звезды = 
                                                                                   // = 4-е площади равносторонего треугольника + площадь кадрата
            }

            public override double Perimetr()
            {
                return 8 * a; // периметр = произведение длины 8-ми сторон
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                FigureStar star = new FigureStar();
                Console.WriteLine("Правильная четырехконечная звезда!");
                Console.WriteLine("Введите сторону: ");
                star.A = Int32.Parse(Console.ReadLine());
            if(star.A > 0)
            {
                Console.WriteLine($"Введенная вами сторона: {star.A}");
                Console.WriteLine("Площадь звезды: {0:#.##}", star.Squere());
                Console.WriteLine("Периметр звезды: {0:#.##}", star.Perimetr());
            }
            }
        }
    }
