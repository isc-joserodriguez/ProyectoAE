using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.Zonas
{
    public class IndexModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public IndexModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<res_cat_zonas> res_cat_zonas { get; set; }
        public eva_cat_espacios eva_cat_espacios { get; set; }
        public int IdEdificio { get; set; }
        public int IdEspacio { get; set; }

        public async Task<IActionResult> OnGetAsync(int espacio, int edificio)
        {
            IQueryable<res_cat_zonas> edificios = from s in _context.res_cat_zonas
                                                     select s;

             res_cat_zonas = await _context
                .res_cat_zonas
                .ToListAsync();
            eva_cat_espacios = await _context
                .eva_cat_espacios
                .SingleOrDefaultAsync(m => m.IdEspacio == espacio);


            if (eva_cat_espacios == null)
            {
                return NotFound();
            }
            IdEspacio = eva_cat_espacios.IdEspacio;
            IdEdificio = eva_cat_espacios.IdEdificio;
            //IdEdificio = edificio;
            res_cat_zonas = await edificios.Where(m => m.IdEspacio == espacio).AsNoTracking().ToListAsync();

            return Page();
        }

        public String Edificio(string ID)
        {
            var Tipos = _context.eva_cat_edificios;
            foreach (eva_cat_edificios d in Tipos)
            {
                if (ID == d.IdEdificio.ToString())
                {
                    return d.Clave;
                }
            }
            return "Desconocido";
        }
    }
}
