using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.CatalogoEstatus
{
    public class IndexModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public IndexModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<cat_estatus> cat_estatus { get;set; }

        public async Task OnGetAsync()
        {
            cat_estatus = await _context.cat_estatus.ToListAsync();
        }

        public String Activo(string letra)
        {
            if (letra == "N")
            {
                return "Activo";
            }
            if (letra == "N")
            {
                return "Inactivo";
            }
            return "Desconocido";
        }

        public String TipoEstatus(string ID)
        {
            var Tipos = _context.cat_tipos_estatus;
            foreach (cat_tipos_estatus d in Tipos)
            {
                if (ID == d.IdTipoEstatus.ToString())
                {
                    return d.DesTipoEstatus;
                }
            }
            return "Desconocido";
        }
    }
}
