using System;

namespace StaminaAppAgendamento.Infra.Dto
{
    public class ClienteTelefoneDto
    {
        public Guid Id { get; set; }
        public Guid IdCliente { get; set; }
        public string DDD { get; set; }
        public string Numero { get; set; }
        public string Observacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime? DataFinalizacao { get; set; }
    }
}