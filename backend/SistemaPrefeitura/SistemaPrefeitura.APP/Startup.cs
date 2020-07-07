using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SistemaPrefeitura.APP.Extensions;
using SistemaPrefeitura.Infra.Common.Configurations;

namespace SistemaPrefeitura.APP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Auth0Configurations auth0Configurations = new Auth0Configurations();
            new ConfigureFromConfigurationOptions<Auth0Configurations>(
                Configuration.GetSection("Auth0Configurations"))
                .Configure(auth0Configurations);
            services.AddSingleton(auth0Configurations);

            services.AddDatabase(Configuration);
            services.AddRepositories();
            services.AddServices();
            services.AddMappers();
            services.AddOauthProvider(auth0Configurations);

            services.AddSwagger();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sistema Prefeitura API - V1");
                c.OAuthAdditionalQueryStringParams(new Dictionary<string, string>()
                {
                    {"audience",@"https://localhost:44386/api/v1/" }
                });
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
