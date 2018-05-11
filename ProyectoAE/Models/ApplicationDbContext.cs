using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoAE.Models.GestionDeEventos;


namespace ProyectoAE.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Boleto> Boletos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Edificio> Edificio { get; set; }
        public DbSet<Res_eventos_horarios> ResEventoHorario { get; set; }
        public DbSet<Res_Eventos> ResEvento { get; set; }
        public DbSet<eva_cat_espacios> EvaCatEspacios { get; set; }

    }
}