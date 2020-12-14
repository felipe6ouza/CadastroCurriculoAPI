using AutoMapper;
using Curriculo.Business.Interfaces;
using Curriculo.Data.Context;
using Curriculo.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Curriculo.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<MeuDbContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), 
                  b => b.MigrationsAssembly("Curriculo.API")));

            services.AddScoped<MeuDbContext>();

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IPessoaRepository, PessoaRepository>();
           

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
