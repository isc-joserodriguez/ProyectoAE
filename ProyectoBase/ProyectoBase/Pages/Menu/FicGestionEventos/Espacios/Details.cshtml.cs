using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.Menu.FicGestionEventos.Espacios
{
    public class DetailsModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public DetailsModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public eva_cat_espacios eva_cat_espacios { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_cat_espacios = await _context.eva_cat_espacios.SingleOrDefaultAsync(m => m.IdEspacio == id);

            if (eva_cat_espacios == null)
            {
                return NotFound();
            }
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
