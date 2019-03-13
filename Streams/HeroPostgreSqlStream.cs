using System.Collections.Generic;
using System.Linq;
using HwDIExample.Entities;
using HwDIExample.Models;
using Microsoft.EntityFrameworkCore;

namespace HwDIExample
{
    public class HeroPostgreSqlStream : IHeroStream
    {
        private readonly HeroContext _heroContext;
        public HeroPostgreSqlStream(HeroContext heroContext)
        {
            _heroContext = heroContext;
            if (_heroContext.HeroesList.Count() == 0)
            {
                _heroContext.HeroesList.Add(new Hero { Name = "Batman", Character = "Bruce Wayne", Power = 1000 });
                _heroContext.HeroesList.Add(new Hero { Name = "Superman", Character = "Kal-El", Power = 1000 });
                _heroContext.HeroesList.Add(new Hero { Name = "Flash", Character = "Barry Allen", Power = 1000 });
                _heroContext.HeroesList.Add(new Hero { Name = "Green Lantern", Character = "Alan Scott", Power = 1000 });
                _heroContext.HeroesList.Add(new Hero { Name = "Green Arrow", Character = "Oliver Queen", Power = 1000 });
                _heroContext.HeroesList.Add(new Hero { Name = "Wonder Woman", Character = "Princess Diana", Power = 1000 });
                _heroContext.HeroesList.Add(new Hero { Name = "Martian Manhunter", Character = "Martian Manhunter", Power = 1000 });
                _heroContext.HeroesList.Add(new Hero { Name = "Robin/Nightwing", Character = "Dick Grayson", Power = 1000 });
                _heroContext.HeroesList.Add(new Hero { Name = "Spider Man", Character = "Peter Parker", Power = 1000 });
                _heroContext.HeroesList.Add(new Hero { Name = "Captain America", Character = "Steve Rogers", Power = 1000 });
                _heroContext.HeroesList.Add(new Hero { Name = "Blue Beetle", Character = "Dan Garret", Power = 1000 });
                _heroContext.HeroesList.Add(new Hero { Name = "Black Canary", Character = "Dinah Drake", Power = 1000 });
                _heroContext.HeroesList.Add(new Hero { Name = "Iron Man", Character = "Tony Stark", Power = 1000 });
                _heroContext.HeroesList.Add(new Hero { Name = "Thor", Character = "Thor Odinson", Power = 1000 });
                _heroContext.HeroesList.Add(new Hero { Name = "Hulk", Character = "Bruce Banner", Power = 1000 });
                _heroContext.HeroesList.Add(new Hero { Name = "Wolverine", Character = "James Howlett", Power = 1000 });
                _heroContext.HeroesList.Add(new Hero { Name = "Daredevil", Character = "Matthew Michael Murdock", Power = 1000 });
                _heroContext.HeroesList.Add(new Hero { Name = "Hawkeye", Character = "Clinton Francis Barton", Power = 1000 });
                _heroContext.HeroesList.Add(new Hero { Name = "Cyclops", Character = "Scott Summers", Power = 1000 });
                _heroContext.HeroesList.Add(new Hero { Name = "Silver Surfer", Character = "Norrin Radd", Power = 1000 });
                _heroContext.SaveChanges();
            }
        }
        public List<Hero> Read()
        {
            List<Hero> heroes = new List<Hero>();
            heroes = _heroContext.HeroesList.ToList();
            return heroes;
        }
    }
}