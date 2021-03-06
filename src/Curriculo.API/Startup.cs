using AutoMapper;
using Curriculo.API.Configurations;
using Curriculo.Business.Interfaces;
using Curriculo.Data.Context;
using Curriculo.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;


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

            /*services.AddDbContext<MeuDbContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), 
                  b => b.MigrationsAssembly("Curriculo.API"))); */



            services.AddScoped<MeuDbContext>();
            services.AddDbContext<MeuDbContext>(opt => opt.UseInMemoryDatabase("test"));

            services.AddLoggerConfig();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo

                {
                    Title = "Curriculo Api",
                    Version = "v1",
                    Description = "A challenge resolution in ASP.NET Core Web API",
                    Contact = new OpenApiContact
                    {
                        Name = "Felipe Souza",
                        Email = "felipe.souz@dcomp.ufs.br",
                        Url = new Uri("https://github.com/felipe6ouza"),
                    },

                });
            });

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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseLoggingConfiguration();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
