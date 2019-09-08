using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StaminaAppAgendamento.CrossCutting.Configuracoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfiguracaoIoC
    {
        public static IServiceCollection AdicionaConfiguracoes(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider(false);
            var configuracoes = serviceProvider.GetService<IConfigurationRoot>();

            var conexaoDBConfig = configuracoes.GetSection("Conexao").Get<ConexaoDBConfig>();
            services.AddSingleton<ConexaoDBConfig>(conexaoDBConfig);

            return services;
        }
    }
}
