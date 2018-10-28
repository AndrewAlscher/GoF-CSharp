using System;

namespace AbstractFactoryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero heroOne = new Hero(new ElfFactory());
            heroOne.Hit();
            heroOne.Run();

            Hero heroTwo = new Hero(new WariorFactory());
            heroTwo.Hit();
            heroTwo.Run();

            Console.ReadLine();
        }
    }

    // Абстрактный класс - оружие.
    abstract class Weapon
    {
        public abstract void Hit();
    }

    // Класс - арбалет.
    class Arbalet : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Стреляем из арбалета.");
        }
    }

    // Класс - меч.
    class Sword : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Ударяем мечом.");
        }
    }

    // Абстрактный класс - движение.
    abstract class Movement
    {
        public abstract void Move();
    }

    // Класс - бег.
    class RunMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Бежим.");
        }
    }

    // Класс - полёт.
    class FlyMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Летим.");
        }
    }

    // Класс абстрактной фабрики.
    abstract class HeroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
    }

    // Фабрика по созданию летающих героев с арбалетами.
    class ElfFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Arbalet();
        }
    }

    // Фабрика по созданию бегающих воинов с мечом.
    class WariorFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
    }

    // Клиент.
    class Hero
    {
        private Weapon Weapon { get; set; }
        private Movement Movement { get; set; }

        public Hero(HeroFactory factory)
        {
            Weapon = factory.CreateWeapon();
            Movement = factory.CreateMovement();
        }

        public void Run()
        {
            Movement.Move();
        }

        public void Hit()
        {
            Weapon.Hit();
        }
    }
}
