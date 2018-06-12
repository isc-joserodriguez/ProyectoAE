using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.CatProductoServicios
{
    public class EditModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public EditModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
            getProductosServicios();
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(cat_productos_servicios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cat_productos_serviciosExists(cat_productos_servicios.IdProdServ))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool cat_productos_serviciosExists(int id)
        {
            return _context.cat_productos_servicios.Any(e => e.IdProdServ == id);
        }

        public List<SelectListItem> ProductoServicio = new List<SelectListItem>();
        public void getProductosServicios()
        {
            var Tipos = _context.cat_generales;
            ProductoServicio.Add(new SelectListItem
            {
                Text = "Producto",
                Value = "P"
            });
            ProductoServicio.Add(new SelectListItem
            {
                Text = "Servicio",
                Value = "S"
            });
        }
    }
}
