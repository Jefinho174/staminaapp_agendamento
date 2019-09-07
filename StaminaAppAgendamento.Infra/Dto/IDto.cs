using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using StaminaAppAgendamento.Core.Entidades;

namespace StaminaAppAgendamento.Infra.Dto
{
    public abstract class IDto<EntidadeDominio,Dto> where EntidadeDominio : Entidade where  Dto : class
    {
        public abstract EntidadeDominio ConvertToDominio(Dto dto);
        public abstract Dto ConvertToDto(EntidadeDominio modelo);
        public abstract IEnumerable<EntidadeDominio> ConvertToListDominio(IEnumerable<Dto> listDto);
        public abstract Expression<Func<Dto, bool>> ConvertToExpressionDto(Expression<Func<EntidadeDominio, bool>> predicate);
    }
}