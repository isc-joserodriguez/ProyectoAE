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

namespace ProyectoBase.Pages.FicGestionEventos.CatalogoEstatus
{
    public class EditModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public EditModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
            getTipoEstatus();
            getActivo();
        }

        [BindProperty]
        public cat_estatus cat_estatus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            cat_estatus = await _context.cat_estatus.SingleOrDefaultAsync(m => m.IdEstatus == id);

            if (cat_estatus == null)
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

            _context.Attach(cat_estatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cat_estatusExists(cat_estatus.IdEstatus))
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

        private bool cat_estatusExists(int id)
        {
            return _context.cat_estatus.Any(e => e.IdEstatus == id);
        }

        public List<SelectListItem> Activo = new List<SelectListItem>();
        public void getActivo()
        {
            //if(d.Activo.Equals("A"))
            Activo.Add(new SelectListItem
            {
                Text = "Activo",
                Value = "S"
            });
            Activo.Add(new SelectListItem
            {
                Text = "Inactivo",
                Value = "N"
            });
        }

        public List<SelectListItem> TipoEstatus = new List<SelectListItem>();
        public void getTipoEstatus()
        {
            var Tipos = _context.cat_tipos_estatus;
            foreach (cat_tipos_estatus d in Tipos)
            {
                if (d.Activo.Equals("S"))
                TipoEstatus.Add(new SelectListItem
                {
                    Text = d.DesTipoEstatus,
                    Value = d.IdTipoEstatus.ToString()
                });
            }
        }
    }
}
