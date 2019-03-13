using System.Collections.Generic;
using HwDIExample.Entities;
using HwDIExample.Models;

namespace HwDIExample
{
    public class HeroTextStream : IHeroStream
    {
        public List<Hero> Read()
        {
            List<Hero> heroes = new List<Hero>();
            var heroesListString = System.IO.File.
                ReadAllLines(@"C:\Projects\Education\DotNet_Core\HwDIExample\bin\Debug\netcoreapp2.2\A.txt");
            foreach(string heroString in heroesListString){
                var heroname = heroString.Split(':');
                var hero = new Hero{
                    Name = heroname[0],
                    Character = heroname[1],
                    Power = int.Parse(heroname[2])
                };
                heroes.Add(hero);
            }
            return heroes;
        }
    }
}