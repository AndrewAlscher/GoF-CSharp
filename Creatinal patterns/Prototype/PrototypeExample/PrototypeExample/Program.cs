using System;

namespace PrototypeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            IFigure figure = new Rectangle(30, 40);
            IFigure clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            figure = new Circle(30);
            clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            Console.Read();
        }
    }

    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }

    class Rectangle : IFigure
    {
        int Width { get; set; }
        int Height { get; set; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public IFigure Clone()
        {
            return new Rectangle(Width, Height);
        }

        public void GetInfo()
        {
            Console.WriteLine("Прямоугольник длиной {0} и шириной {1}", Height, Width);
        }
    }

    class Circle : IFigure
    {
        int Radius { get; set; }

        public Circle(int radius)
        {
            Radius = radius;
        }

        public IFigure Clone()
        {
            return new Circle(Radius);
        }

        public void GetInfo()
        {
            Console.WriteLine("Круг с радиусом{0}", Radius);
        }
    }


}
