using DBClientes.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DBClientes.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _connectionString;

        public ClienteRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<Cliente> ObtenerPorIdentificacion(string identificacion)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("spObtenerClientePorIdentificacion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Identificacion", identificacion);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Cliente
                            {
                                IdCliente = reader.GetInt32("IdCliente"),
                                Identificacion = reader.GetString("Identificacion"),
                                Nombre = reader.GetString("Nombre"),
                                Apellido = reader.GetString("Apellido"),
                                Email = reader.GetString("Email"),
                                FechaCreacion = reader.GetDateTime("FechaCreacion"),
                                FechaActualizacion = reader.GetDateTime("FechaActualizacion")
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}
