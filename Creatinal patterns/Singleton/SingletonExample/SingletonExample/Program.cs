using System;

namespace SingletonExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer comp = new Computer();
            comp.Launch("Windows 8.1");
            Console.WriteLine(comp.OS.Name);

            // У нас не получится изменить ОС, так как объект уже создан.
            comp.OS = OS.getInstance("Windows 10");
            Console.WriteLine(comp.OS.Name);
        }
    }

    class Computer
    {
        public OS OS { get; set; }

        public void Launch(string osName)
        {
            OS = OS.getInstance(osName);
        }
    }


    // Синглтон. Можно одновременно использовать только одну ОС на ПК.
    class OS
    {
        private static OS instanse;

        public string Name { get; private set; }
        private static object syncRoot = new Object();

        protected OS (string name)
        {
            Name = name;
        }

        public static OS getInstance(string name)
        {
            // Двойная проверка instance и потокобезопасность.
            if (instanse == null)
            {
                lock (syncRoot)
                {
                    if (instanse == null)
                    {
                        instanse = new OS(name);
                    }
                }
            }
            

            return instanse;
        }
    }
}
