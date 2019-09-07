using StaminaAppAgendamento.Core.Entidades;
using StaminaAppAgendamento.Dominio.ObjetoValores;

namespace StaminaAppAgendamento.Dominio.Entidades
{
    public class Email : Entidade
    {
        public EnderecoEletronico EnderecoEletronico { get; private set; }

        public string Observacao { get; private set; }

        public Email(EnderecoEletronico enderecoEletronico, string observacao)
        {
            EnderecoEletronico = enderecoEletronico;
            Observacao = observacao;

            AddNotifications(EnderecoEletronico);
        }
    }
}