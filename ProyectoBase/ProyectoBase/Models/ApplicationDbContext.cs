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
            modelBuilder.Entity<res_evento_clientes>().HasKey( c => new { c.IdEvento, c.IdReservaCliente});
            modelBuilder.Entity<res_evento_cliente_prod_serv>().HasKey( c => new { c.IdEvento, c.IdReservaCliente, c.IdReservaServDet});
            modelBuilder.Entity<res_evento_cliente_boletos>().HasKey(c => new { c.IdReservaCliente, c.IdEvento, c.IdBoleto });
            modelBuilder.Entity<eva_cat_espacios>().HasKey( c => new { c.IdEdificio, c.IdEspacio});
            modelBuilder.Entity<cat_estatus>().HasKey(c => new { c.IdTipoEstatus, c.IdEstatus});
            modelBuilder.Entity<cat_generales>().HasKey( c => new { c.IdTipoGeneral, c.IdGeneral});
            modelBuilder.Entity<res_cat_zonas>().HasKey( c => new { c.IdEdificio, c.IdEspacio, c.IdZona });
            modelBuilder.Entity<res_zonas_servicios>().HasKey(c => new { c.IdEdificio, c.IdEspacio, c.IdZona, c.IdProdServ, c.IdProdServEsp });
            modelBuilder.Entity<cat_prod_serv_especifico>().HasKey( c => new { c.IdProdServ, c.IdProdServEsp});
            modelBuilder.Entity<res_evento_zonas>().HasKey( c => new { c.IdEdificio, c.IdEspacio, c.IdEvento, c.IdZona});
            modelBuilder.Entity<res_evento_zona_boleto_estatus>().HasKey( c => new { c.IdBoleto, c.IdEstatusDet});
        }
    }
}
