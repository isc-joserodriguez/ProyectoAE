using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoAE.Models;
using ProyectoAE.Models.GestionDeEventos;

namespace ProyectoAE.Pages.GestionDeEventos.ResEvento
{
    public class IndexModel : PageModel
    {
        private readonly ProyectoAE.Models.ApplicationDbContext _context;

        public IndexModel(ProyectoAE.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Res_Eventos> Res_Eventos { get;set; }

        public async Task OnGetAsync()
        {
            Res_Eventos = await _context.ResEvento.ToListAsync();
        }
    }
}
