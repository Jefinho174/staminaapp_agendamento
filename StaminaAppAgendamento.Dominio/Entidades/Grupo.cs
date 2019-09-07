using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using StaminaAppAgendamento.Core.Entidades;

namespace StaminaAppAgendamento.Dominio.Entidades
{
    public class Grupo : Entidade
    {
        public string Descricao { get; private set; }

        public Grupo(string descricao)
        {
            Descricao = descricao;
            
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Descricao,1,"Grupo.Descricao","Descrição deve conter pele menos 1 caracter")
                .HasMaxLen(Descricao,1,"Grupo.Descricao","Descrição deve conter no máximo 100 caracteres")
            );
        }
    }
}