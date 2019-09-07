using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flunt.Notifications;
using MediatR;
using StaminaAppAgendamento.Core.Commands;
using StaminaAppAgendamento.Dominio.Commands.ClienteCommands;
using StaminaAppAgendamento.Dominio.Entidades;
using StaminaAppAgendamento.Dominio.Enums;
using StaminaAppAgendamento.Dominio.ObjetoValores;
using StaminaAppAgendamento.Dominio.Repositorios;

namespace StaminaAppAgendamento.Dominio.Handlers
{
    public class ClienteHandler :
        Notifiable,
        IRequestHandler<CadastrarClienteCommand, CommandResult<Cliente>>
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteHandler(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public Task<CommandResult<Cliente>> Handle(CadastrarClienteCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResult<Cliente>("Salvo com sucesso", true, null);
            request.Validate();
            if (request.Valid)
            {
                Nome nome = new Nome(request.PrimeiroNome, request.SegundoNome);
                Documento documentocliente = null;

                // validar tipo de pessoa
                switch (request.TipoPessoa)
                {
                    case ETipoPessoa.Fisica:
                        documentocliente = new Documento(request.Documento, ETipoDocumento.Cpf);
                        break;
                    case ETipoPessoa.Juridica:
                        documentocliente = new Documento(request.Documento, ETipoDocumento.Cnpj);
                        break;
                }

                // validar se tipo de documento foi definido
                if (documentocliente != null)
                {
                    Cliente cliente = new Cliente(nome, request.TipoPessoa, documentocliente, request.Rg);
                    if (cliente.Valid)
                    {
                        var xx = _clienteRepositorio.GetList(x => x.TipoPessoa == ETipoPessoa.Fisica);
                        var xxxx = _clienteRepositorio.GetList(x => x.Documento.Codigo == "123");
                        if (_clienteRepositorio.ExisteCliente(cliente)){
                            response.Sucesso = false;
                            response.Mensagem = "Cliente já foi cadastrado com esse documento.";
                            return Task.FromResult(response);
                        }
                        if(_clienteRepositorio.Insert(ref cliente)){
                            response.ObjetoResposta = cliente;
                            return Task.FromResult(response);
                        }
                    }
                    response.Notificacoes.AddRange(cliente.Notifications.Select(x => x.Message).ToList());
                }
                AddNotification("TipoPessoa", "Tipo de documento relátivo ao cliente não foi informado.");
            }
            response.Notificacoes.AddRange(request.Notifications.Select(x => x.Message).ToList());
            response.Sucesso = false;
            response.Mensagem = "Não foi possível cadastrar cliente.";
            return Task.FromResult(response);
        }
    }
}