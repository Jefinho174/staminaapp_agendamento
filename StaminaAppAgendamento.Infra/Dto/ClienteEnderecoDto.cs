using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaminaAppAgendamento.Infra.Dto
{
    public class ClienteEnderecoDto
    {
        [Key]
        public Guid Id { get; set; }
        public Guid IdCliente { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Observacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime? DataFinalizacao { get; set; }
    }
}