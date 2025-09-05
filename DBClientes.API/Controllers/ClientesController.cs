using DBClientes.DTOs;
using DBClientes.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation( // Documentación Swagger
            Summary = "Obtiene un cliente por número de identificación",
            Description = "Retorna los datos completos del cliente si existe, o 404 si no se encuentra",
            OperationId = "GetClienteByIdentificacion",
            Tags = new[] { "Clientes" })]
        [SwaggerResponse(200, "Cliente encontrado", typeof(ClienteDTO))]
        [SwaggerResponse(404, "Cliente no encontrado")]
        [SwaggerResponse(500, "Error interno del servidor")]
        public async Task<IActionResult> ObtenerClientePorIdentificacion([SwaggerParameter("Número de identificación del cliente", Required = true)] string identificacion)
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
