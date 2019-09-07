using System;
using Flunt.Notifications;

namespace StaminaAppAgendamento.Core.Entidades
{
    public class Entidade : Notifiable
    {
        public Guid Id { get;  set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime? DataFinalizacao { get; set; }

        public Entidade()
        {
            Id = Guid.NewGuid();
            DataAtualizacao = DateTime.Now;
        }

        public void SetGuid(Guid guid){
            Id = guid;
        }
    }
}