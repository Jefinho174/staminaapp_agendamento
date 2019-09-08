using System;
using Flunt.Notifications;

namespace StaminaAppAgendamento.Core.Entidades
{
    public class Entidade : Notifiable
    {
        public Guid Id { get;  set; } = Guid.NewGuid();
        public DateTime DataAtualizacao { get; set; }
        public DateTime? DataFinalizacao { get; set; }

        public Entidade()
        {
            DataAtualizacao = DateTime.Now;
        }

        public void SetGuid(Guid guid){
            Id = guid;
        }
    }
}