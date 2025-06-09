# 💅 AgendaEstetica

**AgendaEstetica** es una aplicación de escritorio desarrollada en **C# (WinForms)** con **Entity Framework Core** y **SQL Server** como base de datos. El sistema permite gestionar turnos, empleados, clientes y servicios de una estética o centro de belleza, facilitando la organización diaria y el seguimiento de citas.

---

## 🚀 Características principales

- ✅ Gestión de **Clientes** (nombre, teléfono)
- ✅ Gestión de **Empleados** (nombre, especialidad, teléfono)
- ✅ Registro de **Servicios** (nombre, precio, duración, descripción)
- ✅ Administración de **Horarios de Cita**
- ✅ Creación de **Agenda de Citas** vinculadas a clientes, empleados y servicios
- ✅ Seguimiento del estado de la cita (pagada, finalizada)
- ✅ Asociación entre horarios y citas (relación muchos a muchos)

---

## 🛠️ Tecnologías utilizadas

- 💻 **Lenguaje:** C# (.NET 6 o superior)
- 🖼️ **Interfaz gráfica:** Windows Forms
- 🗃️ **Base de datos:** SQL Server
- 🧠 **ORM:** Entity Framework Core
- ⚙️ **IDE recomendado:** Visual Studio 2022
- 🐙 **Control de versiones:** Git + Git Bash (MINGW64)

---

## 📦 Instalación y configuración

### 1. Clonar el repositorio

```bash
git clone https://github.com/gabymuise/AgendaEstetica.git
cd AgendaEstetica
```

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
```

