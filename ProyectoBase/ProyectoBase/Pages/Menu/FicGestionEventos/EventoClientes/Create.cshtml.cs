using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.Menu.FicGestionEventos.EventoClientes
{
    public class CreateModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public CreateModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public int IdEdificio { get; set; }
        public int IdEspacio { get; set; }
        public int IdEvento { get; set; }

        public async Task<IActionResult> OnGetAsync(int edificio, int espacio, int evento)
        {
            IdEdificio = edificio;
            IdEspacio = espacio;
            IdEvento = evento;
            return Page();
        }

        [BindProperty]
        public res_evento_clientes res_evento_clientes { get; set; }

        public async Task<IActionResult> OnPostAsync(int edificio_, int espacio_, int evento_)
        {
            res_evento_clientes.FechaRegistro = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _context.res_evento_clientes.Add(res_evento_clientes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { edificio = edificio_, espacio = espacio_, evento = evento_ });
        }
    }
}