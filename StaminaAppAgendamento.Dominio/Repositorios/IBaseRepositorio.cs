using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using StaminaAppAgendamento.Core.Entidades;

namespace StaminaAppAgendamento.Dominio.Repositorios
{

    public interface IBaseRepositorio<TEntidade> where TEntidade : Entidade
    {
        IEnumerable<TEntidade> GetAll();
        TEntidade GetById(int id);
        bool Insert(ref TEntidade entity);
        bool Update(TEntidade entity);
        bool Delete(int id);
        IEnumerable<TEntidade> GetList(Expression<Func<TEntidade, bool>> predicate);
    }
}