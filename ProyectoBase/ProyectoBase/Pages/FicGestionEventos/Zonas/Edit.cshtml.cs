using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.Zonas
{
    public class EditModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public EditModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public res_cat_zonas res_cat_zonas { get; set; }
        public int IdEdificio { get; set; }
        public int IdEspacio { get; set; }

        public async Task<IActionResult> OnGetAsync(int id, int espacio, int edificio)
        {
            IdEdificio = edificio;
            IdEspacio = espacio;
            res_cat_zonas = await _context.res_cat_zonas.SingleOrDefaultAsync(m => m.IdZona == id);

            if (res_cat_zonas == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            res_cat_zonas.CapacidadPer = res_cat_zonas.Filas * res_cat_zonas.AsientosPorFila;
            _context.Attach(res_cat_zonas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!res_cat_zonasExists(res_cat_zonas.IdZona))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { espacio = res_cat_zonas.IdEspacio, edificio = res_cat_zonas.IdEdificio });
        }

        private bool res_cat_zonasExists(int id)
        {
            return _context.res_cat_zonas.Any(e => e.IdZona == id);
        }

        public String getEdificio(string ID)
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

        public String getEspacio(string ID)
        {
            var Tipos = _context.eva_cat_espacios;
            foreach (eva_cat_espacios d in Tipos)
            {
                if (ID == d.IdEspacio.ToString())
                {
                    return d.Alias;
                }
            }
            return "Desconocido";
        }
    }
}
