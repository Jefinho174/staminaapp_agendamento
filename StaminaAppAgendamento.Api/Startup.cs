using System;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StaminaAppAgendamento.Infra.IoC;
using Swashbuckle.AspNetCore.Swagger;

namespace StaminaAppAgendamento.Api
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
            services.AddInfraIoC();
            services.AddMediatR(AppDomain.CurrentDomain.Load("StaminaAppAgendamento.Dominio"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                var resolver = options.SerializerSettings.ContractResolver;
                if (resolver != null)
                {
                    (resolver as DefaultContractResolver).NamingStrategy = null;
                }
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "StaminaApp Agendamento - WebApi",
                    Version = "v1",
                    Contact = new Contact
                    {
                        Name = "Jeferson Luiz",
                        Url = "https://github.com/Jefinho174"
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "StaminaApp - Agendamento");
                c.RoutePrefix = string.Empty;
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
