IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [cat_tipos_estatus] (
    [IdTipoEstatus] int NOT NULL IDENTITY,
    [DesTipoEstatus] nvarchar(30) NOT NULL,
    [Activo] nvarchar(1) NOT NULL,
    CONSTRAINT [PK_cat_tipos_estatus] PRIMARY KEY ([IdTipoEstatus])
);

GO

CREATE TABLE [cat_tipos_generales] (
    [IdTipoGeneral] int NOT NULL IDENTITY,
    [DesTipo] nvarchar(100) NOT NULL,
    [Activo] nvarchar(1) NOT NULL,
    CONSTRAINT [PK_cat_tipos_generales] PRIMARY KEY ([IdTipoGeneral])
);

GO

CREATE TABLE [eva_cat_edificios] (
    [IdEdificio] int NOT NULL IDENTITY,
    [Clave] nvarchar(20) NOT NULL,
    [Alias] nvarchar(10) NOT NULL,
    [DesEdificio] nvarchar(50) NOT NULL,
    [Prioridad] int NOT NULL,
    CONSTRAINT [PK_eva_cat_edificios] PRIMARY KEY ([IdEdificio])
);

GO

CREATE TABLE [rh_cat_personas] (
    [IdPersona] int NOT NULL IDENTITY,
    [IdInstituto] int NOT NULL,
    [NumControl] nvarchar(20) NOT NULL,
    [Nombre] nvarchar(100) NOT NULL,
    [ApPaterno] nvarchar(60) NULL,
    [ApMaterno] nvarchar(60) NULL,
    [RFC] nvarchar(10) NULL,
    [CURP] nvarchar(25) NOT NULL,
    [TipoPersona] nvarchar(1) NOT NULL,
    [Sexo] nvarchar(1) NOT NULL,
    [RutaFoto] nvarchar(255) NULL,
    [Alias] nvarchar(20) NULL,
    [FechaNac] datetime2 NOT NULL,
    CONSTRAINT [PK_rh_cat_personas] PRIMARY KEY ([IdPersona])
);

GO

CREATE TABLE [cat_estatus] (
    [IdTipoEstatus] int NOT NULL,
    [IdEstatus] int NOT NULL IDENTITY,
    [Clave] nvarchar(50) NOT NULL,
    [DesEstatus] nvarchar(30) NOT NULL,
    [Activo] nvarchar(1) NOT NULL,
    CONSTRAINT [PK_cat_estatus] PRIMARY KEY ([IdTipoEstatus], [IdEstatus]),
    CONSTRAINT [AK_cat_estatus_IdEstatus] UNIQUE ([IdEstatus]),
    CONSTRAINT [FK_cat_estatus_cat_tipos_estatus_IdTipoEstatus] FOREIGN KEY ([IdTipoEstatus]) REFERENCES [cat_tipos_estatus] ([IdTipoEstatus]) ON DELETE CASCADE
);

GO

CREATE TABLE [cat_generales] (
    [IdTipoGeneral] int NOT NULL,
    [IdGeneral] int NOT NULL IDENTITY,
    [Clave] nvarchar(20) NOT NULL,
    [DesGeneral] nvarchar(100) NOT NULL,
    [Activo] nvarchar(1) NOT NULL,
    CONSTRAINT [PK_cat_generales] PRIMARY KEY ([IdTipoGeneral], [IdGeneral]),
    CONSTRAINT [AK_cat_generales_IdGeneral] UNIQUE ([IdGeneral]),
    CONSTRAINT [FK_cat_generales_cat_tipos_generales_IdTipoGeneral] FOREIGN KEY ([IdTipoGeneral]) REFERENCES [cat_tipos_generales] ([IdTipoGeneral]) ON DELETE CASCADE
);

GO

