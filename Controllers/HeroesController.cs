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

        // GET api/values
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

        // [HttpGet("{paths}")]
        // public ActionResult<string> Get(string paths)
        // {
        //     var pathA = Startup.pathA;
        //     var pathB = Startup.pathB;
        //     return $"{pathA} - {pathB}";
        // }
        // // GET api/values/5
        // [HttpGet("{id}")]
        // public ActionResult<string> Get(int id)
        // {
        //     return "value";
        // }

        // // POST api/values
        // [HttpPost]
        // public void Post([FromBody] string value)
        // {
        // }

        // // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
