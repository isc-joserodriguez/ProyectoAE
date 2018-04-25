﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<ProyectoAE.Models.GestionDeEventos.Edificio> Edificio { get; set; }


    }
}