CREATE TABLE [eva_cat_espacios] (
    [IdEdificio] int NOT NULL,
    [IdEspacio] int NOT NULL IDENTITY,
    [Clave] nvarchar(20) NOT NULL,
    [Alias] nvarchar(10) NOT NULL,
    [DesEspacio] nvarchar(50) NOT NULL,
    [Capacidad] int NOT NULL,
    [Prioridad] int NOT NULL,
    CONSTRAINT [PK_eva_cat_espacios] PRIMARY KEY ([IdEdificio], [IdEspacio]),
    CONSTRAINT [AK_eva_cat_espacios_IdEspacio] UNIQUE ([IdEspacio]),
    CONSTRAINT [FK_eva_cat_espacios_eva_cat_edificios_IdEdificio] FOREIGN KEY ([IdEdificio]) REFERENCES [eva_cat_edificios] ([IdEdificio]) ON DELETE CASCADE
);

GO

CREATE TABLE [cat_productos_servicios] (
    [IdProdServ] int NOT NULL IDENTITY,
    [ClaveProdServ] nvarchar(20) NOT NULL,
    [CodigoBarras] nvarchar(50) NOT NULL,
    [DesProdServ] nvarchar(200) NOT NULL,
    [ProductoServicio] nvarchar(1) NOT NULL,
    [IdTipoGenProdServ] int NOT NULL,
    [cat_tipos_generalesIdTipoGeneral] int NULL,
    [IdGenProdServ] int NOT NULL,
    [cat_generalesIdTipoGeneral] int NULL,
    [cat_generalesIdGeneral] int NULL,
    CONSTRAINT [PK_cat_productos_servicios] PRIMARY KEY ([IdProdServ]),
    CONSTRAINT [FK_cat_productos_servicios_cat_tipos_generales_cat_tipos_generalesIdTipoGeneral] FOREIGN KEY ([cat_tipos_generalesIdTipoGeneral]) REFERENCES [cat_tipos_generales] ([IdTipoGeneral]) ON DELETE NO ACTION,
    CONSTRAINT [FK_cat_productos_servicios_cat_generales_cat_generalesIdTipoGeneral_cat_generalesIdGeneral] FOREIGN KEY ([cat_generalesIdTipoGeneral], [cat_generalesIdGeneral]) REFERENCES [cat_generales] ([IdTipoGeneral], [IdGeneral]) ON DELETE NO ACTION
);

GO

CREATE TABLE [res_eventos] (
    [IdEvento] int NOT NULL IDENTITY,
    [IdTipoGenEvento] int NOT NULL,
    [cat_tipos_generalesIdTipoGeneral] int NULL,
    [IdGenEvento] int NOT NULL,
    [cat_generalesIdTipoGeneral] int NULL,
    [cat_generalesIdGeneral] int NULL,
    [IdPersonaReg] int NOT NULL,
    [rh_cat_personasIdPersona] int NULL,
    [NombreEvento] nvarchar(1000) NOT NULL,
    [Observacion] nvarchar(1000) NULL,
    [Explicacion] nvarchar(3000) NULL,
    [URL] nvarchar(1000) NOT NULL,
    [FechaIn] datetime2 NOT NULL,
    [FechaFin] datetime2 NOT NULL,
    [IdEdificio] int NOT NULL,
    [FechaReg] datetime2 NOT NULL,
    [UsuarioReg] int NOT NULL,
    CONSTRAINT [PK_res_eventos] PRIMARY KEY ([IdEvento]),
    CONSTRAINT [FK_res_eventos_eva_cat_edificios_IdEdificio] FOREIGN KEY ([IdEdificio]) REFERENCES [eva_cat_edificios] ([IdEdificio]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_eventos_cat_tipos_generales_cat_tipos_generalesIdTipoGeneral] FOREIGN KEY ([cat_tipos_generalesIdTipoGeneral]) REFERENCES [cat_tipos_generales] ([IdTipoGeneral]) ON DELETE NO ACTION,
    CONSTRAINT [FK_res_eventos_rh_cat_personas_rh_cat_personasIdPersona] FOREIGN KEY ([rh_cat_personasIdPersona]) REFERENCES [rh_cat_personas] ([IdPersona]) ON DELETE NO ACTION,
    CONSTRAINT [FK_res_eventos_cat_generales_cat_generalesIdTipoGeneral_cat_generalesIdGeneral] FOREIGN KEY ([cat_generalesIdTipoGeneral], [cat_generalesIdGeneral]) REFERENCES [cat_generales] ([IdTipoGeneral], [IdGeneral]) ON DELETE NO ACTION
);

