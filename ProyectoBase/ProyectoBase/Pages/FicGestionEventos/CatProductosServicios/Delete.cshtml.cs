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
    public class DeleteModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public DeleteModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public cat_productos_servicios cat_productos_servicios { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            cat_productos_servicios = await _context.cat_productos_servicios.SingleOrDefaultAsync(m => m.IdProdServ == id);

            if (cat_productos_servicios == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            cat_productos_servicios = await _context.cat_productos_servicios.FindAsync(id);

            if (cat_productos_servicios != null)
            {
                _context.cat_productos_servicios.Remove(cat_productos_servicios);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

        public String getProductoServicio(String valor) {
            if (valor.Equals("P")) return "Producto";
            if (valor.Equals("S")) return "Servicio";
            return "Descnocido";
        }
    }
}
