USE master
GO

-- Crear base de datos
CREATE DATABASE prueba_tecnica;
GO

USE prueba_tecnica;
GO

-- Tabla: Departamento
CREATE TABLE Departamento (
    IdDepartamento INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL
);
INSERT INTO Departamento(Nombre) VALUES
('Ahuachapán'),
('Cabaáas'),
('Chalatenango'),
('Cuscatlán'),
('La Libertad'),
('La Paz'),
('La Unión'),
('Morazán'),
('San Miguel'),
('San Salvador'),
('San Vicente'),
('Santa Ana'),
('Sonsonate'),
('Usulután');

-- Tabla: Municipio
CREATE TABLE Municipio (
    IdMunicipio INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    IdDepartamento INT NOT NULL,
    FOREIGN KEY (IdDepartamento) REFERENCES Departamento(IdDepartamento)
);
INSERT INTO Municipio(Nombre, IdDepartamento) VALUES
('Ahuachapán Centro', 1),
('Ahuachapán Norte', 1),
('Ahuachapán Sur', 1),
('Cabañas Este', 2),
('Cabañas Oeste', 2),
('Chalatenango Centro', 3),
('Chalatenango Norte', 3),
('Chalatenango Sur', 3),
('Cuscatlán Norte', 4),
('Cuscatlvn Sur', 4),
('La Libertad Centro', 5),
('La Libertad Costa', 5),
('La Libertad Este', 5),
('La Libertad Norte', 5),
('La Libertad Oeste', 5),
('La Libertad Sur', 5),
('La Paz Centro', 6),
('La Paz Este', 6),
('La Paz Oeste', 6),
('La Unión Norte', 7),
('La Unión Sur', 7),
('Morazán Norte', 8),
('Morazán Sur', 8),
('San Miguel Centro', 9),
('San Miguel Norte', 9),
('San Miguel Oeste', 9),
('San Salvador Centro', 10),
('San Salvador Este', 10),
('San Salvador Norte', 10),
('San Salvador Oeste', 10),
('San Salvador Sur', 10),
('San Vicente Norte', 11),
('San Vicente Sur', 11),
('Santa Ana Centro', 12),
('Santa Ana Este', 12),
('Santa Ana Norte', 12),
('Santa Ana Oeste', 12),
('Sonsonate Centro', 13),
('Sonsonate Este', 13),
('Sonsonate Norte', 13),
('Sonsonate Oeste', 13),
('Usulután Este', 14),
('Usulután Norte', 14),
('Usulután Oeste', 14);

-- Tabla: Usuario
CREATE TABLE Usuario (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    CorreoElectronico NVARCHAR(150) NOT NULL,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(256) NOT NULL
);

-- Tabla: Cliente
CREATE TABLE Cliente (
    IdCliente INT PRIMARY KEY IDENTITY(1,1),
    NombreComercial NVARCHAR(150) NOT NULL,
    RazonSocial NVARCHAR(150) NOT NULL,
    Documento NVARCHAR(50) NOT NULL,
    Telefono NVARCHAR(20) NOT NULL,
    CorreoElectronico NVARCHAR(150),
    Direccion NVARCHAR(250),
    Activo CHAR(1) NOT NULL DEFAULT 'S',
    Eliminado CHAR(1) NOT NULL DEFAULT 'N',
    IdMunicipio INT NOT NULL,
    FOREIGN KEY (IdMunicipio) REFERENCES Municipio(IdMunicipio)
);

-- Tabla: BitacoraAccion
CREATE TABLE BitacoraAccion (
    IdBitacoraAccion INT PRIMARY KEY IDENTITY(1,1),
    Operacion NVARCHAR(20) NOT NULL,
    IdCliente INT NOT NULL,
    IdUsuario INT NOT NULL,
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);

INSERT INTO Usuario (Nombre, Apellido, CorreoElectronico, Username, Password)
VALUES ('Administrador', 'Principal', 'admin@prueba.com', 'admin', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', CONVERT(VARBINARY, '4dm1n')), 2));