GO

CREATE TABLE [res_cat_zonas] (
    [IdEdificio] int NOT NULL,
    [IdEspacio] int NOT NULL,
    [IdZona] int NOT NULL IDENTITY,
    [DesZona] nvarchar(225) NOT NULL,
    [CapacidadPer] int NOT NULL,
    [Filas] int NOT NULL,
    [AsientosPorFila] int NOT NULL,
    CONSTRAINT [PK_res_cat_zonas] PRIMARY KEY ([IdEdificio], [IdEspacio], [IdZona]),
    CONSTRAINT [AK_res_cat_zonas_IdZona] UNIQUE ([IdZona]),
    CONSTRAINT [FK_res_cat_zonas_eva_cat_edificios_IdEdificio] FOREIGN KEY ([IdEdificio]) REFERENCES [eva_cat_edificios] ([IdEdificio]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_cat_zonas_eva_cat_espacios_IdEdificio_IdEspacio] FOREIGN KEY ([IdEdificio], [IdEspacio]) REFERENCES [eva_cat_espacios] ([IdEdificio], [IdEspacio]) ON DELETE CASCADE
);

GO

CREATE TABLE [cat_prod_serv_especifico] (
    [IdProdServ] int NOT NULL,
    [IdProdServEsp] int NOT NULL IDENTITY,
    [ClaveProdServEsp] nvarchar(20) NOT NULL,
    [DesProdServEsp] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_cat_prod_serv_especifico] PRIMARY KEY ([IdProdServ], [IdProdServEsp]),
    CONSTRAINT [AK_cat_prod_serv_especifico_IdProdServEsp] UNIQUE ([IdProdServEsp]),
    CONSTRAINT [FK_cat_prod_serv_especifico_cat_productos_servicios_IdProdServ] FOREIGN KEY ([IdProdServ]) REFERENCES [cat_productos_servicios] ([IdProdServ]) ON DELETE CASCADE
);

GO

CREATE TABLE [res_evento_clientes] (
    [IdEvento] int NOT NULL,
    [IdReservaCliente] int NOT NULL IDENTITY,
    [IdClienteReserva] int NOT NULL,
    [FechaRegistro] datetime2 NOT NULL,
    CONSTRAINT [PK_res_evento_clientes] PRIMARY KEY ([IdEvento], [IdReservaCliente]),
    CONSTRAINT [AK_res_evento_clientes_IdReservaCliente] UNIQUE ([IdReservaCliente]),
    CONSTRAINT [FK_res_evento_clientes_res_eventos_IdEvento] FOREIGN KEY ([IdEvento]) REFERENCES [res_eventos] ([IdEvento]) ON DELETE CASCADE
);

GO

CREATE TABLE [res_evento_estatus] (
    [IdEvento] int NOT NULL,
    [IdEstatusDet] int NOT NULL IDENTITY,
    [FechaEstatus] datetime2 NOT NULL,
    [IdTipoEstatus] int NOT NULL,
    [IdEstatus] int NOT NULL,
    [Actual] nvarchar(1) NOT NULL,
    [Observacion] nvarchar(500) NULL,
    [UsuarioReg] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_res_evento_estatus] PRIMARY KEY ([IdEvento], [IdEstatusDet]),
    CONSTRAINT [AK_res_evento_estatus_IdEstatusDet] UNIQUE ([IdEstatusDet]),
    CONSTRAINT [FK_res_evento_estatus_res_eventos_IdEvento] FOREIGN KEY ([IdEvento]) REFERENCES [res_eventos] ([IdEvento]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_evento_estatus_cat_tipos_estatus_IdTipoEstatus] FOREIGN KEY ([IdTipoEstatus]) REFERENCES [cat_tipos_estatus] ([IdTipoEstatus]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_evento_estatus_cat_estatus_IdTipoEstatus_IdEstatus] FOREIGN KEY ([IdTipoEstatus], [IdEstatus]) REFERENCES [cat_estatus] ([IdTipoEstatus], [IdEstatus]) ON DELETE CASCADE
);

