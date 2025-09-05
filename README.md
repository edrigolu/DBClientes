# DBClientes

# 🚀 API de Gestión de Clientes - Backend

API RESTful desarrollada en .NET 8 para la gestión de clientes con arquitectura por capas y base de datos SQL Server.

## 📦 Tecnologías Utilizadas

- **.NET 8**
- **Entity Framework Core 8**
- **SQL Server 2019**
- **Swagger/OpenAPI**

## 🏗️ Arquitectura
DBClientesSolution/
├── DBClientes.API/ # Capa de presentación
├── DBClientes.Services/ # Lógica de negocio
├── DBClientes.Repositories/ # Acceso a datos
├── DBClientes.Models/ # Entidades EF Core
└── DBClientes.DTOs/ # Objetos transferencia


## 📊 Base de Datos

### Script de creación:
```sql
CREATE DATABASE DBClientes;
GO

USE DBClientes;
GO

CREATE TABLE Clientes (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Identificacion VARCHAR(20) NOT NULL UNIQUE,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    FechaCreacion DATETIME2 DEFAULT GETDATE(),
    FechaActualizacion DATETIME2 DEFAULT GETDATE()
);
GO

-- Insertar datos de ejemplo
INSERT INTO Clientes (Identificacion, Nombre, Apellido, Email) VALUES
('12345678A', 'Juan', 'Pérez', 'juan.perez@email.com'),
('87654321B', 'María', 'Gómez', 'maria.gomez@email.com'),
('11223344C', 'Carlos', 'López', 'carlos.lopez@email.com');
GO

CREATE PROCEDURE spObtenerClientePorIdentificacion
    @Identificacion VARCHAR(20)
AS
BEGIN
    SELECT 
    IdCliente, 
    Identificacion, 
    Nombre, 
    Apellido, 
    Email, 
    FechaCreacion, 
    FechaActualizacion
FROM Clientes  WHERE Identificacion = @Identificacion;
END
GO

🚀 Instalación y Ejecución
Prerrequisitos
.NET 8 SDK

SQL Server 2019+

Visual Studio 2022 o VS Code

Pasos:
1. Clonar repositorio

bash
git clone https://github.com/edrigolu/DBClientes.git

cd DBClientes

2. Restaurar paquetes

bash

dotnet restore

3. Configurar conexión en:  appsettings.json

json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=DBClientes;Integrated Security=true;TrustServerCertificate=true;"
  }
}

4. Ejecutar aplicación

bash
dotnet run --project DBClientes.API

📚 API Endpoints
GET /api/clientes/{identificacion}
Obtiene un cliente por número de identificación.

Response:

json
{
  "idCliente": 1,
  "identificacion": "12345678A",
  "nombre": "Juan",
  "apellido": "Pérez",
  "email": "juan.perez@email.com",
  "fechaCreacion": "2025-09-04T16:14:25.1666667",
  "fechaActualizacion": "2025-09-04T16:14:25.1666667"
}
🔧 Desarrollo
Estructura de capas:
API: Controladores y endpoints

Services: Lógica de negocio

Repositories: Acceso a datos con EF Core

Models: Entidades de base de datos

DTOs: Objetos de transferencia

Patrones utilizados:
Inyección de dependencias

Repository Pattern

Separación de responsabilidades

📊 Swagger Documentation
La documentación interactiva está disponible en:

https://localhost:44324/swagger/index.html





