using System;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Dommel;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using StaminaAppAgendamento.Dominio.Repositorios;
using StaminaAppAgendamento.Infra.DtoMapeamento;
using StaminaAppAgendamento.Infra.Repositorio;
using static Dommel.DommelMapper;

namespace StaminaAppAgendamento.Infra.IoC
{
    public static class InfraIoC
    {
        public static IServiceCollection AddInfraIoC(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => {
                cfg.AddExpressionMapping();
            },typeof(InfraIoC).Assembly);

            services.AddScoped<IClienteRepositorio>(factory =>
            {
                var mapper = services.BuildServiceProvider(false).GetService<IMapper>();
                return new ClienteRepositorio("server=192.168.99.100;port=3306;database=staminaapp_agendamento;userid=root;password=root", mapper);
            });

            SetKeyPropertyResolver(new DefaultKeyPropertyResolver());

            //FluentMapper.Initialize(config =>
            //{
            //    config.AddMap(new ClienteDtoMap());
            //    config.ForDommel();
            //});

            services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddMySql5()
                    .WithGlobalConnectionString("server=192.168.99.100;port=3306;database=staminaapp_agendamento;userid=root;password=root")
                    .ScanIn(typeof(InfraIoC).Assembly).For.Migrations());
            UpdateDatabase(services.BuildServiceProvider(false));
            return services;
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var runner = scope.ServiceProvider.GetService<IMigrationRunner>();
                runner.MigrateUp();
            }
        }
    }
}