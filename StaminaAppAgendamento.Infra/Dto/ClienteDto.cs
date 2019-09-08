using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using StaminaAppAgendamento.Dominio.Entidades;
using StaminaAppAgendamento.Dominio.Enums;

namespace StaminaAppAgendamento.Infra.Dto
{
    [Table("Cliente")]
    public class ClienteDto 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string SegundoNome { get; set; }
        public ETipoPessoa TipoPessoa  { get; set; }
        public string Documento { get; set; }
        public string Rg { get; set; }
        public IList<ClienteEnderecoDto> Enderecos { get; set; }
        public IList<ClienteTelefoneDto> Telefones { get; set; }
        public IList<ClienteEmailDto> Emails { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime? DataFinalizacao { get; set; }
    }
}