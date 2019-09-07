using StaminaAppAgendamento.Core.Entidades;

namespace StaminaAppAgendamento.Dominio.Entidades
{
    public class Servico : Entidade
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public decimal Desconto { get; private set; }
    }
}