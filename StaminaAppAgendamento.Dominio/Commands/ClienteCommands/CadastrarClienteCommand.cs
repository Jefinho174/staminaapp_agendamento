using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using StaminaAppAgendamento.Core.Commands;
using StaminaAppAgendamento.Dominio.Entidades;
using StaminaAppAgendamento.Dominio.Enums;

namespace StaminaAppAgendamento.Dominio.Commands.ClienteCommands
{
    public class CadastrarClienteCommand : Notifiable, IRequest<CommandResult<Cliente>>
    {
        public string PrimeiroNome { get; set; }
        public string SegundoNome { get; set; }
        public ETipoPessoa TipoPessoa { get; set; }
        public string Documento { get; set; }
        public string Rg { get; set; }

         public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(PrimeiroNome, 1, "PrimeiroNome", "Primeiro Nome deve conter pele menos 1 caracter")
                .HasMinLen(SegundoNome, 1, "SegundoNome", "Segundo Nome deve conter pele menos 1 caracter")
                .HasMaxLen(PrimeiroNome, 100, "PrimeiroNome", "Primeiro Nome deve conter no máximo 100 caracteres")
                .HasMaxLen(SegundoNome, 100, "SegundoNome", "Segundo Nome deve conter no máximo 100 caracteres")
                .HasMinLen(Documento, 1, "Documento", "Documento deve conter pele menos 1 caracter")
            );
        }
    }
}