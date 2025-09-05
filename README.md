# DBClientes

# 🚀 API de Gestión de Clientes - Backend

API RESTful desarrollada en .NET 8 para la gestión de clientes con arquitectura por capas y base de datos SQL Server.

## 📦 Tecnologías Utilizadas

- **.NET 8**
- **Entity Framework Core 8**
- **SQL Server 2019**
- **Swagger/OpenAPI**
- **Docker** (opcional)

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

