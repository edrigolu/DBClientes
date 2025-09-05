using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace DBClientes.DTOs
{
    [SwaggerSchema("DTO para representar un cliente")]
    public class ClienteDTO
    {
        [SwaggerSchema("ID único del cliente")]
        public int IdCliente { get; set; }

        [Required]
        [SwaggerSchema("Número de identificación del cliente", Format = "varchar(20)")]
        public string? Identificacion { get; set; }

        [Required]
        [SwaggerSchema("Nombre del cliente", Format = "varchar(100)")]
        public string? Nombre { get; set; }

        [Required]
        [SwaggerSchema("Apellido del cliente", Format = "varchar(100)")]
        public string? Apellido { get; set; }

        [Required]
        [EmailAddress]
        [SwaggerSchema("Correo del cliente", Format = "varchar(255)")]
        public string? Email { get; set; }

        [SwaggerSchema("Fecha de creación del registro")]
        public DateTime FechaCreacion { get; set; }

        [SwaggerSchema("Fecha de última actualización")]
        public DateTime FechaActualizacion { get; set; }

    }
}
