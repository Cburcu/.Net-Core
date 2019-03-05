using System;

namespace HwDIExample{
    public class Hero : IHero
    {
        public string SuperHero { get; set; }
        public string Characters { get; set; }

        public void SaveTheWorld(string message)
        {
            Console.WriteLine(message);
        }
    }
}