GO

CREATE TABLE [res_evento_horarios] (
    [IdEvento] int NOT NULL,
    [IdHorarioDet] int NOT NULL IDENTITY,
    [IdEdificio] int NOT NULL,
    [IdEspacio] int NOT NULL,
    [Dia] nvarchar(10) NOT NULL,
    [FechaHoraIni] datetime2 NOT NULL,
    [FechaHoraFin] datetime2 NOT NULL,
    [Disponible] nvarchar(1) NOT NULL,
    [FechaReg] datetime2 NOT NULL,
    [UsuarioReg] nvarchar(18) NOT NULL,
    CONSTRAINT [PK_res_evento_horarios] PRIMARY KEY ([IdEvento], [IdHorarioDet]),
    CONSTRAINT [AK_res_evento_horarios_IdHorarioDet] UNIQUE ([IdHorarioDet]),
    CONSTRAINT [FK_res_evento_horarios_eva_cat_edificios_IdEdificio] FOREIGN KEY ([IdEdificio]) REFERENCES [eva_cat_edificios] ([IdEdificio]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_evento_horarios_res_eventos_IdEvento] FOREIGN KEY ([IdEvento]) REFERENCES [res_eventos] ([IdEvento]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_evento_horarios_eva_cat_espacios_IdEdificio_IdEspacio] FOREIGN KEY ([IdEdificio], [IdEspacio]) REFERENCES [eva_cat_espacios] ([IdEdificio], [IdEspacio]) ON DELETE CASCADE
);

GO

CREATE TABLE [res_evento_zona_boletos] (
    [IdBoleto] int NOT NULL IDENTITY,
    [IdEvento] int NOT NULL,
    [IdEdificio] int NOT NULL,
    [IdEspacio] int NOT NULL,
    [IdZona] int NOT NULL,
    [NumBoleto] nvarchar(20) NOT NULL,
    [DesBoleto] nvarchar(20) NOT NULL,
    [Precio] real NOT NULL,
    [IVA] real NOT NULL,
    [Ubicacion] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_res_evento_zona_boletos] PRIMARY KEY ([IdBoleto]),
    CONSTRAINT [FK_res_evento_zona_boletos_eva_cat_edificios_IdEdificio] FOREIGN KEY ([IdEdificio]) REFERENCES [eva_cat_edificios] ([IdEdificio]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_evento_zona_boletos_res_eventos_IdEvento] FOREIGN KEY ([IdEvento]) REFERENCES [res_eventos] ([IdEvento]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_evento_zona_boletos_eva_cat_espacios_IdEdificio_IdEspacio] FOREIGN KEY ([IdEdificio], [IdEspacio]) REFERENCES [eva_cat_espacios] ([IdEdificio], [IdEspacio]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_evento_zona_boletos_res_cat_zonas_IdEdificio_IdEspacio_IdZona] FOREIGN KEY ([IdEdificio], [IdEspacio], [IdZona]) REFERENCES [res_cat_zonas] ([IdEdificio], [IdEspacio], [IdZona]) ON DELETE CASCADE
);

GO

