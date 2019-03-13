using HwDIExample.Entities;
using HwDIExample.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HwDIExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            pathA = Configuration.GetSection("FilePaths").GetSection("PathA").Value;
        }
        public IConfiguration Configuration { get; }
        public static string pathA;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HeroContext>(options =>
                    options.UseNpgsql(connectionString: Configuration.GetConnectionString(name: "DefaultConnection")));
                    
            services.AddSingleton<IHero, Hero>();
            // services.AddSingleton<IHeroStream, HeroTextStream>();
            services.AddSingleton<IHeroStream, HeroPostgreSqlStream>();
            // services.AddSingleton<IHeroStream, HeroServiceStream>();

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
