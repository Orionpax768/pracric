using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pracric
{
    abstract class GeometricShape //предок
    {
        protected string name; //название фигурки
        protected uint[] lenghrs; //количество сторон. Вадим, поздравляю с рождением дочери!
        protected uint sides; //массив для назначения сторон
        public GeometricShape() 
        {
            Console.WriteLine("Это абстрактна фигураю Свединий нет.");
        }

        protected uint Perimeter() 
        { 
            uint perinetr = 0;
            foreach (uint itemn in lenghrs) 
            {
                perinetr += itemn;
            }
            return perinetr;
        }

        protected abstract double Square(); //абстрактный метод

        protected void GetInfo() 
        {
            Console.WriteLine($"Информация о геометрической фигуре" + 
                $"\nНазвание фигуры: {name}" + 
                $"\nКоличество сторон: {sides}" + 
                $"\nПериметр: {Perimeter()}" + 
                $"\nПлощадь: {Square()}");
        }
    }
    class Rectangle: GeometricShape //наследник прямоугольник
    {
        public Rectangle() 
        {
            base.name = "Прямоугольник";
            base.sides = 4;
            base.lenghrs = new uint[4] {4,8,4,8};
            base.GetInfo();
        }

        protected override double Square() 
        {
            return lenghrs[0] * lenghrs[1]; //Площадь прямоугольника йоу S = a*b
        }
    }
    class Triangle : GeometricShape 
    {
        public Triangle() 
        {
            base.name = "Треугольник";
            base.sides = 3;
            base.lenghrs = new uint[3] {3,6, 9};
            base.GetInfo();
        }
        protected override double Square() 
        {
            double halfmeter = base.Perimeter()/2;
            double stric = Math.Sqrt(halfmeter * (halfmeter * lenghrs[0]) * (halfmeter * lenghrs[1]) * (halfmeter * lenghrs[2]));
            return Math.Round(stric, 2);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle rtag = new Rectangle();
            Console.WriteLine();
            Triangle trg= new Triangle();
            Console.ReadKey();
        }
    }
}