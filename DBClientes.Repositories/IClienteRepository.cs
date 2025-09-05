using DBClientes.Models;

namespace DBClientes.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> ObtenerPorIdentificacion(string identificacion);
    }
}
