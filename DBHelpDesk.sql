/*
==============================================================
Proyecto : HelpDesk
Autor    : Dominic Roman
Motor    : SQL Server
Versión  : 1.0
==============================================================
*/

USE master;
GO

IF EXISTS (
    SELECT 1
    FROM sys.databases
    WHERE name = 'HelpDeskDB'
)
BEGIN
    ALTER DATABASE HelpDeskDB
    SET SINGLE_USER
    WITH ROLLBACK IMMEDIATE;

    DROP DATABASE HelpDeskDB;
END
GO

CREATE DATABASE HelpDeskDB;
GO

USE HelpDeskDB;
GO

CREATE TABLE area
(
    id_area INT IDENTITY(1,1),

    area CHAR(4) NOT NULL,
    nombre NVARCHAR(35) NOT NULL,
    activo BIT NOT NULL
        CONSTRAINT DF_area_activo DEFAULT(1),

    usuario_creacion_id INT NOT NULL,
    fecha_creacion DATETIME2(0) NOT NULL
        CONSTRAINT DF_area_fecha_creacion DEFAULT(GETDATE()),

    usuario_modifica_id INT NULL,
    fecha_modifica DATETIME2(0) NULL,

    CONSTRAINT PK_area
        PRIMARY KEY(id_area)
);
GO

CREATE TABLE rol
(
    id_rol INT IDENTITY(1,1),

    nombre NVARCHAR(25) NOT NULL,
    descripcion NVARCHAR(MAX) NULL,

    activo BIT NOT NULL
        CONSTRAINT DF_rol_activo DEFAULT(1),

    CONSTRAINT PK_rol
        PRIMARY KEY(id_rol)
);
GO

CREATE TABLE usuario
(
    id_usuario INT IDENTITY(1,1),

    usuario_login NVARCHAR(25) NOT NULL,
    contrasena NVARCHAR(50) NOT NULL,

    nombres NVARCHAR(25) NOT NULL,
    apellidos NVARCHAR(25) NOT NULL,

    correo NVARCHAR(50) NOT NULL,
    telefono NVARCHAR(11) NULL,

    activo BIT NOT NULL
        CONSTRAINT DF_usuario_activo DEFAULT(1),

    fecha_creacion DATETIME2(0) NOT NULL
        CONSTRAINT DF_usuario_fecha_creacion DEFAULT(GETDATE()),

    id_area INT NOT NULL,

    CONSTRAINT PK_usuario
        PRIMARY KEY(id_usuario),

    CONSTRAINT UQ_usuario_login
        UNIQUE(usuario_login)
);
GO

CREATE TABLE usuario_rol
(
    id_usuario_rol INT IDENTITY(1,1),

    id_usuario INT NOT NULL,
    id_rol INT NOT NULL,

    CONSTRAINT PK_usuario_rol
        PRIMARY KEY(id_usuario_rol)
);
GO

CREATE TABLE estado_ticket
(
    id_estado_ticket INT IDENTITY(1,1),

    estado_ticket CHAR(1) NOT NULL,

    nombre NVARCHAR(25) NOT NULL,

    activo BIT NOT NULL
        CONSTRAINT DF_estado_ticket_activo DEFAULT(1),

    usuario_creacion_id INT NOT NULL,

    fecha_creacion DATETIME2(0) NOT NULL
        CONSTRAINT DF_estado_ticket_fecha DEFAULT(GETDATE()),

    usuario_modifica_id INT NULL,

    fecha_modifica DATETIME2(0) NULL,

    CONSTRAINT PK_estado_ticket
        PRIMARY KEY(id_estado_ticket)
);
GO

CREATE TABLE prioridad
(
    id_prioridad INT IDENTITY(1,1),

    prioridad CHAR(1) NOT NULL,

    nombre NVARCHAR(25) NOT NULL,

    activo BIT NOT NULL
        CONSTRAINT DF_prioridad_activo DEFAULT(1),

    usuario_creacion_id INT NOT NULL,

    fecha_creacion DATETIME2(0) NOT NULL
        CONSTRAINT DF_prioridad_fecha DEFAULT(GETDATE()),

    usuario_modifica_id INT NULL,

    fecha_modifica DATETIME2(0) NULL,

    CONSTRAINT PK_prioridad
        PRIMARY KEY(id_prioridad)
);
GO

