using System;

namespace HwDIExample.Models
{
    public class Hero : IHero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Character { get; set; }
        public int Power { get; set; }
    }
}