CREATE TABLE [res_evento_zonas] (
    [IdEdificio] int NOT NULL,
    [IdEspacio] int NOT NULL,
    [IdEvento] int NOT NULL,
    [IdZona] int NOT NULL,
    [FechaReg] datetime2 NOT NULL,
    [UsuarioReg] nvarchar(20) NOT NULL,
    [RutaImagen] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_res_evento_zonas] PRIMARY KEY ([IdEdificio], [IdEspacio], [IdEvento], [IdZona]),
    CONSTRAINT [FK_res_evento_zonas_eva_cat_edificios_IdEdificio] FOREIGN KEY ([IdEdificio]) REFERENCES [eva_cat_edificios] ([IdEdificio]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_evento_zonas_res_eventos_IdEvento] FOREIGN KEY ([IdEvento]) REFERENCES [res_eventos] ([IdEvento]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_evento_zonas_eva_cat_espacios_IdEdificio_IdEspacio] FOREIGN KEY ([IdEdificio], [IdEspacio]) REFERENCES [eva_cat_espacios] ([IdEdificio], [IdEspacio]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_evento_zonas_res_cat_zonas_IdEdificio_IdEspacio_IdZona] FOREIGN KEY ([IdEdificio], [IdEspacio], [IdZona]) REFERENCES [res_cat_zonas] ([IdEdificio], [IdEspacio], [IdZona]) ON DELETE CASCADE
);

GO

CREATE TABLE [res_evento_servicios] (
    [IdEvento] int NOT NULL,
    [Requerido] nvarchar(1) NOT NULL,
    [IdProdServ] int NOT NULL,
    [IdProdServEsp] int NOT NULL,
    CONSTRAINT [PK_res_evento_servicios] PRIMARY KEY ([IdEvento], [IdProdServ], [IdProdServEsp]),
    CONSTRAINT [FK_res_evento_servicios_res_eventos_IdEvento] FOREIGN KEY ([IdEvento]) REFERENCES [res_eventos] ([IdEvento]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_evento_servicios_cat_productos_servicios_IdProdServ] FOREIGN KEY ([IdProdServ]) REFERENCES [cat_productos_servicios] ([IdProdServ]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_evento_servicios_cat_prod_serv_especifico_IdProdServ_IdProdServEsp] FOREIGN KEY ([IdProdServ], [IdProdServEsp]) REFERENCES [cat_prod_serv_especifico] ([IdProdServ], [IdProdServEsp]) ON DELETE CASCADE
);

GO

CREATE TABLE [res_zonas_servicios] (
    [IdEdificio] int NOT NULL,
    [IdEspacio] int NOT NULL,
    [IdZona] int NOT NULL,
    [IdProdServ] int NOT NULL,
    [IdProdServEsp] int NOT NULL,
    CONSTRAINT [PK_res_zonas_servicios] PRIMARY KEY ([IdEdificio], [IdEspacio], [IdZona], [IdProdServ], [IdProdServEsp]),
    CONSTRAINT [AK_res_zonas_servicios_IdEdificio_IdEspacio_IdProdServ_IdProdServEsp_IdZona] UNIQUE ([IdEdificio], [IdEspacio], [IdProdServ], [IdProdServEsp], [IdZona]),
    CONSTRAINT [FK_res_zonas_servicios_eva_cat_edificios_IdEdificio] FOREIGN KEY ([IdEdificio]) REFERENCES [eva_cat_edificios] ([IdEdificio]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_zonas_servicios_cat_productos_servicios_IdProdServ] FOREIGN KEY ([IdProdServ]) REFERENCES [cat_productos_servicios] ([IdProdServ]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_zonas_servicios_eva_cat_espacios_IdEdificio_IdEspacio] FOREIGN KEY ([IdEdificio], [IdEspacio]) REFERENCES [eva_cat_espacios] ([IdEdificio], [IdEspacio]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_zonas_servicios_cat_prod_serv_especifico_IdProdServ_IdProdServEsp] FOREIGN KEY ([IdProdServ], [IdProdServEsp]) REFERENCES [cat_prod_serv_especifico] ([IdProdServ], [IdProdServEsp]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_zonas_servicios_res_cat_zonas_IdEdificio_IdEspacio_IdZona] FOREIGN KEY ([IdEdificio], [IdEspacio], [IdZona]) REFERENCES [res_cat_zonas] ([IdEdificio], [IdEspacio], [IdZona]) ON DELETE CASCADE
);

GO