CREATE TABLE categoria
(
    id_categoria INT IDENTITY(1,1),

    categoria CHAR(1) NOT NULL,

    nombre NVARCHAR(25) NOT NULL,

    activo BIT NOT NULL
        CONSTRAINT DF_categoria_activo DEFAULT(1),

    usuario_creacion_id INT NOT NULL,

    fecha_creacion DATETIME2(0) NOT NULL
        CONSTRAINT DF_categoria_fecha DEFAULT(GETDATE()),

    usuario_modifica_id INT NULL,

    fecha_modifica DATETIME2(0) NULL,

    CONSTRAINT PK_categoria
        PRIMARY KEY(id_categoria)
);
GO

CREATE TABLE ticket
(
    id_ticket INT IDENTITY(1,1),

    titulo NVARCHAR(25) NOT NULL,
    descripcion NVARCHAR(MAX) NOT NULL,

    usuario_creacion_id INT NOT NULL,

    fecha_creacion DATETIME2(0) NOT NULL
        CONSTRAINT DF_ticket_fecha DEFAULT(GETDATE()),

    usuario_modifica_id INT NULL,

    fecha_modifica DATETIME2(0) NULL,

    correo_solicitante NVARCHAR(25) NULL,

    fecha_cierre DATETIME2(0) NULL,

    id_usuario INT NOT NULL,
    id_prioridad INT NOT NULL,
    id_estado_ticket INT NOT NULL,
    id_categoria INT NOT NULL,
    id_area INT NOT NULL,

    CONSTRAINT PK_ticket
        PRIMARY KEY(id_ticket)
);
GO

CREATE TABLE comentario_ticket
(
    id_comentario INT IDENTITY(1,1),

    comentario NVARCHAR(MAX) NOT NULL,

    usuario_creacion_id INT NOT NULL,

    fecha_creacion DATETIME2(0) NOT NULL
        CONSTRAINT DF_comentario_fecha DEFAULT(GETDATE()),

    fecha_modifica DATETIME2(0) NULL,

    id_ticket INT NOT NULL,

    CONSTRAINT PK_comentario_ticket
        PRIMARY KEY(id_comentario)
);
GO

/**FOREIGN KEYS**/

ALTER TABLE usuario
ADD CONSTRAINT FK_usuario_area
FOREIGN KEY(id_area)
REFERENCES area(id_area);
GO

ALTER TABLE usuario_rol
ADD CONSTRAINT FK_usuario_rol_usuario
FOREIGN KEY(id_usuario)
REFERENCES usuario(id_usuario);
GO

ALTER TABLE usuario_rol
ADD CONSTRAINT FK_usuario_rol_rol
FOREIGN KEY(id_rol)
REFERENCES rol(id_rol);
GO

ALTER TABLE ticket
ADD CONSTRAINT FK_ticket_usuario
FOREIGN KEY(id_usuario)
REFERENCES usuario(id_usuario);
GO

ALTER TABLE ticket
ADD CONSTRAINT FK_ticket_prioridad
FOREIGN KEY(id_prioridad)
REFERENCES prioridad(id_prioridad);
GO

ALTER TABLE ticket
ADD CONSTRAINT FK_ticket_estado
FOREIGN KEY(id_estado_ticket)
REFERENCES estado_ticket(id_estado_ticket);
GO

ALTER TABLE ticket
ADD CONSTRAINT FK_ticket_categoria
FOREIGN KEY(id_categoria)
REFERENCES categoria(id_categoria);
GO

ALTER TABLE ticket
ADD CONSTRAINT FK_ticket_area
FOREIGN KEY(id_area)
REFERENCES area(id_area);
GO

ALTER TABLE comentario_ticket
ADD CONSTRAINT FK_comentario_ticket
FOREIGN KEY(id_ticket)
REFERENCES ticket(id_ticket);
GO