using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.EventoClientes
{
    public class IndexModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public IndexModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<res_evento_clientes> res_evento_clientes { get;set; }

        public int IdEdificio { get; set; }
        public int IdEspacio { get; set; }
        public int IdEvento { get; set; }



        public async Task<IActionResult> OnGetAsync(int edificio, int espacio, int evento)
        {
            IdEdificio = edificio;
            IdEspacio = espacio;
            IdEvento = evento;
            res_evento_clientes = await _context.res_evento_clientes.ToListAsync();
            return Page();
        }
    }
}
