using System.Collections.Generic;
using System.Net.Http;
using HwDIExample.Entities;
using HwDIExample.Models;

namespace HwDIExample
{
    public class HeroServiceStream : IHeroStream
    {
        public List<Hero> Read()
        {
            List<Hero> heroes = new List<Hero>();
            // service kullanmalısın rest tabanlı service projesi yazmalısın web api yazmalısın
            // HeroServiceStream için ayrı bir WEB API servisi yazacağız. REST tabanlı olacak ve geriye Hero listesi döndürecek.
            
            var client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:12345/api/");
            //HTTP GET
            var responseTask = client.GetAsync("heroes");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<Hero>>();
                readTask.Wait();

                heroes = readTask.Result;
            }

            return heroes;
        }
    }
}