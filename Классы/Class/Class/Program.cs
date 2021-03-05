using System;

namespace Class
{
    abstract class GeometrFigura
    {
        public abstract double Squere();
        public abstract double Perimetr();
    }
        class FiguraStar : GeometrFigura
        {
            double a;

            public FiguraStar(double a)
            {
                this.a = a;
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
                FiguraStar star = new FiguraStar(4.0);
                Console.WriteLine("Правильная четырехконечная звезда!");
                Console.WriteLine("Площадь звезды: {0:#.##}", star.Squere());
                Console.WriteLine("Периметр звезды: {0:#.##}", star.Perimetr());
                Console.WriteLine();
            }
        }
    }
