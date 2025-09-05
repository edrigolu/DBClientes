using DBClientes.DTOs;
using DBClientes.Services;
using Microsoft.AspNetCore.Mvc;

namespace DBClientes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("{identificacion}")]
        public async Task<IActionResult> ObtenerClientePorIdentificacion(string identificacion)
        {
            ClienteDTO cliente = await _clienteService.ObtenerClientePorIdentificacion(identificacion);

            if (cliente == null)
            {
                return NotFound(new { message = "Cliente no encontrado" });
            }

            return Ok(cliente);
        }
    }
}