CREATE TABLE [res_evento_cliente_prod_serv] (
    [IdEvento] int NOT NULL,
    [IdReservaCliente] int NOT NULL,
    [IdReservaServDet] int NOT NULL IDENTITY,
    [IdProdServ] int NOT NULL,
    [IdProdServEsp] int NOT NULL,
    [Cantidad] real NOT NULL,
    [Precio] real NOT NULL,
    [IVA] real NOT NULL,
    [IdUnidadMedida] int NOT NULL,
    [Importe] real NOT NULL,
    CONSTRAINT [PK_res_evento_cliente_prod_serv] PRIMARY KEY ([IdEvento], [IdReservaCliente], [IdReservaServDet]),
    CONSTRAINT [AK_res_evento_cliente_prod_serv_IdReservaServDet] UNIQUE ([IdReservaServDet]),
    CONSTRAINT [FK_res_evento_cliente_prod_serv_res_eventos_IdEvento] FOREIGN KEY ([IdEvento]) REFERENCES [res_eventos] ([IdEvento]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_evento_cliente_prod_serv_cat_productos_servicios_IdProdServ] FOREIGN KEY ([IdProdServ]) REFERENCES [cat_productos_servicios] ([IdProdServ]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_evento_cliente_prod_serv_res_evento_clientes_IdEvento_IdReservaCliente] FOREIGN KEY ([IdEvento], [IdReservaCliente]) REFERENCES [res_evento_clientes] ([IdEvento], [IdReservaCliente]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_evento_cliente_prod_serv_cat_prod_serv_especifico_IdProdServ_IdProdServEsp] FOREIGN KEY ([IdProdServ], [IdProdServEsp]) REFERENCES [cat_prod_serv_especifico] ([IdProdServ], [IdProdServEsp]) ON DELETE CASCADE
);

GO

CREATE TABLE [res_evento_cliente_boletos] (
    [IdReservaCliente] int NOT NULL,
    [IdEvento] int NOT NULL,
    [IdBoleto] int NOT NULL,
    [IdPersona] int NOT NULL,
    [ConfirmaAsistencia] nvarchar(max) NULL,
    [Nombre] nvarchar(60) NOT NULL,
    CONSTRAINT [PK_res_evento_cliente_boletos] PRIMARY KEY ([IdReservaCliente], [IdEvento], [IdBoleto]),
    CONSTRAINT [FK_res_evento_cliente_boletos_res_evento_zona_boletos_IdBoleto] FOREIGN KEY ([IdBoleto]) REFERENCES [res_evento_zona_boletos] ([IdBoleto]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_evento_cliente_boletos_res_eventos_IdEvento] FOREIGN KEY ([IdEvento]) REFERENCES [res_eventos] ([IdEvento]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_evento_cliente_boletos_rh_cat_personas_IdPersona] FOREIGN KEY ([IdPersona]) REFERENCES [rh_cat_personas] ([IdPersona]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_evento_cliente_boletos_res_evento_clientes_IdEvento_IdReservaCliente] FOREIGN KEY ([IdEvento], [IdReservaCliente]) REFERENCES [res_evento_clientes] ([IdEvento], [IdReservaCliente]) ON DELETE CASCADE
);

GO

CREATE TABLE [res_evento_zona_boleto_estatus] (
    [IdBoleto] int NOT NULL,
    [IdEstatusDet] int NOT NULL IDENTITY,
    [FechaEstatus] datetime2 NOT NULL,
    [IdTipoEstatus] int NOT NULL,
    [IdEstatus] int NOT NULL,
    [Actual] nvarchar(1) NOT NULL,
    [Observacion] nvarchar(500) NULL,
    [UsuarioReg] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_res_evento_zona_boleto_estatus] PRIMARY KEY ([IdBoleto], [IdEstatusDet]),
    CONSTRAINT [AK_res_evento_zona_boleto_estatus_IdEstatusDet] UNIQUE ([IdEstatusDet]),
    CONSTRAINT [FK_res_evento_zona_boleto_estatus_res_evento_zona_boletos_IdBoleto] FOREIGN KEY ([IdBoleto]) REFERENCES [res_evento_zona_boletos] ([IdBoleto]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_evento_zona_boleto_estatus_cat_tipos_estatus_IdTipoEstatus] FOREIGN KEY ([IdTipoEstatus]) REFERENCES [cat_tipos_estatus] ([IdTipoEstatus]) ON DELETE CASCADE,
    CONSTRAINT [FK_res_evento_zona_boleto_estatus_cat_estatus_IdTipoEstatus_IdEstatus] FOREIGN KEY ([IdTipoEstatus], [IdEstatus]) REFERENCES [cat_estatus] ([IdTipoEstatus], [IdEstatus]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_cat_productos_servicios_cat_tipos_generalesIdTipoGeneral] ON [cat_productos_servicios] ([cat_tipos_generalesIdTipoGeneral]);

