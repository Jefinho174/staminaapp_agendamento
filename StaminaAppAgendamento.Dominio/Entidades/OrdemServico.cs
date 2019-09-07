using System;
using System.Collections.Generic;
using System.Linq;
using StaminaAppAgendamento.Core.Entidades;

namespace StaminaAppAgendamento.Dominio.Entidades
{
    public class OrdemServico : Entidade
    {
        public int Numero { get; private set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Descricao { get; private set; }
        private IList<Servico> _servicos;
        public IReadOnlyCollection<Servico> Servicos { get { return _servicos.ToArray(); } }

        public OrdemServico(int numero, DateTime dataInicio, DateTime dataFim, string descricao, decimal valorTotal, decimal valorDesconto)
        {
            Numero = numero;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Descricao = descricao;
        }

        public void AddServico(Servico servico){
            AddNotifications(servico);
            _servicos.Add(servico);
        }

    }
}