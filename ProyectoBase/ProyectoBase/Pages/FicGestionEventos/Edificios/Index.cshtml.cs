using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.Edificios
{
    public class IndexModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public IndexModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; } = "Nombre";
        public string DateSort { get; set; } = "Fecha";
        public string DateEndSort { get; set; } = "FechaFin";
        public string IdSort { get; set; } = "Id";
        public string ASC { get; set; } = "ASC";
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public string x { get; set; }

        public IList<eva_cat_edificios> eva_cat_edificios { get;set; }

        public async Task OnGetAsync(string sortOrder, string orden, string busqueda)
        {

            IQueryable<eva_cat_edificios> cat_edificios = from s in _context.eva_cat_edificios
                                                    select s;
            CurrentFilter = busqueda;
            if (!String.IsNullOrEmpty(busqueda))
            {
                cat_edificios = cat_edificios.Where(s => s.Clave.Contains(busqueda) || s.Alias.ToString().Contains(busqueda) || s.Prioridad.ToString().Contains(busqueda));

            }

            if (sortOrder == "clave" && orden == "ASC")
            {
                ASC = "DESC";
                cat_edificios = cat_edificios.OrderBy(s => s.Clave);
            }
            else if (sortOrder == "clave" && orden == "DESC")
            {
                ASC = "ASC";
                cat_edificios = cat_edificios.OrderByDescending(s => s.Clave);
            }
            else if (sortOrder == "alias" && orden == "ASC")
            {
                ASC = "DESC";
                cat_edificios = cat_edificios.OrderBy(s => s.Alias);
            }
            else if (sortOrder == "alias" && orden == "DESC")
            {
                ASC = "ASC";
                cat_edificios = cat_edificios.OrderByDescending(s => s.Alias);
            }
            else if (sortOrder == "prioridad" && orden == "ASC")
            {
                ASC = "DESC";
                cat_edificios = cat_edificios.OrderBy(s => s.Prioridad);
            }
            else if (sortOrder == "prioridad" && orden == "DESC")
            {
                ASC = "ASC";
                cat_edificios = cat_edificios.OrderByDescending(s => s.Prioridad);
            }
            else
            {
                ASC = (String.IsNullOrEmpty(orden)) ? "ASC" : "";
                cat_edificios = cat_edificios.OrderBy(s => s.Clave);
            }

            x = sortOrder + " : " + orden;

            eva_cat_edificios = await cat_edificios.AsNoTracking().ToListAsync();
        }
    }
}
