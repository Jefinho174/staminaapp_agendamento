using Flunt.Validations;
using StaminaAppAgendamento.Core.ObjetoValores;

namespace StaminaAppAgendamento.Dominio.ObjetoValores
{
    public class EnderecoEletronico : ObjetoValor
    {
        public string Descricao { get; private set; }

        public EnderecoEletronico(string descricao)
        {
            Descricao = descricao;
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Descricao,"Email.Descricao","Email não e valido")
            );
        }
    }
}