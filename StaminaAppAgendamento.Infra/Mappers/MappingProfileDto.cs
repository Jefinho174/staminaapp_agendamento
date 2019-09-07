using System;
using System.Linq.Expressions;
using AutoMapper;
using StaminaAppAgendamento.Dominio.Entidades;
using StaminaAppAgendamento.Dominio.Enums;
using StaminaAppAgendamento.Dominio.ObjetoValores;
using StaminaAppAgendamento.Infra.Dto;

namespace StaminaAppAgendamento.Infra.Mappers
{
    public class MappingProfileDto : Profile
    {

        public MappingProfileDto(){

            // CreateMap<Telefone,ClienteTelefoneDto>();
            // CreateMap<ClienteTelefoneDto,Telefone>();

            // CreateMap<Cliente,ClienteEmailDto>();
            // CreateMap<ClienteEmailDto,Cliente>();

            // CreateMap<Endereco,ClienteEnderecoDto>();
            // CreateMap<ClienteEnderecoDto,Endereco>();
            CreateMap<Cliente,ClienteDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.PrimeiroNome, opt => opt.MapFrom(src => src.Nome.PrimeiroNome))
                .ForMember(dest => dest.SegundoNome, opt => opt.MapFrom(src => src.Nome.SegundoNome))
                .ForMember(dest => dest.Documento, opt => opt.MapFrom(src => src.Documento.Codigo));
            
            CreateMap<ClienteDto,Cliente>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)))
                .ForPath(dest => dest.Documento.Codigo , opt => opt.MapFrom(src => src.Documento))
                .ForCtorParam("documento", opt => opt.MapFrom(src => src.TipoPessoa.Equals(ETipoPessoa.Juridica)
                                                                                ? new Documento(src.Documento, ETipoDocumento.Cnpj)
                                                                                : new Documento(src.Documento, ETipoDocumento.Cpf)))
                .ForCtorParam("nome", opt => opt.MapFrom(src => new Nome(src.PrimeiroNome, src.SegundoNome)));
        }

    }
}