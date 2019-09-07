using StaminaAppAgendamento.Core.Entidades;
using StaminaAppAgendamento.Core.ObjetoValores;

namespace StaminaAppAgendamento.Dominio.Entidades
{
    public class Telefone : Entidade
    {
        public string DDD { get; private set; }
        public string Numero { get; private set; }
        public string Observacao { get; set; }

        public Telefone(string ddd, string numero)
        {
            DDD = ddd;
            Numero = numero;
        }
    }
}