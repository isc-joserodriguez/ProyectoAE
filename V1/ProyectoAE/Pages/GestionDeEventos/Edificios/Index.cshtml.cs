using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoAE.Models;
using ProyectoAE.Models.GestionDeEventos;

namespace ProyectoAE.Pages.GestionDeEventos.Edificios
{
    public class IndexModel : PageModel
    {
        private readonly ProyectoAE.Models.ApplicationDbContext _context;

        public IndexModel(ProyectoAE.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Edificio> Edificio { get;set; }

        /*public async Task OnGetAsync()
        {
            Edificio = await _context.Edificio.ToListAsync();
        }*/
        public async Task OnGetAsync(string searchString)
        {
            var bnombre = from m in _context.Edificio
                          select m;
            var queryable = from m in _context.Edificio
                            select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                bnombre = bnombre.Where(s => s.Nombre.Contains(searchString));
            }

            Edificio = await bnombre.ToListAsync();
        }
    }
}
