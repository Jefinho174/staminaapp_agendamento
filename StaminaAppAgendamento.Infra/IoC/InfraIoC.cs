using System;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Dommel;
using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Generators.MySql;
using FluentMigrator.Runner.Processors.MySql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MySql.Data.MySqlClient;
using StaminaAppAgendamento.CrossCutting.Configuracoes;
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

            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

            SetKeyPropertyResolver(new DefaultKeyPropertyResolver());

            services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddMySql5()
                    .WithGlobalConnectionString(serviceProvider =>
                    {
                        var config = serviceProvider.GetService<ConexaoDBConfig>();
                        return config.DBConnectionString;
                    })
                    .ScanIn(typeof(InfraIoC).Assembly).For.Migrations());
            UpdateDatabase(services.BuildServiceProvider(false));
            return services;
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {

            using (var scope = serviceProvider.CreateScope())
            {
                var config = scope.ServiceProvider.GetService<ConexaoDBConfig>();
                using (var db = new MySqlConnection(config.ConnectionString))
                using (var cmd = new MySqlCommand($"CREATE DATABASE IF NOT EXISTS {config.Database}", db))
                {
                    db.Open();
                    cmd.ExecuteNonQuery();
                }

                var runner = scope.ServiceProvider.GetService<IMigrationRunner>();
                if (runner.HasMigrationsToApplyUp())
                    runner.MigrateUp();
            }
        }
    }
}