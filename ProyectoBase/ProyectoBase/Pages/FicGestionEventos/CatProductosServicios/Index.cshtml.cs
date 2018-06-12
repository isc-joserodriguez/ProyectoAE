using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.CatProductoServicios
{
    public class IndexModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public IndexModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<cat_productos_servicios> cat_productos_servicios { get; set; }

        public async Task OnGetAsync()
        {
            cat_productos_servicios = await _context.cat_productos_servicios.ToListAsync();
        }

        public String getProductoServicio(String valor) {
            if (valor.Equals("P")) return "Producto";
            if (valor.Equals("S")) return "Servicio";
            return "Desconocido";
        }
    }
}
