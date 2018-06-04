using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.Menu.FicGestionEventos.CatProdServEspecifico
{
    public class IndexModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public IndexModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<cat_prod_serv_especifico> cat_prod_serv_especifico { get; set; }
        public cat_productos_servicios cat_productos_servicios { get; set; }
        public int IdProdServ { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            IQueryable<cat_prod_serv_especifico> tabla = from s in _context.cat_prod_serv_especifico
                                                         select s;
            if (id == null)
            {
                return NotFound();
            }

            cat_prod_serv_especifico = await _context.cat_prod_serv_especifico.ToListAsync();
            cat_productos_servicios = await _context.cat_productos_servicios.SingleOrDefaultAsync(m => m.IdProdServ == id);

            if (cat_productos_servicios == null)
            {
                return NotFound();
            }

            IdProdServ = cat_productos_servicios.IdProdServ;
            cat_prod_serv_especifico = await tabla.Where(m => m.IdProdServ == id).AsNoTracking().ToListAsync();

            return Page();
        }

        public String getProductoServicio(String valor)
        {
            if (valor.Equals("P")) return "Producto";
            if (valor.Equals("S")) return "Servicio";
            return "Descnocido";
        }
    }
}
