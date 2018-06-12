using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.Espacios
{
    public class IndexModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public IndexModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<eva_cat_espacios> eva_cat_espacios { get;set; }
        public eva_cat_edificios eva_cat_edificios { get; set; }
        public int IdEdificio { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            IQueryable<eva_cat_espacios> edificios = from s in _context.eva_cat_espacios
                                                      select s;

            if (id == null)
            {
                return NotFound();
            }

            eva_cat_espacios = await _context
                .eva_cat_espacios
                .ToListAsync();
            eva_cat_edificios = await _context
                .eva_cat_edificios
                .SingleOrDefaultAsync(m => m.IdEdificio == id);
            

            if (eva_cat_edificios == null)
            {
                return NotFound();
            }
            IdEdificio = eva_cat_edificios.IdEdificio;
            eva_cat_espacios = await edificios.Where(m => m.IdEdificio == id).AsNoTracking().ToListAsync();

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
