using DBClientes.DTOs;
using DBClientes.Repositories;

namespace DBClientes.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteDTO> ObtenerClientePorIdentificacion(string identificacion)
        {
            var cliente = await _clienteRepository.ObtenerPorIdentificacion(identificacion);

            if (cliente == null)
            {
                return null!;
            }

            return new ClienteDTO
            {
                IdCliente = cliente.IdCliente,
                Identificacion = cliente.Identificacion,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Email = cliente.Email,
                FechaCreacion = cliente.FechaCreacion,
                FechaActualizacion = cliente.FechaActualizacion
            };
        }
    }
}
