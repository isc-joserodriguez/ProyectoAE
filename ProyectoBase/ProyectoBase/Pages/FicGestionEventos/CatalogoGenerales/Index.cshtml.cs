using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.CatalogoGenerales
{
    public class IndexModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public IndexModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<cat_generales> cat_generales { get;set; }

        public async Task OnGetAsync(int id)
        {
            cat_generales = await _context.cat_generales.ToListAsync();
        }

        public String TipoGenEvento(string ID)
        {
            var Tipos = _context.cat_tipos_generales;
            foreach (cat_tipos_generales d in Tipos)
            {
                if (ID == d.IdTipoGeneral.ToString())
                {
                    return d.DesTipo;
                }
            }
            return "Desconocido";
        }

        public String Activo(string letra)
        {
            if (letra == "S")
            {
                return "Activo";
            }
            if (letra == "N")
            {
                return "Inactivo";
            }
            return "Desconocido";
        }
    }
}
