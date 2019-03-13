using System.Collections.Generic;
using HwDIExample.Models;
namespace HwDIExample.Entities
{
    public interface IHeroStream
    {
        List<Hero> Read();
    }
}