using System;
using StaminaAppAgendamento.Core.Entidades;

namespace StaminaAppAgendamento.Dominio.Entidades
{
    public class Login : Entidade
    {
        public string Identificacao { get; private set; }
        public string Usuario { get; private set; }
        public string Senha { get; private set; }
        public int Nivel { get; private set; }
        public DateTime DataCriacao { get; private set; }
    }
}