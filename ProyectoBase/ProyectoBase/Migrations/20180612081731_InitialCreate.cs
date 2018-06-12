using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoBase.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cat_tipos_estatus",
                columns: table => new
                {
                    IdTipoEstatus = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DesTipoEstatus = table.Column<string>(maxLength: 30, nullable: false),
                    Activo = table.Column<string>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cat_tipos_estatus", x => x.IdTipoEstatus);
                });

            migrationBuilder.CreateTable(
                name: "cat_tipos_generales",
                columns: table => new
                {
                    IdTipoGeneral = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DesTipo = table.Column<string>(maxLength: 100, nullable: false),
                    Activo = table.Column<string>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cat_tipos_generales", x => x.IdTipoGeneral);
                });

            migrationBuilder.CreateTable(
                name: "eva_cat_edificios",
                columns: table => new
                {
                    IdEdificio = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Clave = table.Column<string>(maxLength: 20, nullable: false),
                    Alias = table.Column<string>(maxLength: 10, nullable: false),
                    DesEdificio = table.Column<string>(maxLength: 50, nullable: false),
                    Prioridad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eva_cat_edificios", x => x.IdEdificio);
                });

            migrationBuilder.CreateTable(
                name: "rh_cat_personas",
                columns: table => new
                {
                    IdPersona = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdInstituto = table.Column<int>(nullable: false),
                    NumControl = table.Column<string>(maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    ApPaterno = table.Column<string>(maxLength: 60, nullable: true),
                    ApMaterno = table.Column<string>(maxLength: 60, nullable: true),
                    RFC = table.Column<string>(maxLength: 10, nullable: true),
                    CURP = table.Column<string>(maxLength: 25, nullable: false),
                    TipoPersona = table.Column<string>(maxLength: 1, nullable: false),
                    Sexo = table.Column<string>(maxLength: 1, nullable: false),
                    RutaFoto = table.Column<string>(maxLength: 255, nullable: true),
                    Alias = table.Column<string>(maxLength: 20, nullable: true),
                    FechaNac = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rh_cat_personas", x => x.IdPersona);
                });

            migrationBuilder.CreateTable(
                name: "cat_estatus",
                columns: table => new
                {
                    IdTipoEstatus = table.Column<int>(nullable: false),
                    IdEstatus = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Clave = table.Column<string>(maxLength: 50, nullable: false),
                    DesEstatus = table.Column<string>(maxLength: 30, nullable: false),
                    Activo = table.Column<string>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cat_estatus", x => new { x.IdTipoEstatus, x.IdEstatus });
                    table.UniqueConstraint("AK_cat_estatus_IdEstatus", x => x.IdEstatus);
                    table.ForeignKey(
                        name: "FK_cat_estatus_cat_tipos_estatus_IdTipoEstatus",
                        column: x => x.IdTipoEstatus,
                        principalTable: "cat_tipos_estatus",
                        principalColumn: "IdTipoEstatus",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cat_generales",
                columns: table => new
                {
                    IdTipoGeneral = table.Column<int>(nullable: false),
                    IdGeneral = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Clave = table.Column<string>(maxLength: 20, nullable: false),
                    DesGeneral = table.Column<string>(maxLength: 100, nullable: false),
                    Activo = table.Column<string>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cat_generales", x => new { x.IdTipoGeneral, x.IdGeneral });
                    table.UniqueConstraint("AK_cat_generales_IdGeneral", x => x.IdGeneral);
                    table.ForeignKey(
                        name: "FK_cat_generales_cat_tipos_generales_IdTipoGeneral",
                        column: x => x.IdTipoGeneral,
                        principalTable: "cat_tipos_generales",
                        principalColumn: "IdTipoGeneral",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "eva_cat_espacios",
                columns: table => new
                {
                    IdEdificio = table.Column<int>(nullable: false),
                    IdEspacio = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Clave = table.Column<string>(maxLength: 20, nullable: false),
                    Alias = table.Column<string>(maxLength: 10, nullable: false),
                    DesEspacio = table.Column<string>(maxLength: 50, nullable: false),
                    Capacidad = table.Column<int>(nullable: false),
                    Prioridad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eva_cat_espacios", x => new { x.IdEdificio, x.IdEspacio });
                    table.UniqueConstraint("AK_eva_cat_espacios_IdEspacio", x => x.IdEspacio);
                    table.ForeignKey(
                        name: "FK_eva_cat_espacios_eva_cat_edificios_IdEdificio",
                        column: x => x.IdEdificio,
                        principalTable: "eva_cat_edificios",
                        principalColumn: "IdEdificio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cat_productos_servicios",
                columns: table => new
                {
                    IdProdServ = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaveProdServ = table.Column<string>(maxLength: 20, nullable: false),
                    CodigoBarras = table.Column<string>(maxLength: 50, nullable: false),
                    DesProdServ = table.Column<string>(maxLength: 200, nullable: false),
                    ProductoServicio = table.Column<string>(maxLength: 1, nullable: false),
                    IdTipoGenProdServ = table.Column<int>(nullable: false),
                    cat_tipos_generalesIdTipoGeneral = table.Column<int>(nullable: true),
                    IdGenProdServ = table.Column<int>(nullable: false),
                    cat_generalesIdTipoGeneral = table.Column<int>(nullable: true),
                    cat_generalesIdGeneral = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cat_productos_servicios", x => x.IdProdServ);
                    table.ForeignKey(
                        name: "FK_cat_productos_servicios_cat_tipos_generales_cat_tipos_generalesIdTipoGeneral",
                        column: x => x.cat_tipos_generalesIdTipoGeneral,
                        principalTable: "cat_tipos_generales",
                        principalColumn: "IdTipoGeneral",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cat_productos_servicios_cat_generales_cat_generalesIdTipoGeneral_cat_generalesIdGeneral",
                        columns: x => new { x.cat_generalesIdTipoGeneral, x.cat_generalesIdGeneral },
                        principalTable: "cat_generales",
                        principalColumns: new[] { "IdTipoGeneral", "IdGeneral" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "res_eventos",
                columns: table => new
                {
                    IdEvento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdTipoGenEvento = table.Column<int>(nullable: false),
                    cat_tipos_generalesIdTipoGeneral = table.Column<int>(nullable: true),
                    IdGenEvento = table.Column<int>(nullable: false),
                    cat_generalesIdTipoGeneral = table.Column<int>(nullable: true),
                    cat_generalesIdGeneral = table.Column<int>(nullable: true),
                    IdPersonaReg = table.Column<int>(nullable: false),
                    rh_cat_personasIdPersona = table.Column<int>(nullable: true),
                    NombreEvento = table.Column<string>(maxLength: 1000, nullable: false),
                    Observacion = table.Column<string>(maxLength: 1000, nullable: true),
                    Explicacion = table.Column<string>(maxLength: 3000, nullable: true),
                    URL = table.Column<string>(maxLength: 1000, nullable: false),
                    FechaIn = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    IdEdificio = table.Column<int>(nullable: false),
                    FechaReg = table.Column<DateTime>(nullable: false),
                    UsuarioReg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_res_eventos", x => x.IdEvento);
                    table.ForeignKey(
                        name: "FK_res_eventos_eva_cat_edificios_IdEdificio",
                        column: x => x.IdEdificio,
                        principalTable: "eva_cat_edificios",
                        principalColumn: "IdEdificio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_eventos_cat_tipos_generales_cat_tipos_generalesIdTipoGeneral",
                        column: x => x.cat_tipos_generalesIdTipoGeneral,
                        principalTable: "cat_tipos_generales",
                        principalColumn: "IdTipoGeneral",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_res_eventos_rh_cat_personas_rh_cat_personasIdPersona",
                        column: x => x.rh_cat_personasIdPersona,
                        principalTable: "rh_cat_personas",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_res_eventos_cat_generales_cat_generalesIdTipoGeneral_cat_generalesIdGeneral",
                        columns: x => new { x.cat_generalesIdTipoGeneral, x.cat_generalesIdGeneral },
                        principalTable: "cat_generales",
                        principalColumns: new[] { "IdTipoGeneral", "IdGeneral" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "res_cat_zonas",
                columns: table => new
                {
                    IdEdificio = table.Column<int>(nullable: false),
                    IdEspacio = table.Column<int>(nullable: false),
                    IdZona = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DesZona = table.Column<string>(maxLength: 225, nullable: false),
                    CapacidadPer = table.Column<int>(nullable: false),
                    Filas = table.Column<int>(nullable: false),
                    AsientosPorFila = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_res_cat_zonas", x => new { x.IdEdificio, x.IdEspacio, x.IdZona });
                    table.UniqueConstraint("AK_res_cat_zonas_IdZona", x => x.IdZona);
                    table.ForeignKey(
                        name: "FK_res_cat_zonas_eva_cat_edificios_IdEdificio",
                        column: x => x.IdEdificio,
                        principalTable: "eva_cat_edificios",
                        principalColumn: "IdEdificio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_cat_zonas_eva_cat_espacios_IdEdificio_IdEspacio",
                        columns: x => new { x.IdEdificio, x.IdEspacio },
                        principalTable: "eva_cat_espacios",
                        principalColumns: new[] { "IdEdificio", "IdEspacio" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cat_prod_serv_especifico",
                columns: table => new
                {
                    IdProdServ = table.Column<int>(nullable: false),
                    IdProdServEsp = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaveProdServEsp = table.Column<string>(maxLength: 20, nullable: false),
                    DesProdServEsp = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cat_prod_serv_especifico", x => new { x.IdProdServ, x.IdProdServEsp });
                    table.UniqueConstraint("AK_cat_prod_serv_especifico_IdProdServEsp", x => x.IdProdServEsp);
                    table.ForeignKey(
                        name: "FK_cat_prod_serv_especifico_cat_productos_servicios_IdProdServ",
                        column: x => x.IdProdServ,
                        principalTable: "cat_productos_servicios",
                        principalColumn: "IdProdServ",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "res_evento_clientes",
                columns: table => new
                {
                    IdEvento = table.Column<int>(nullable: false),
                    IdReservaCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdClienteReserva = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_res_evento_clientes", x => new { x.IdEvento, x.IdReservaCliente });
                    table.UniqueConstraint("AK_res_evento_clientes_IdReservaCliente", x => x.IdReservaCliente);
                    table.ForeignKey(
                        name: "FK_res_evento_clientes_res_eventos_IdEvento",
                        column: x => x.IdEvento,
                        principalTable: "res_eventos",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "res_evento_estatus",
                columns: table => new
                {
                    IdEvento = table.Column<int>(nullable: false),
                    IdEstatusDet = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaEstatus = table.Column<DateTime>(nullable: false),
                    IdTipoEstatus = table.Column<int>(nullable: false),
                    IdEstatus = table.Column<int>(nullable: false),
                    Actual = table.Column<string>(maxLength: 1, nullable: false),
                    Observacion = table.Column<string>(maxLength: 500, nullable: true),
                    UsuarioReg = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_res_evento_estatus", x => new { x.IdEvento, x.IdEstatusDet });
                    table.UniqueConstraint("AK_res_evento_estatus_IdEstatusDet", x => x.IdEstatusDet);
                    table.ForeignKey(
                        name: "FK_res_evento_estatus_res_eventos_IdEvento",
                        column: x => x.IdEvento,
                        principalTable: "res_eventos",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_evento_estatus_cat_tipos_estatus_IdTipoEstatus",
                        column: x => x.IdTipoEstatus,
                        principalTable: "cat_tipos_estatus",
                        principalColumn: "IdTipoEstatus",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_evento_estatus_cat_estatus_IdTipoEstatus_IdEstatus",
                        columns: x => new { x.IdTipoEstatus, x.IdEstatus },
                        principalTable: "cat_estatus",
                        principalColumns: new[] { "IdTipoEstatus", "IdEstatus" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "res_evento_horarios",
                columns: table => new
                {
                    IdEvento = table.Column<int>(nullable: false),
                    IdHorarioDet = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdEdificio = table.Column<int>(nullable: false),
                    IdEspacio = table.Column<int>(nullable: false),
                    Dia = table.Column<string>(maxLength: 10, nullable: false),
                    FechaHoraIni = table.Column<DateTime>(nullable: false),
                    FechaHoraFin = table.Column<DateTime>(nullable: false),
                    Disponible = table.Column<string>(maxLength: 1, nullable: false),
                    FechaReg = table.Column<DateTime>(nullable: false),
                    UsuarioReg = table.Column<string>(maxLength: 18, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_res_evento_horarios", x => new { x.IdEvento, x.IdHorarioDet });
                    table.UniqueConstraint("AK_res_evento_horarios_IdHorarioDet", x => x.IdHorarioDet);
                    table.ForeignKey(
                        name: "FK_res_evento_horarios_eva_cat_edificios_IdEdificio",
                        column: x => x.IdEdificio,
                        principalTable: "eva_cat_edificios",
                        principalColumn: "IdEdificio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_evento_horarios_res_eventos_IdEvento",
                        column: x => x.IdEvento,
                        principalTable: "res_eventos",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_evento_horarios_eva_cat_espacios_IdEdificio_IdEspacio",
                        columns: x => new { x.IdEdificio, x.IdEspacio },
                        principalTable: "eva_cat_espacios",
                        principalColumns: new[] { "IdEdificio", "IdEspacio" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "res_evento_zona_boletos",
                columns: table => new
                {
                    IdBoleto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdEvento = table.Column<int>(nullable: false),
                    IdEdificio = table.Column<int>(nullable: false),
                    IdEspacio = table.Column<int>(nullable: false),
                    IdZona = table.Column<int>(nullable: false),
                    NumBoleto = table.Column<string>(maxLength: 20, nullable: false),
                    DesBoleto = table.Column<string>(maxLength: 20, nullable: false),
                    Precio = table.Column<float>(nullable: false),
                    IVA = table.Column<float>(nullable: false),
                    Ubicacion = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_res_evento_zona_boletos", x => x.IdBoleto);
                    table.ForeignKey(
                        name: "FK_res_evento_zona_boletos_eva_cat_edificios_IdEdificio",
                        column: x => x.IdEdificio,
                        principalTable: "eva_cat_edificios",
                        principalColumn: "IdEdificio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_evento_zona_boletos_res_eventos_IdEvento",
                        column: x => x.IdEvento,
                        principalTable: "res_eventos",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_evento_zona_boletos_eva_cat_espacios_IdEdificio_IdEspacio",
                        columns: x => new { x.IdEdificio, x.IdEspacio },
                        principalTable: "eva_cat_espacios",
                        principalColumns: new[] { "IdEdificio", "IdEspacio" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_evento_zona_boletos_res_cat_zonas_IdEdificio_IdEspacio_IdZona",
                        columns: x => new { x.IdEdificio, x.IdEspacio, x.IdZona },
                        principalTable: "res_cat_zonas",
                        principalColumns: new[] { "IdEdificio", "IdEspacio", "IdZona" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "res_evento_zonas",
                columns: table => new
                {
                    IdEdificio = table.Column<int>(nullable: false),
                    IdEspacio = table.Column<int>(nullable: false),
                    IdEvento = table.Column<int>(nullable: false),
                    IdZona = table.Column<int>(nullable: false),
                    FechaReg = table.Column<DateTime>(nullable: false),
                    UsuarioReg = table.Column<string>(maxLength: 20, nullable: false),
                    RutaImagen = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_res_evento_zonas", x => new { x.IdEdificio, x.IdEspacio, x.IdEvento, x.IdZona });
                    table.ForeignKey(
                        name: "FK_res_evento_zonas_eva_cat_edificios_IdEdificio",
                        column: x => x.IdEdificio,
                        principalTable: "eva_cat_edificios",
                        principalColumn: "IdEdificio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_evento_zonas_res_eventos_IdEvento",
                        column: x => x.IdEvento,
                        principalTable: "res_eventos",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_evento_zonas_eva_cat_espacios_IdEdificio_IdEspacio",
                        columns: x => new { x.IdEdificio, x.IdEspacio },
                        principalTable: "eva_cat_espacios",
                        principalColumns: new[] { "IdEdificio", "IdEspacio" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_evento_zonas_res_cat_zonas_IdEdificio_IdEspacio_IdZona",
                        columns: x => new { x.IdEdificio, x.IdEspacio, x.IdZona },
                        principalTable: "res_cat_zonas",
                        principalColumns: new[] { "IdEdificio", "IdEspacio", "IdZona" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "res_evento_servicios",
                columns: table => new
                {
                    IdEvento = table.Column<int>(nullable: false),
                    Requerido = table.Column<string>(maxLength: 1, nullable: false),
                    IdProdServ = table.Column<int>(nullable: false),
                    IdProdServEsp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_res_evento_servicios", x => new { x.IdEvento, x.IdProdServ, x.IdProdServEsp });
                    table.ForeignKey(
                        name: "FK_res_evento_servicios_res_eventos_IdEvento",
                        column: x => x.IdEvento,
                        principalTable: "res_eventos",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_evento_servicios_cat_productos_servicios_IdProdServ",
                        column: x => x.IdProdServ,
                        principalTable: "cat_productos_servicios",
                        principalColumn: "IdProdServ",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_evento_servicios_cat_prod_serv_especifico_IdProdServ_IdProdServEsp",
                        columns: x => new { x.IdProdServ, x.IdProdServEsp },
                        principalTable: "cat_prod_serv_especifico",
                        principalColumns: new[] { "IdProdServ", "IdProdServEsp" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "res_zonas_servicios",
                columns: table => new
                {
                    IdEdificio = table.Column<int>(nullable: false),
                    IdEspacio = table.Column<int>(nullable: false),
                    IdZona = table.Column<int>(nullable: false),
                    IdProdServ = table.Column<int>(nullable: false),
                    IdProdServEsp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_res_zonas_servicios", x => new { x.IdEdificio, x.IdEspacio, x.IdZona, x.IdProdServ, x.IdProdServEsp });
                    table.UniqueConstraint("AK_res_zonas_servicios_IdEdificio_IdEspacio_IdProdServ_IdProdServEsp_IdZona", x => new { x.IdEdificio, x.IdEspacio, x.IdProdServ, x.IdProdServEsp, x.IdZona });
                    table.ForeignKey(
                        name: "FK_res_zonas_servicios_eva_cat_edificios_IdEdificio",
                        column: x => x.IdEdificio,
                        principalTable: "eva_cat_edificios",
                        principalColumn: "IdEdificio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_zonas_servicios_cat_productos_servicios_IdProdServ",
                        column: x => x.IdProdServ,
                        principalTable: "cat_productos_servicios",
                        principalColumn: "IdProdServ",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_zonas_servicios_eva_cat_espacios_IdEdificio_IdEspacio",
                        columns: x => new { x.IdEdificio, x.IdEspacio },
                        principalTable: "eva_cat_espacios",
                        principalColumns: new[] { "IdEdificio", "IdEspacio" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_zonas_servicios_cat_prod_serv_especifico_IdProdServ_IdProdServEsp",
                        columns: x => new { x.IdProdServ, x.IdProdServEsp },
                        principalTable: "cat_prod_serv_especifico",
                        principalColumns: new[] { "IdProdServ", "IdProdServEsp" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_zonas_servicios_res_cat_zonas_IdEdificio_IdEspacio_IdZona",
                        columns: x => new { x.IdEdificio, x.IdEspacio, x.IdZona },
                        principalTable: "res_cat_zonas",
                        principalColumns: new[] { "IdEdificio", "IdEspacio", "IdZona" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "res_evento_cliente_prod_serv",
                columns: table => new
                {
                    IdEvento = table.Column<int>(nullable: false),
                    IdReservaCliente = table.Column<int>(nullable: false),
                    IdReservaServDet = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdProdServ = table.Column<int>(nullable: false),
                    IdProdServEsp = table.Column<int>(nullable: false),
                    Cantidad = table.Column<float>(nullable: false),
                    Precio = table.Column<float>(nullable: false),
                    IVA = table.Column<float>(nullable: false),
                    IdUnidadMedida = table.Column<int>(nullable: false),
                    Importe = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_res_evento_cliente_prod_serv", x => new { x.IdEvento, x.IdReservaCliente, x.IdReservaServDet });
                    table.UniqueConstraint("AK_res_evento_cliente_prod_serv_IdReservaServDet", x => x.IdReservaServDet);
                    table.ForeignKey(
                        name: "FK_res_evento_cliente_prod_serv_res_eventos_IdEvento",
                        column: x => x.IdEvento,
                        principalTable: "res_eventos",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_evento_cliente_prod_serv_cat_productos_servicios_IdProdServ",
                        column: x => x.IdProdServ,
                        principalTable: "cat_productos_servicios",
                        principalColumn: "IdProdServ",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_evento_cliente_prod_serv_res_evento_clientes_IdEvento_IdReservaCliente",
                        columns: x => new { x.IdEvento, x.IdReservaCliente },
                        principalTable: "res_evento_clientes",
                        principalColumns: new[] { "IdEvento", "IdReservaCliente" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_evento_cliente_prod_serv_cat_prod_serv_especifico_IdProdServ_IdProdServEsp",
                        columns: x => new { x.IdProdServ, x.IdProdServEsp },
                        principalTable: "cat_prod_serv_especifico",
                        principalColumns: new[] { "IdProdServ", "IdProdServEsp" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "res_evento_cliente_boletos",
                columns: table => new
                {
                    IdReservaCliente = table.Column<int>(nullable: false),
                    IdEvento = table.Column<int>(nullable: false),
                    IdBoleto = table.Column<int>(nullable: false),
                    IdPersona = table.Column<int>(nullable: false),
                    ConfirmaAsistencia = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_res_evento_cliente_boletos", x => new { x.IdReservaCliente, x.IdEvento, x.IdBoleto });
                    table.ForeignKey(
                        name: "FK_res_evento_cliente_boletos_res_evento_zona_boletos_IdBoleto",
                        column: x => x.IdBoleto,
                        principalTable: "res_evento_zona_boletos",
                        principalColumn: "IdBoleto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_evento_cliente_boletos_res_eventos_IdEvento",
                        column: x => x.IdEvento,
                        principalTable: "res_eventos",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_evento_cliente_boletos_rh_cat_personas_IdPersona",
                        column: x => x.IdPersona,
                        principalTable: "rh_cat_personas",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_evento_cliente_boletos_res_evento_clientes_IdEvento_IdReservaCliente",
                        columns: x => new { x.IdEvento, x.IdReservaCliente },
                        principalTable: "res_evento_clientes",
                        principalColumns: new[] { "IdEvento", "IdReservaCliente" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "res_evento_zona_boleto_estatus",
                columns: table => new
                {
                    IdBoleto = table.Column<int>(nullable: false),
                    IdEstatusDet = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaEstatus = table.Column<DateTime>(nullable: false),
                    IdTipoEstatus = table.Column<int>(nullable: false),
                    IdEstatus = table.Column<int>(nullable: false),
                    Actual = table.Column<string>(maxLength: 1, nullable: false),
                    Observacion = table.Column<string>(maxLength: 500, nullable: true),
                    UsuarioReg = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_res_evento_zona_boleto_estatus", x => new { x.IdBoleto, x.IdEstatusDet });
                    table.UniqueConstraint("AK_res_evento_zona_boleto_estatus_IdEstatusDet", x => x.IdEstatusDet);
                    table.ForeignKey(
                        name: "FK_res_evento_zona_boleto_estatus_res_evento_zona_boletos_IdBoleto",
                        column: x => x.IdBoleto,
                        principalTable: "res_evento_zona_boletos",
                        principalColumn: "IdBoleto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_evento_zona_boleto_estatus_cat_tipos_estatus_IdTipoEstatus",
                        column: x => x.IdTipoEstatus,
                        principalTable: "cat_tipos_estatus",
                        principalColumn: "IdTipoEstatus",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_res_evento_zona_boleto_estatus_cat_estatus_IdTipoEstatus_IdEstatus",
                        columns: x => new { x.IdTipoEstatus, x.IdEstatus },
                        principalTable: "cat_estatus",
                        principalColumns: new[] { "IdTipoEstatus", "IdEstatus" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cat_productos_servicios_cat_tipos_generalesIdTipoGeneral",
                table: "cat_productos_servicios",
                column: "cat_tipos_generalesIdTipoGeneral");

            migrationBuilder.CreateIndex(
                name: "IX_cat_productos_servicios_cat_generalesIdTipoGeneral_cat_generalesIdGeneral",
                table: "cat_productos_servicios",
                columns: new[] { "cat_generalesIdTipoGeneral", "cat_generalesIdGeneral" });

            migrationBuilder.CreateIndex(
                name: "IX_res_evento_cliente_boletos_IdBoleto",
                table: "res_evento_cliente_boletos",
                column: "IdBoleto");

            migrationBuilder.CreateIndex(
                name: "IX_res_evento_cliente_boletos_IdPersona",
                table: "res_evento_cliente_boletos",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_res_evento_cliente_boletos_IdEvento_IdReservaCliente",
                table: "res_evento_cliente_boletos",
                columns: new[] { "IdEvento", "IdReservaCliente" });

            migrationBuilder.CreateIndex(
                name: "IX_res_evento_cliente_prod_serv_IdProdServ_IdProdServEsp",
                table: "res_evento_cliente_prod_serv",
                columns: new[] { "IdProdServ", "IdProdServEsp" });

            migrationBuilder.CreateIndex(
                name: "IX_res_evento_estatus_IdTipoEstatus_IdEstatus",
                table: "res_evento_estatus",
                columns: new[] { "IdTipoEstatus", "IdEstatus" });

            migrationBuilder.CreateIndex(
                name: "IX_res_evento_horarios_IdEdificio_IdEspacio",
                table: "res_evento_horarios",
                columns: new[] { "IdEdificio", "IdEspacio" });

            migrationBuilder.CreateIndex(
                name: "IX_res_evento_servicios_IdProdServ_IdProdServEsp",
                table: "res_evento_servicios",
                columns: new[] { "IdProdServ", "IdProdServEsp" });

            migrationBuilder.CreateIndex(
                name: "IX_res_evento_zona_boleto_estatus_IdTipoEstatus_IdEstatus",
                table: "res_evento_zona_boleto_estatus",
                columns: new[] { "IdTipoEstatus", "IdEstatus" });

            migrationBuilder.CreateIndex(
                name: "IX_res_evento_zona_boletos_IdEvento",
                table: "res_evento_zona_boletos",
                column: "IdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_res_evento_zona_boletos_IdEdificio_IdEspacio_IdZona",
                table: "res_evento_zona_boletos",
                columns: new[] { "IdEdificio", "IdEspacio", "IdZona" });

            migrationBuilder.CreateIndex(
                name: "IX_res_evento_zonas_IdEvento",
                table: "res_evento_zonas",
                column: "IdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_res_evento_zonas_IdEdificio_IdEspacio_IdZona",
                table: "res_evento_zonas",
                columns: new[] { "IdEdificio", "IdEspacio", "IdZona" });

            migrationBuilder.CreateIndex(
                name: "IX_res_eventos_IdEdificio",
                table: "res_eventos",
                column: "IdEdificio");

            migrationBuilder.CreateIndex(
                name: "IX_res_eventos_cat_tipos_generalesIdTipoGeneral",
                table: "res_eventos",
                column: "cat_tipos_generalesIdTipoGeneral");

            migrationBuilder.CreateIndex(
                name: "IX_res_eventos_rh_cat_personasIdPersona",
                table: "res_eventos",
                column: "rh_cat_personasIdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_res_eventos_cat_generalesIdTipoGeneral_cat_generalesIdGeneral",
                table: "res_eventos",
                columns: new[] { "cat_generalesIdTipoGeneral", "cat_generalesIdGeneral" });

            migrationBuilder.CreateIndex(
                name: "IX_res_zonas_servicios_IdProdServ_IdProdServEsp",
                table: "res_zonas_servicios",
                columns: new[] { "IdProdServ", "IdProdServEsp" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "res_evento_cliente_boletos");

            migrationBuilder.DropTable(
                name: "res_evento_cliente_prod_serv");

            migrationBuilder.DropTable(
                name: "res_evento_estatus");

            migrationBuilder.DropTable(
                name: "res_evento_horarios");

            migrationBuilder.DropTable(
                name: "res_evento_servicios");

            migrationBuilder.DropTable(
                name: "res_evento_zona_boleto_estatus");

            migrationBuilder.DropTable(
                name: "res_evento_zonas");

            migrationBuilder.DropTable(
                name: "res_zonas_servicios");

            migrationBuilder.DropTable(
                name: "res_evento_clientes");

            migrationBuilder.DropTable(
                name: "res_evento_zona_boletos");

            migrationBuilder.DropTable(
                name: "cat_estatus");

            migrationBuilder.DropTable(
                name: "cat_prod_serv_especifico");

            migrationBuilder.DropTable(
                name: "res_eventos");

            migrationBuilder.DropTable(
                name: "res_cat_zonas");

            migrationBuilder.DropTable(
                name: "cat_tipos_estatus");

            migrationBuilder.DropTable(
                name: "cat_productos_servicios");

            migrationBuilder.DropTable(
                name: "rh_cat_personas");

            migrationBuilder.DropTable(
                name: "eva_cat_espacios");

            migrationBuilder.DropTable(
                name: "cat_generales");

            migrationBuilder.DropTable(
                name: "eva_cat_edificios");

            migrationBuilder.DropTable(
                name: "cat_tipos_generales");
        }
    }
}
