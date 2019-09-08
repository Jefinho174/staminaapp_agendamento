using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Dommel;
using MySql.Data.MySqlClient;
using StaminaAppAgendamento.Core.Entidades;
using StaminaAppAgendamento.CrossCutting.Configuracoes;
using StaminaAppAgendamento.Dominio.Repositorios;
using StaminaAppAgendamento.Infra.Dto;

namespace StaminaAppAgendamento.Infra.Repositorio
{
    public class BaseDtoRepositorio<EntidadeDominio, DtoModelo> : IBaseRepositorio<EntidadeDominio>
        where EntidadeDominio : Entidade
        where DtoModelo : class
    {

        protected readonly ConexaoDBConfig _config;
        protected readonly IMapper _mapper;
        protected IDto<EntidadeDominio, DtoModelo> Dto;

        public BaseDtoRepositorio(ConexaoDBConfig config, IMapper mapper)
        {
            _mapper = mapper;
            _config = config;
        }

        public bool Delete(int id)
        {
            try
            {
                using (var db = new MySqlConnection(this._config.DBConnectionString))
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
                using (var db = new MySqlConnection(this._config.DBConnectionString))
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
                using (var db = new MySqlConnection(this._config.DBConnectionString))
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
                using (var db = new MySqlConnection(this._config.DBConnectionString))
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
                using (var db = new MySqlConnection(this._config.DBConnectionString))
                {
                    DtoModelo viewModel = (DtoModelo)_mapper.Map<EntidadeDominio, DtoModelo>(entity);
                    db.Insert(viewModel);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(EntidadeDominio entity)
        {
            try
            {
                using (var db = new MySqlConnection(this._config.DBConnectionString))
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