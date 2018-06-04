using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.Menu.FicGestionEventos.Zonas
{
    public class CreateModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public CreateModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int espacio, int edificio)
        {
            IdEdificio = edificio;
            IdEspacio = espacio;
            return Page();
        }

        [BindProperty]
        public res_cat_zonas res_cat_zonas { get; set; }
        public int IdEdificio { get; set; }
        public int IdEspacio { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            res_cat_zonas.CapacidadPer = res_cat_zonas.AsientosPorFila * res_cat_zonas.Filas;
            _context.res_cat_zonas.Add(res_cat_zonas);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { espacio = res_cat_zonas.IdEspacio, edificio = res_cat_zonas.IdEdificio});
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