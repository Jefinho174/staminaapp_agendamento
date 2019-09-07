using Flunt.Validations;
using StaminaAppAgendamento.Core.Entidades;

namespace StaminaAppAgendamento.Dominio.Entidades
{
    public class Categoria : Entidade
    {
        public string Descricao { get; private set; }
        public Grupo Grupo { get; private set; }
        public SubGrupo SubGrupo { get; private set; }
        public Familia Familia { get; private set; }

        public Categoria(string descricao, Grupo grupo, SubGrupo subGrupo, Familia familia)
        {
            Descricao = descricao;
            Grupo = grupo;
            SubGrupo = subGrupo;
            Familia = familia;

            AddNotifications(Grupo,SubGrupo,Familia, new Contract()
                .Requires()
                .HasMinLen(Descricao,1,"Categoria.Descricao","Descrição deve conter pele menos 1 caracter")
                .HasMaxLen(Descricao,1,"Categoria.Descricao","Descrição deve conter no máximo 100 caracteres")
            );
        }
    }
}