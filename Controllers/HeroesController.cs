using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HwDIExample.Entities;
using HwDIExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HwDIExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        public IServiceScopeFactory _serviceScopeFactory;
        // public IServiceProvider _serviceProvider;
        public HeroesController(IServiceProvider serviceProvider, IServiceScopeFactory serviceScopeFactory)
        {
            // _serviceProvider = serviceProvider;
            _serviceScopeFactory = serviceScopeFactory;
        }

        // GET api/heroes
        [HttpGet]
        public ActionResult<List<Hero>> Get()
        {
            List<Hero> heroes = new List<Hero>();
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var streams = scope.ServiceProvider.GetServices<IHeroStream>();
                // var streams = _serviceProvider.GetServices<IHeroStream>();
                foreach (var stream in streams)
                {
                    var heroList = stream.Read();
                    foreach (var hero in heroList)
                    {
                        heroes.Add(hero);
                    }
                }
            }
            return heroes;
        }
    }
}
