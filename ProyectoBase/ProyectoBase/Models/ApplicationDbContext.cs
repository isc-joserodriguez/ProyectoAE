using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<res_eventos> res_eventos { get; set; }
        public DbSet<res_evento_horarios> res_evento_horarios { get; set; }

        public DbSet<res_evento_cliente_prod_serv> res_evento_cliente_prod_serv { get; set; }
        public DbSet<res_evento_clientes> res_evento_clientes { get; set; }
        public DbSet<res_evento_cliente_boletos> res_evento_cliente_boletos { get; set; }

        public DbSet<eva_cat_edificios> eva_cat_edificios { get; set; }
        public DbSet<eva_cat_espacios> eva_cat_espacios { get; set; }
        public DbSet<cat_tipos_estatus> cat_tipos_estatus { get; set; }
        public DbSet<cat_estatus> cat_estatus { get; set; }
        public DbSet<cat_generales> cat_generales { get; set; }
        public DbSet<cat_tipos_generales> cat_tipos_generales { get; set; }
        public DbSet<rh_cat_personas> rh_cat_personas { get; set; }

        public DbSet<res_evento_estatus> res_evento_estatus { get; set; }
        public DbSet<res_evento_servicios> res_evento_servicios { get; set; }
        public DbSet<res_cat_zonas> res_cat_zonas { get; set; }
        public DbSet<res_zonas_servicios> res_zonas_servicios { get; set; }
        public DbSet<cat_productos_servicios> cat_productos_servicios { get; set; }
        public DbSet<cat_prod_serv_especifico> cat_prod_serv_especifico { get; set; }
        
        public DbSet<res_evento_zona_boleto_estatus> res_evento_zona_boleto_estatus { get; set; }
        public DbSet<res_evento_zona_boletos> res_evento_zona_boletos { get; set; }
        public DbSet<res_evento_zonas> res_evento_zonas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<res_evento_horarios>().HasKey(c => new { c.IdEvento, c.IdHorarioDet });
            modelBuilder.Entity<res_evento_servicios>().HasKey(c => new { c.IdEvento, c.IdProdServ, c.IdProdServEsp });
            modelBuilder.Entity<res_evento_estatus>().HasKey(c => new { c.IdEvento, c.IdEstatusDet });
            modelBuilder.Entity<res_evento_clientes>().HasKey(c => new { c.IdEvento, c.IdReservaCliente });
            modelBuilder.Entity<res_evento_cliente_prod_serv>().HasKey(c => new { c.IdEvento, c.IdReservaCliente, c.IdReservaServDet });
            modelBuilder.Entity<res_evento_cliente_boletos>().HasKey(c => new { c.IdReservaCliente, c.IdEvento, c.IdBoleto });
            modelBuilder.Entity<eva_cat_espacios>().HasKey(c => new { c.IdEdificio, c.IdEspacio });
            modelBuilder.Entity<cat_estatus>().HasKey(c => new { c.IdTipoEstatus, c.IdEstatus });
            modelBuilder.Entity<cat_generales>().HasKey(c => new { c.IdTipoGeneral, c.IdGeneral });
            modelBuilder.Entity<res_cat_zonas>().HasKey(c => new { c.IdEdificio, c.IdEspacio, c.IdZona });
            modelBuilder.Entity<res_zonas_servicios>().HasKey(c => new { c.IdEdificio, c.IdEspacio, c.IdZona, c.IdProdServ, c.IdProdServEsp });
            modelBuilder.Entity<cat_prod_serv_especifico>().HasKey(c => new { c.IdProdServ, c.IdProdServEsp });
            modelBuilder.Entity<res_evento_zonas>().HasKey(c => new { c.IdEdificio, c.IdEspacio, c.IdEvento, c.IdZona });
            modelBuilder.Entity<res_evento_zona_boleto_estatus>().HasKey(c => new { c.IdBoleto, c.IdEstatusDet });

            modelBuilder.Entity<cat_estatus>()
                .HasOne(e => e.TiposEstatus)
                .WithMany(b => b.Estatus)
                .HasForeignKey(p => p.IdTipoEstatus)
                .HasConstraintName("ForeignKey_TiposEstatus_Estatus");

            modelBuilder.Entity<cat_generales>()
                .HasOne(e => e.TiposGenerales)
                .WithMany(b => b.Generales)
                .HasForeignKey(p => p.IdTipoGeneral)
                .HasConstraintName("ForeignKey_TiposGenerales_Generales");

            modelBuilder.Entity<cat_prod_serv_especifico>()
                .HasOne(e => e.ProductosServicios)
                .WithMany(b => b.ProductoServicioEspecifico)
                .HasForeignKey(p => p.IdProdServ)
                .HasConstraintName("ForeignKey_ProductosServicios_ProductosServiciosEspecifico");

            modelBuilder.Entity<cat_productos_servicios>()
                .HasOne(e => e.TiposGenerales)
                .WithMany(b => b.ProductosServicios)
                .HasForeignKey(p => p.IdTipoGenProdServ)
                .HasConstraintName("ForeignKey_TiposGenerales_ProductosServicios");

            modelBuilder.Entity<cat_productos_servicios>()
                .HasOne(e => e.Generales)
                .WithMany(b => b.ProductosServicios)
                .HasForeignKey(p => p.IdGenProdServ)
                .HasConstraintName("ForeignKey_Generales_ProductosServicios");

            modelBuilder.Entity<eva_cat_espacios>()
                .HasOne(e => e.Edificios)
                .WithMany(b => b.Espacios)
                .HasForeignKey(p => p.IdEdificio)
                .HasConstraintName("ForeignKey_Edificios_Espacios");

            modelBuilder.Entity<res_cat_zonas>()
                .HasOne(e => e.Edificios)
                .WithMany(b => b.Zonas)
                .HasForeignKey(p => p.IdEdificio)
                .HasConstraintName("ForeignKey_Edificios_Zonas");

            modelBuilder.Entity<res_cat_zonas>()
                .HasOne(e => e.Espacios)
                .WithMany(b => b.Zonas)
                .HasForeignKey(p => p.IdEspacio)
                .HasConstraintName("ForeignKey_Espacios_Zonas");

            modelBuilder.Entity<res_evento_cliente_boletos>()
                .HasOne(e => e.EventoClientes)
                .WithMany(b => b.EventoClientesBoletos)
                .HasForeignKey(p => p.IdReservaCliente)
                .HasConstraintName("ForeignKey_EventoClientes_EventoClienteBoletos");

            modelBuilder.Entity<res_evento_cliente_boletos>()
                .HasOne(e => e.Eventos)
                .WithMany(b => b.EventoClientesBoletos)
                .HasForeignKey(p => p.IdEvento)
                .HasConstraintName("ForeignKey_Eventos_EventoClienteBoletos");

            modelBuilder.Entity<res_evento_cliente_boletos>()
                .HasOne(e => e.EventoZonaBoleto)
                .WithMany(b => b.EventoClientesBoletos)
                .HasForeignKey(p => p.IdBoleto)
                .HasConstraintName("ForeignKey_EventoZonaBoletos_EventoClienteBoletos");

            modelBuilder.Entity<res_evento_cliente_boletos>()
                .HasOne(e => e.Personas)
                .WithMany(b => b.EventoClienteBoletos)
                .HasForeignKey(p => p.IdPersona)
                .HasConstraintName("ForeignKey_Personas_EventoClienteBoletos");

            modelBuilder.Entity<res_evento_cliente_prod_serv>()
                .HasOne(e => e.Eventos)
                .WithMany(b => b.EventoClienteProdServ)
                .HasForeignKey(p => p.IdEvento)
                .HasConstraintName("ForeignKey_Evento_EventoClienteProdServ");

            modelBuilder.Entity<res_evento_cliente_prod_serv>()
                .HasOne(e => e.EventoClientes)
                .WithMany(b => b.EventoClienteProdServ)
                .HasForeignKey(p => p.IdReservaCliente)
                .HasConstraintName("ForeignKey_EventoClientes_EventoClienteProdServ");

            modelBuilder.Entity<res_evento_cliente_prod_serv>()
                .HasOne(e => e.ProductosServicios)
                .WithMany(b => b.EventoClienteProdServ)
                .HasForeignKey(p => p.IdProdServ)
                .HasConstraintName("ForeignKey_ProductosServicios_EventoClienteProdServ");

            modelBuilder.Entity<res_evento_cliente_prod_serv>()
                .HasOne(e => e.ProductoServicioEspecifico)
                .WithMany(b => b.EventoClienteProdServ)
                .HasForeignKey(p => p.IdProdServEsp)
                .HasConstraintName("ForeignKey_ProductosServiciosEspecifico_EventoClienteProdServ");

            modelBuilder.Entity<res_evento_clientes>()
                .HasOne(e => e.Eventos)
                .WithMany(b => b.EventoClientes)
                .HasForeignKey(p => p.IdEvento)
                .HasConstraintName("ForeignKey_Evento_EventoClientes");

            modelBuilder.Entity<res_evento_estatus>()
                .HasOne(e => e.Eventos)
                .WithMany(b => b.EventoEstatus)
                .HasForeignKey(p => p.IdEvento)
                .HasConstraintName("ForeignKey_Evento_EventoEstatus");

            modelBuilder.Entity<res_evento_estatus>()
                .HasOne(e => e.TiposEstatus)
                .WithMany(b => b.EventoEstatus)
                .HasForeignKey(p => p.IdTipoEstatus)
                .HasConstraintName("ForeignKey_TiposEstatus_EventoEstatus");

            modelBuilder.Entity<res_evento_estatus>()
                .HasOne(e => e.Estatus)
                .WithMany(b => b.EventoEstatus)
                .HasForeignKey(p => p.IdEstatus)
                .HasConstraintName("ForeignKey_Estatus_EventoEstatus");

            modelBuilder.Entity<res_evento_horarios>()
                .HasOne(e => e.Eventos)
                .WithMany(b => b.EventoHorarios)
                .HasForeignKey(p => p.IdEvento)
                .HasConstraintName("ForeignKey_Eventos_EventoHorarios");

            modelBuilder.Entity<res_evento_horarios>()
                .HasOne(e => e.Edificios)
                .WithMany(b => b.EventoHorarios)
                .HasForeignKey(p => p.IdEdificio)
                .HasConstraintName("ForeignKey_Edificios_EventoHorarios");

            modelBuilder.Entity<res_evento_horarios>()
                .HasOne(e => e.Espacios)
                .WithMany(b => b.EventoHorarios)
                .HasForeignKey(p => p.IdEspacio)
                .HasConstraintName("ForeignKey_Espacios_EventoHorarios");

            modelBuilder.Entity<res_evento_servicios>()
                .HasOne(e => e.Eventos)
                .WithMany(b => b.EventoServicios)
                .HasForeignKey(p => p.IdEvento)
                .HasConstraintName("ForeignKey_Eventos_EventoServicios");

            modelBuilder.Entity<res_evento_servicios>()
                .HasOne(e => e.ProductosSErvicios)
                .WithMany(b => b.EventoServicios)
                .HasForeignKey(p => p.IdProdServ)
                .HasConstraintName("ForeignKey_ProductosServicios_EventoServicios");

            modelBuilder.Entity<res_evento_servicios>()
                .HasOne(e => e.ProdServEspecifico)
                .WithMany(b => b.EventoServicios)
                .HasForeignKey(p => p.IdProdServEsp)
                .HasConstraintName("ForeignKey_ProdServEspecifico_EventoServicios");

            modelBuilder.Entity<res_evento_zona_boleto_estatus>()
                .HasOne(e => e.EventoZonaBoletos)
                .WithMany(b => b.EventoZonaBoletoEstatus)
                .HasForeignKey(p => p.IdBoleto)
                .HasConstraintName("ForeignKey_EventoZonaBoletos_EventoZonaBoletoEstatus");

            modelBuilder.Entity<res_evento_zona_boleto_estatus>()
                .HasOne(e => e.TiposEstatus)
                .WithMany(b => b.EventoZonaBoletoEstatus)
                .HasForeignKey(p => p.IdTipoEstatus)
                .HasConstraintName("ForeignKey_TiposEstatus_EventoZonaBoletoEstatus");

            modelBuilder.Entity<res_evento_zona_boleto_estatus>()
                .HasOne(e => e.Estatus)
                .WithMany(b => b.EventoZonaBoletoEstatus)
                .HasForeignKey(p => p.IdEstatus)
                .HasConstraintName("ForeignKey_Estatus_EventoZonaBoletoEstatus");

            modelBuilder.Entity<res_evento_zona_boletos>()
                .HasOne(e => e.Eventos)
                .WithMany(b => b.EventoZonaBoletos)
                .HasForeignKey(p => p.IdEvento)
                .HasConstraintName("ForeignKey_Eventos_EventoZonaBoletos");

            modelBuilder.Entity<res_evento_zona_boletos>()
                .HasOne(e => e.Edificios)
                .WithMany(b => b.EventoZonaBoletos)
                .HasForeignKey(p => p.IdEdificio)
                .HasConstraintName("ForeignKey_Edificios_EventoZonaBoletos");

            modelBuilder.Entity<res_evento_zona_boletos>()
                .HasOne(e => e.Espacios)
                .WithMany(b => b.EventoZonaBoletos)
                .HasForeignKey(p => p.IdEspacio)
                .HasConstraintName("ForeignKey_Espacios_EventoZonaBoletos");

            modelBuilder.Entity<res_evento_zona_boletos>()
                .HasOne(e => e.Zonas)
                .WithMany(b => b.EventoZonaBoletos)
                .HasForeignKey(p => p.IdZona)
                .HasConstraintName("ForeignKey_Zonas_EventoZonaBoletos");

            modelBuilder.Entity<res_zonas_servicios>()
                .HasOne(e => e.Edificios)
                .WithMany(b => b.ZonasServicios)
                .HasForeignKey(p => p.IdEdificio)
                .HasConstraintName("ForeignKey_Edificio_ZonasServicios");

            modelBuilder.Entity<res_zonas_servicios>()
                .HasOne(e => e.Espacios)
                .WithMany(b => b.ZonasServicios)
                .HasForeignKey(p => p.IdEspacio)
                .HasConstraintName("ForeignKey_Espacios_ZonasServicios");

            modelBuilder.Entity<res_zonas_servicios>()
                .HasOne(e => e.Zonas)
                .WithMany(b => b.ZonasServicios)
                .HasForeignKey(p => p.IdZona)
                .HasConstraintName("ForeignKey_Zonas_ZonasServicios");

            modelBuilder.Entity<res_zonas_servicios>()
                .HasOne(e => e.ProductosServicios)
                .WithMany(b => b.ZonasServicios)
                .HasForeignKey(p => p.IdProdServ)
                .HasConstraintName("ForeignKey_ProductosServicios_ZonasServicios");

            modelBuilder.Entity<res_zonas_servicios>()
                .HasOne(e => e.ProdServEspecifico)
                .WithMany(b => b.ZonasServicios)
                .HasForeignKey(p => p.IdProdServEsp)
                .HasConstraintName("ForeignKey_ProdServEspecifico_ZonasServicios");

            modelBuilder.Entity<res_evento_zonas>()
                .HasOne(e => e.Edificios)
                .WithMany(b => b.EventoZonas)
                .HasForeignKey(p => p.IdEdificio)
                .HasConstraintName("ForeignKey_Edificio_EventoZonas");

            modelBuilder.Entity<res_evento_zonas>()
                .HasOne(e => e.Espacios)
                .WithMany(b => b.EventoZonas)
                .HasForeignKey(p => p.IdEspacio)
                .HasConstraintName("ForeignKey_Espacios_EventoZonas");

            modelBuilder.Entity<res_evento_zonas>()
                .HasOne(e => e.Eventos)
                .WithMany(b => b.EventoZonas)
                .HasForeignKey(p => p.IdEvento)
                .HasConstraintName("ForeignKey_Eventos_EventoZonas");

            modelBuilder.Entity<res_evento_zonas>()
                .HasOne(e => e.Zonas)
                .WithMany(b => b.EventoZonas)
                .HasForeignKey(p => p.IdZona)
                .HasConstraintName("ForeignKey_Zonas_EventoZonas");

            modelBuilder.Entity<res_eventos>()
                .HasOne(e => e.TiposGenerales)
                .WithMany(b => b.Eventos)
                .HasForeignKey(p => p.IdTipoGenEvento)
                .HasConstraintName("ForeignKey_TipoGenerales_Eventos");

            modelBuilder.Entity<res_eventos>()
                .HasOne(e => e.Generales)
                .WithMany(b => b.Eventos)
                .HasForeignKey(p => p.IdGenEvento)
                .HasConstraintName("ForeignKey_Generales_Eventos");

            modelBuilder.Entity<res_eventos>()
                .HasOne(e => e.Personas)
                .WithMany(b => b.Eventos)
                .HasForeignKey(p => p.IdPersonaReg)
                .HasConstraintName("ForeignKey_Personas_Eventos");

            modelBuilder.Entity<res_eventos>()
                .HasOne(e => e.Edificios)
                .WithMany(b => b.Eventos)
                .HasForeignKey(p => p.IdEdificio)
                .HasConstraintName("ForeignKey_Edificio_Eventos");
        }
    }
}


