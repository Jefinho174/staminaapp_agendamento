using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Dommel;
using MySql.Data.MySqlClient;
using StaminaAppAgendamento.CrossCutting.Configuracoes;
using StaminaAppAgendamento.Dominio.Entidades;
using StaminaAppAgendamento.Dominio.Repositorios;
using StaminaAppAgendamento.Infra.Dto;

namespace StaminaAppAgendamento.Infra.Repositorio
{
    public class ClienteRepositorio : BaseDtoRepositorio<Cliente, ClienteDto>, IClienteRepositorio
    {
        public ClienteRepositorio(ConexaoDBConfig config, IMapper mapper) : base(config, mapper)
        {
        }

        public bool ExisteCliente(Cliente cliente)
        {
            Expression<Func<ClienteDto, bool>> select = null;
            select = srv => (srv.Documento == cliente.Documento.Codigo && srv.Id != cliente.Id.ToString());
            using (var db = new MySqlConnection(this._config.DBConnectionString)){
                return (db.Select(select).ToList().Any()) ? true : false;
            }
        }
    }
}