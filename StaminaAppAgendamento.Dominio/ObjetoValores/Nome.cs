using Flunt.Validations;
using StaminaAppAgendamento.Core.ObjetoValores;

namespace StaminaAppAgendamento.Dominio.ObjetoValores
{
    public class Nome : ObjetoValor
    {
        public string PrimeiroNome { get; private set; }
        public string SegundoNome { get; private set; }

        public Nome(string primeiroNome, string segundoNome)
        {
            PrimeiroNome = primeiroNome;
            SegundoNome = segundoNome;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(PrimeiroNome, 1, "Nome.PrimeiroNome", "Primeiro Nome deve conter pele menos 1 caracter")
                .HasMinLen(SegundoNome, 1, "Nome.SegundoNome", "Segundo Nome deve conter pele menos 1 caracter")
                .HasMaxLen(PrimeiroNome, 100, "Nome.PrimeiroNome", "Primeiro Nome deve conter no máximo 100 caracteres")
                .HasMaxLen(SegundoNome, 100, "Nome.SegundoNome", "Segundo Nome deve conter no máximo 100 caracteres")
            );
        }

        public override string ToString()
        {
            return string.Concat(PrimeiroNome, " ", SegundoNome);
        }
    }
}