using Elmah.Io.AspNetCore;
using Elmah.Io.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Curriculo.API.Configurations
{
    public static class LoggerConfiguration
    {
        public static IServiceCollection AddLoggerConfig(this IServiceCollection services)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "d6fd6c4fdec74cb4bc1900b1e6169981";
                o.LogId = new Guid("b2f25d5c-8bb3-4d2f-8f94-7043e38a325e");
            });

            // Configuração para logs adicionados manualmente (fora do pipeline da aplicação)
            services.AddLogging(buider =>
            {
                buider.AddElmahIo(o =>
                {
                    o.ApiKey = "d6fd6c4fdec74cb4bc1900b1e6169981";
                    o.LogId = new Guid("b2f25d5c-8bb3-4d2f-8f94-7043e38a325e");
                });

                buider.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
            });


            services.AddHealthChecks();

     
            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            app.UseHealthChecks("/api/hc");
            return app;
        }
    }


}
