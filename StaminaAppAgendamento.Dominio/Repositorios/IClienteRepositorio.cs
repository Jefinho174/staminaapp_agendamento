using StaminaAppAgendamento.Dominio.Entidades;

namespace StaminaAppAgendamento.Dominio.Repositorios
{
    public interface IClienteRepositorio : IBaseRepositorio<Cliente>
    {
        bool ExisteCliente(Cliente cliente);
    }
}