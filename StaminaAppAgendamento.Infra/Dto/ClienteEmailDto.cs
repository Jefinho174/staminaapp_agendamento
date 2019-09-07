using System;

namespace StaminaAppAgendamento.Infra.Dto
{
    public class ClienteEmailDto
    {
        public Guid Id { get; set; }
        public Guid IdCliente { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime? DataFinalizacao { get; set; }
    }
}