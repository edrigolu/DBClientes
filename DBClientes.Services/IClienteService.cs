using DBClientes.DTOs;

namespace DBClientes.Services
{
    public interface IClienteService
    {
        Task<ClienteDTO> ObtenerClientePorIdentificacion(string identificacion);
    }
}
