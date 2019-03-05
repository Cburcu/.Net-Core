using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HwDIExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            superHero = Configuration.GetSection("Hero").GetSection("superhero").Value;
            superCharacter = Configuration.GetSection("Hero").GetSection("characters").GetSection("character1").Value;
        }
        public IConfiguration Configuration { get; }
        public static string superHero;
        public static string superCharacter;
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHero, Hero>();
            services.AddSingleton<ITextFileName, TextFileNameA>();
            services.AddSingleton<ITextFileName, TextFileNameB>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }
    }
}
