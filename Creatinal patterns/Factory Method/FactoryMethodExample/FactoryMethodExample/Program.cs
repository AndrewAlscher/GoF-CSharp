using System;

namespace FactoryMethodExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Developer dev = new PanelDeveloper("ООО Алые Паруса");
            Developer devTwo = new WoodDeveloper("ООО Деревянное зодчество");

            House houseOne = dev.Create();
            House houseTwo = devTwo.Create();

            Console.ReadLine();
        }
    }

    /* Абстрактный класс строительной компании. */
    abstract class Developer
    {
        public string Name { get; set; }

        public Developer(string n)
        {
            Name = n;
        }

        /* Фабричный метод. */
        abstract public House Create();
    }

    /* Строит панельные дома. */
    class PanelDeveloper : Developer
    {
        public PanelDeveloper(string n) : base(n)
        {

        }

        public override House Create()
        {
            return new PanelHouse();
        }
    }

    /* Строит деревянные дома. */
    class WoodDeveloper : Developer
    {
        public WoodDeveloper(string n) : base(n)
        {

        }

        public override House Create()
        {
            return new WoodHouse();
        }
    }

    /* Абстрактный класс дома. */
    abstract class House
    {

    }

    /* Панельный дом. */
    class PanelHouse : House
    {
        public PanelHouse()
        {
            Console.WriteLine("Панельный дом построен.");
        }
    }

    /* Деревянный дом. */
    class WoodHouse : House
    {
        public WoodHouse()
        {
            Console.WriteLine("Деревянный дом построен.");
        }
    }
}
