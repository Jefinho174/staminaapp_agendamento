using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Dommel;
using MySql.Data.MySqlClient;
using StaminaAppAgendamento.Core.Entidades;
using StaminaAppAgendamento.Dominio.Repositorios;
using StaminaAppAgendamento.Infra.Dto;

namespace StaminaAppAgendamento.Infra.Repositorio
{
    public class BaseDtoRepositorio<EntidadeDominio, DtoModelo> : IBaseRepositorio<EntidadeDominio>
        where EntidadeDominio : Entidade
        where DtoModelo : class
    {

        public string StringConeccaoBanco { get; private set; }
        public readonly IMapper _mapper;
        public IDto<EntidadeDominio, DtoModelo> Dto;

        public BaseDtoRepositorio(string stringConeccaoBanco, IMapper mapper)
        {
            _mapper = mapper;
            StringConeccaoBanco = stringConeccaoBanco;
        }

        public bool Delete(int id)
        {
            try
            {
                using (var db = new MySqlConnection(StringConeccaoBanco))
                {
                    var entity = GetById(id);
                    if (entity == null)
                    {
                        return db.Delete(entity);
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<EntidadeDominio> GetAll()
        {
            try
            {
                using (var db = new MySqlConnection(StringConeccaoBanco))
                {
                    var dbresult = db.GetAll<DtoModelo>();
                    return _mapper.Map<IEnumerable<EntidadeDominio>>(dbresult);
                }
            }
            catch (Exception)
            {
                return default(List<EntidadeDominio>);
            }
        }

        public EntidadeDominio GetById(int id)
        {
            try
            {
                using (var db = new MySqlConnection(StringConeccaoBanco))
                {
                    var dbresult = db.Get<DtoModelo>(id);
                    return _mapper.Map<EntidadeDominio>(dbresult);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<EntidadeDominio> GetList(Expression<Func<EntidadeDominio, bool>> predicate)
        {
            try
            {
                using (var db = new MySqlConnection(StringConeccaoBanco))
                {
                    Expression<Func<DtoModelo, bool>> expression = (Expression<Func<DtoModelo, bool>>) _mapper.Map<Expression<Func<EntidadeDominio, bool>>,Expression<Func<DtoModelo, bool>>>(predicate);
                    var xx = db.Select<DtoModelo>(expression);
                    
                    return default(List<EntidadeDominio>);
                }
            }
            catch (Exception ex)
            {
                return default(List<EntidadeDominio>);
            }

        }

        public bool Insert(ref EntidadeDominio entity)
        {
            try
            {
                using (var db = new MySqlConnection(StringConeccaoBanco))
                {
                    DtoModelo viewModel = (DtoModelo)_mapper.Map<EntidadeDominio, DtoModelo>(entity);
                    db.Insert(viewModel);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(EntidadeDominio entity)
        {
            try
            {
                using (var db = new MySqlConnection(StringConeccaoBanco))
                {
                    DtoModelo viewModel = (DtoModelo)_mapper.Map<EntidadeDominio, DtoModelo>(entity);
                    return db.Update(viewModel);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}