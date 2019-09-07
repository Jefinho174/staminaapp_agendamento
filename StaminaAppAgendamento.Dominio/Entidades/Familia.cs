using Flunt.Validations;
using StaminaAppAgendamento.Core.Entidades;

namespace StaminaAppAgendamento.Dominio.Entidades
{
    public class Familia : Entidade
    {
        public string Descricao { get; private set; }

        public Familia(string descricao)
        {
            Descricao = descricao;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Descricao,1,"Familia.Descricao","Descrição deve conter pele menos 1 caracter")
                .HasMaxLen(Descricao,1,"Familia.Descricao","Descrição deve conter no máximo 100 caracteres")
            );
        }
    }
}