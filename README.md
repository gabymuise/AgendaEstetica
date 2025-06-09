# 💅 AgendaEstetica

AgendaEstetica es una aplicación de escritorio desarrollada en C# con Windows Forms (WinForms) y Entity Framework Core, pensada para gestionar una agenda de turnos en una estética. Permite organizar citas, clientes, empleados y servicios ofrecidos, centralizando la información en una base de datos SQL Server.

---

## 🚀 Características principales

- Registro y gestión de **clientes**.
- Registro de **empleados** y sus especialidades.
- Administración de **servicios** (nombre, precio, duración, descripción).
- Agenda de **citas** con asignación de horario, cliente, servicio y profesional.
- Gestión del estado de la cita: pagado / finalizado.
- CRUD completo para cada entidad.

---

## 🛠️ Tecnologías utilizadas

- **C#** (Windows Forms)
- **.NET 6 o superior**
- **Entity Framework Core**
- **SQL Server** (Local o en red)
- **MINGW64 / Git Bash** para control de versiones

---

## 📦 Instalación y configuración

### 1. Clonar el repositorio

```bash
git clone https://github.com/tuusuario/AgendaEstetica.git
cd AgendaEstetica

### 2️⃣ Crear la base de datos en SQL Server

Abrí SQL Server Management Studio (SSMS) y ejecutá el siguiente script:

```sql
CREATE DATABASE agendaEstetica;
GO

USE agendaEstetica;
GO

-- Tabla Empleados
CREATE TABLE Empleados (
    idEmpleado INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
    especialidad VARCHAR(100) NOT NULL,
    telefono VARCHAR(20) NOT NULL,
    createdAt DATETIME NOT NULL DEFAULT GETDATE(),
    updatedAt DATETIME NULL,
    deletedAt DATETIME NULL
);
GO

-- Tabla Clientes
CREATE TABLE Clientes (
    idCliente INT PRIMARY KEY IDENTITY(1,1),
    nombreApellido VARCHAR(200) NOT NULL,
    telefono VARCHAR(20) NOT NULL,
    createdAt DATETIME NOT NULL DEFAULT GETDATE(),
    updatedAt DATETIME NULL,
    deletedAt DATETIME NULL
);
GO

-- Tabla Servicios
CREATE TABLE Servicios (
    idServicios INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
    duracionEstimada INT NOT NULL,
    precio DECIMAL(10,2) NOT NULL,
    descripcion TEXT,
    createdAt DATETIME NOT NULL DEFAULT GETDATE(),
    updatedAt DATETIME NULL,
    deletedAt DATETIME NULL
);
GO

-- Tabla HorarioCita
CREATE TABLE HorarioCita (
    idhorarios INT PRIMARY KEY IDENTITY(1,1),
    dia VARCHAR(10) NOT NULL,
    fecha DATE NOT NULL,
    Hora TIME NOT NULL,
    idEmpleado INT NOT NULL,
    disponible BIT DEFAULT 1,
    createdAt DATETIME NOT NULL DEFAULT GETDATE(),
    updatedAt DATETIME NULL,
    deletedAt DATETIME NULL,
    FOREIGN KEY (idEmpleado) REFERENCES Empleados(idEmpleado)
);
GO

-- Tabla AgendaCitas
CREATE TABLE AgendaCitas (
    idAgendaCitas INT PRIMARY KEY IDENTITY(1,1),
    precioFinal DECIMAL(10,2) NOT NULL,
    pagado BIT DEFAULT 0,
    finalizado BIT DEFAULT 0,
    idCliente INT NOT NULL,
    idServicios INT NOT NULL,
    createdAt DATETIME NOT NULL DEFAULT GETDATE(),
    updatedAt DATETIME NULL,
    deletedAt DATETIME NULL,
    FOREIGN KEY (idCliente) REFERENCES Clientes(idCliente),
    FOREIGN KEY (idServicios) REFERENCES Servicios(idServicios)
);
GO

-- Tabla puente AgendaCitas_has_HorarioCitas
CREATE TABLE AgendaCitas_has_HorarioCitas (
    idHorarioCitas INT,
    idAgendaCitas INT,
    createdAt DATETIME NOT NULL DEFAULT GETDATE(),
    PRIMARY KEY (idHorarioCitas, idAgendaCitas),
    FOREIGN KEY (idHorarioCitas) REFERENCES HorarioCita(idhorarios),
    FOREIGN KEY (idAgendaCitas) REFERENCES AgendaCitas(idAgendaCitas)
);
GO
