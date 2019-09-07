using Flunt.Validations;
using StaminaAppAgendamento.Core.Entidades;

namespace StaminaAppAgendamento.Dominio.Entidades
{
    public class UnidadeMedida : Entidade
    {
        public string Codigo { get; private set; }
        public string Descricao { get; private set; }

        public UnidadeMedida(string codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Codigo,1,"UnidadeMedida.Codigo","Codigo deve conter pele menos 1 caracter")
                .HasMaxLen(Codigo,1,"UnidadeMedida.Codigo","Codigo deve conter no máximo 100 caracteres")
                .HasMinLen(Descricao,1,"UnidadeMedida.Descricao","Descrição deve conter pele menos 1 caracter")
                .HasMaxLen(Descricao,1,"UnidadeMedida.Descricao","Descrição deve conter no máximo 100 caracteres")
            );
        }
    }
}