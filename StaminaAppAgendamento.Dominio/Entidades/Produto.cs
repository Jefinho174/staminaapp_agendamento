using System;
using Flunt.Validations;
using StaminaAppAgendamento.Core.Entidades;
using StaminaAppAgendamento.Dominio.ObjetoValores;

namespace StaminaAppAgendamento.Dominio.Entidades
{
    public class Produto : Entidade
    {
        public string Codigo { get; private set; }
        public string Referencia { get; private set; }
        public string Descricao { get; private set; }
        public string DescricaoReduzida { get; private set; }
        public string Detalhamento { get; private set; }
        public string Ean { get; private set; }
        public Ncm Ncm { get; private set; }
        public Categoria Categoria { get; private set; }
        public UnidadeMedida UnidadeMedida { get; private set; }
        public Fornecedor Fornecedor { get; private set; }
        public decimal ValorUnidadeMedica { get; private set; }
        public Custo Custo { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public int Quantidade { get; private set; }

        public Produto(string codigo, string referencia, string descricao, string descricaoReduzida, string detalhamento, string ean, Ncm ncm, Categoria categoria, UnidadeMedida unidadeMedida, Fornecedor fornecedor, decimal valorUnidadeMedica, Custo custo, decimal valorUnitario, int quantidade)
        {
            Codigo = codigo;
            Referencia = referencia;
            Descricao = descricao;
            DescricaoReduzida = descricaoReduzida;
            Detalhamento = detalhamento;
            Ean = ean;
            Ncm = ncm;
            Categoria = categoria;
            UnidadeMedida = unidadeMedida;
            Fornecedor = fornecedor;
            ValorUnidadeMedica = valorUnidadeMedica;
            Custo = custo;
            ValorUnitario = valorUnitario;
            Quantidade = quantidade;

            AddNotifications(Ncm,Categoria,UnidadeMedida,Fornecedor,Custo, new Contract()
                .Requires()
                .HasMinLen(Codigo,1,"Produto.Codigo","Codigo deve conter pele menos 1 caracter")
                .HasMaxLen(Codigo,100,"Produto.Codigo","Codigo deve conter no máximo 100 caracteres")
                .HasMinLen(Descricao,1,"Produto.Descricao","Descrição deve conter pele menos 1 caracter")
                .HasMaxLen(Descricao,100,"Produto.Descricao","Descrição deve conter no máximo 100 caracteres")
                .HasMinLen(Detalhamento,1,"Produto.Detalhamento","Codigo deve conter pele menos 1 caracter")
                .HasMaxLen(Detalhamento,100,"Produto.Detalhamento","Detalhamento deve conter no máximo 100 caracteres")
            );
        }
    }
}