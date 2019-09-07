using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using StaminaAppAgendamento.Core.Entidades;
using StaminaAppAgendamento.Dominio.Enums;

namespace StaminaAppAgendamento.Dominio.Entidades
{
    public class Agendamento : Entidade
    {
        public Cliente Cliente { get; private set; }
        public DateTime DataHora { get; private set; }
        public EPeriodo Periodo { get; private set; }
        public Login Login { get; private set; }
        public EStatusAgendamento Status { get; private set; }
        private IList<Servico> _servicos;
        public IReadOnlyCollection<Servico> Servicos { get { return _servicos.ToArray(); } }

        public Agendamento(Cliente cliente,DateTime dataHora, EPeriodo periodo,Login login)
        {
            Cliente = cliente;
            DataHora = dataHora;
            Periodo = periodo;
            Login = login;
            _servicos = new List<Servico>();
            AddNotifications(Cliente,new Contract());
        }

        public void AddServico(Servico servico){
            AddNotifications(servico);
            _servicos.Add(servico);
        }
    }
}