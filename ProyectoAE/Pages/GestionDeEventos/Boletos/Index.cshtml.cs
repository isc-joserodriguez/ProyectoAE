using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoAE.Models;
using ProyectoAE.Models.GestionDeEventos;

namespace ProyectoAE.Pages.GestionDeEventos.Boletos
{
    public class IndexModel : PageModel
    {
        private readonly ProyectoAE.Models.ApplicationDbContext _context;

        public IndexModel(ProyectoAE.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Boleto> Boleto { get;set; }

        public async Task OnGetAsync()
        {
            Boleto = await _context.Boletos.ToListAsync();
        }
    }
}
