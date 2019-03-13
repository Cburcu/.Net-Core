using System;
using System.Collections.Generic;
using System.Linq;
using HwDIExample.Entities;
using HwDIExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace HwDIExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        public IServiceProvider _serviceProvider;
        public HeroesController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // GET api/heroes
        [HttpGet]
        public ActionResult<List<Hero>> Get()
        {
            List<Hero> heroes = new List<Hero>();
            var textStreams = _serviceProvider.GetServices<IHeroStream>();
            foreach (var textStream in textStreams)
            {
                var heroList = textStream.Read();
                foreach (var hero in heroList)
                {
                    heroes.Add(hero);
                }
            }
            return heroes;
        }
    }
}
