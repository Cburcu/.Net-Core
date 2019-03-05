using System;
using System.Collections.Generic;

namespace HwDIExample.Controllers
{
    public class GetHeroes
    {
        public static List<Hero> Heroes(string textFilePath){
            List<Hero> heroes = new List<Hero>();
            var heroesListString = System.IO.File.ReadAllLines(textFilePath);
            foreach(string heroString in heroesListString){
                var heroname = heroString.Split(':');
                var hero = new Hero{
                    SuperHero = heroname[0],
                    Characters = heroname[1]
                };
                heroes.Add(hero);
            }
            return heroes;
        }

        internal static object Heroes(object service)
        {
            throw new NotImplementedException();
        }
    }
}