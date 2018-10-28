using System;

namespace SingletonLazyExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer comp = new Computer();
            comp.Launch();

            // Не получится изменить ОС, т.к. объект уже создан.
            comp.OS = OS.getInstance();
        }
    }

    public class Computer
    {
        public OS OS { get; set; }

        public void Launch()
        {
            OS = OS.getInstance();
        }
    }


    public class OS
    {
        private static readonly Lazy<OS> lazy = new Lazy<OS>(() => new OS());

        public string Name { get; private set; }

        private OS()
        {
            Name = System.Guid.NewGuid().ToString();
        }

        public static OS getInstance()
        {
            return lazy.Value;
        }
    }
}
