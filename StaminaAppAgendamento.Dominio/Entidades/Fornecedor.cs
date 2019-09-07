using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using StaminaAppAgendamento.Core.Entidades;
using StaminaAppAgendamento.Dominio.Enums;
using StaminaAppAgendamento.Dominio.ObjetoValores;

namespace StaminaAppAgendamento.Dominio.Entidades
{
    public class Fornecedor : Entidade
    {
        public string Nome { get; private set; }
        public ETipoPessoa TipoPessoa { get; private set; }
        public Documento Documento { get; private set; }
        private IList<Endereco> _enderecos;
        private IList<Telefone> _telefones;
        private IList<Email> _emails;
        public IReadOnlyCollection<Endereco> Enderecos { get { return _enderecos.ToArray(); } }
        public IReadOnlyCollection<Telefone> Telefones { get { return _telefones.ToArray(); } }
        public IReadOnlyCollection<Email> Emails { get { return _emails.ToArray(); } }

        public Fornecedor(string nome, ETipoPessoa tipoPessoa, Documento documento, string rg)
        {
            Nome = nome;
            TipoPessoa = tipoPessoa;
            Documento = documento;

            AddNotifications(Documento, new Contract()
                .Requires()
                .HasMinLen(Nome,1,"Fornecedor.Descricao","Nome deve conter pele menos 1 caracter")
                .HasMinLen(Nome,1,"Fornecedor.Descricao","Nome deve conter pele menos 1 caracter")
            );
        }

        public void AddTelefone(Telefone telefone){
            AddNotifications(telefone);
            _telefones.Add(telefone);
        }

        public void AddEmail(Email email){
            AddNotifications(email);
            _emails.Add(email);
        }

        public void AddEndereco(Endereco endereco){
            AddNotifications(endereco);
            _enderecos.Add(endereco);
        }
    }
}