GO

CREATE INDEX [IX_cat_productos_servicios_cat_generalesIdTipoGeneral_cat_generalesIdGeneral] ON [cat_productos_servicios] ([cat_generalesIdTipoGeneral], [cat_generalesIdGeneral]);

GO

CREATE INDEX [IX_res_evento_cliente_boletos_IdBoleto] ON [res_evento_cliente_boletos] ([IdBoleto]);

GO

CREATE INDEX [IX_res_evento_cliente_boletos_IdPersona] ON [res_evento_cliente_boletos] ([IdPersona]);

GO

CREATE INDEX [IX_res_evento_cliente_boletos_IdEvento_IdReservaCliente] ON [res_evento_cliente_boletos] ([IdEvento], [IdReservaCliente]);

GO

CREATE INDEX [IX_res_evento_cliente_prod_serv_IdProdServ_IdProdServEsp] ON [res_evento_cliente_prod_serv] ([IdProdServ], [IdProdServEsp]);

GO

CREATE INDEX [IX_res_evento_estatus_IdTipoEstatus_IdEstatus] ON [res_evento_estatus] ([IdTipoEstatus], [IdEstatus]);

GO

CREATE INDEX [IX_res_evento_horarios_IdEdificio_IdEspacio] ON [res_evento_horarios] ([IdEdificio], [IdEspacio]);

GO

CREATE INDEX [IX_res_evento_servicios_IdProdServ_IdProdServEsp] ON [res_evento_servicios] ([IdProdServ], [IdProdServEsp]);

GO

CREATE INDEX [IX_res_evento_zona_boleto_estatus_IdTipoEstatus_IdEstatus] ON [res_evento_zona_boleto_estatus] ([IdTipoEstatus], [IdEstatus]);

GO

CREATE INDEX [IX_res_evento_zona_boletos_IdEvento] ON [res_evento_zona_boletos] ([IdEvento]);

GO

CREATE INDEX [IX_res_evento_zona_boletos_IdEdificio_IdEspacio_IdZona] ON [res_evento_zona_boletos] ([IdEdificio], [IdEspacio], [IdZona]);

GO

CREATE INDEX [IX_res_evento_zonas_IdEvento] ON [res_evento_zonas] ([IdEvento]);

GO

CREATE INDEX [IX_res_evento_zonas_IdEdificio_IdEspacio_IdZona] ON [res_evento_zonas] ([IdEdificio], [IdEspacio], [IdZona]);

GO

CREATE INDEX [IX_res_eventos_IdEdificio] ON [res_eventos] ([IdEdificio]);

GO

CREATE INDEX [IX_res_eventos_cat_tipos_generalesIdTipoGeneral] ON [res_eventos] ([cat_tipos_generalesIdTipoGeneral]);

GO

CREATE INDEX [IX_res_eventos_rh_cat_personasIdPersona] ON [res_eventos] ([rh_cat_personasIdPersona]);

GO

CREATE INDEX [IX_res_eventos_cat_generalesIdTipoGeneral_cat_generalesIdGeneral] ON [res_eventos] ([cat_generalesIdTipoGeneral], [cat_generalesIdGeneral]);

GO

CREATE INDEX [IX_res_zonas_servicios_IdProdServ_IdProdServEsp] ON [res_zonas_servicios] ([IdProdServ], [IdProdServEsp]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180612081731_InitialCreate', N'2.1.0-rtm-30799');

GO

