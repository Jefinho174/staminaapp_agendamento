using Dapper.FluentMap.Dommel.Mapping;
using StaminaAppAgendamento.Infra.Dto;

namespace StaminaAppAgendamento.Infra.DtoMapeamento
{
    public class ClienteDtoMap : DommelEntityMap<ClienteDto>
    {
        public ClienteDtoMap()
        {
            ToTable("Cliente");
            Map(x => x.Id).ToColumn("Id").IsKey().IsIdentity();
            Map(x => x.PrimeiroNome).ToColumn("PrimeiroNome");
            Map(x => x.SegundoNome).ToColumn("SegundoNome");
            Map(x => x.TipoPessoa).ToColumn("TipoPessoa");
            Map(x => x.Documento).ToColumn("Documento");
            Map(x => x.Rg).ToColumn("Rg");
            Map(x => x.DataAtualizacao).ToColumn("DataAtualizacao");
            Map(x => x.DataFinalizacao).ToColumn("DataFinalizacao");
            Map(x => x.Telefones).Ignore();
            Map(x => x.Enderecos).Ignore();
            Map(x => x.Emails).Ignore();
        }
    }
}