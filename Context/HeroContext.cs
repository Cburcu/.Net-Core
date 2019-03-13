using System.Linq;
using HwDIExample.Entities;
using HwDIExample.Models;
using Microsoft.EntityFrameworkCore;

namespace HwDIExample
{
    public class HeroContext : DbContext
    {
        public HeroContext(DbContextOptions<HeroContext> options) : base(options)
        {
        }
        public DbSet<Hero> HeroesList { get; set; }

    }
}