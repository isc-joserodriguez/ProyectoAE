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

namespace ProyectoBase.Pages.Menu.FicGestionEventos.EventoServicios
{
    public class EditModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public EditModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
            getTiposGenerales();
            getTiposProdServEsp();
            getRequerido();
        }

        [BindProperty]
        public res_evento_servicios res_evento_servicios { get; set; }
        public int IdEvento { get; set; }

        public async Task<IActionResult> OnGetAsync(int id, int evento)
        {
            if (SeleccionoProductoServicio()) { getTiposProdServEsp(); }
            else
            {
                IdEvento = evento;
            }

            res_evento_servicios = await _context.res_evento_servicios.SingleOrDefaultAsync(m => m.IdEventoServ == id);

            if (res_evento_servicios == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (SeleccionoProductoServicio())
            {
                getTiposProdServEsp();
                IdEvento = res_evento_servicios.IdEvento;
            }
            if (!ModelState.IsValid || res_evento_servicios.IdEvento == 0)
            {
                return Page();
            }

            if (res_evento_servicios.Requerido != "S" && res_evento_servicios.Requerido != "N") res_evento_servicios.Requerido = "S";

            _context.Attach(res_evento_servicios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!res_evento_serviciosExists(res_evento_servicios.IdEventoServ))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { id = res_evento_servicios.IdEvento });
        }

        private bool res_evento_serviciosExists(int id)
        {
            return _context.res_evento_servicios.Any(e => e.IdEventoServ == id);
        }

        public List<SelectListItem> TiposProdServ = new List<SelectListItem>();
        public void getTiposGenerales()
        {
            var Tipos = _context.cat_productos_servicios;
            foreach (cat_productos_servicios d in Tipos)
            {
                TiposProdServ.Add(new SelectListItem
                {
                    Text = d.ClaveProdServ,
                    Value = d.IdProdServ.ToString()
                });
            }
        }

        public List<SelectListItem> Requerido = new List<SelectListItem>();
        public void getRequerido()
        {
            Requerido.Add(new SelectListItem
            {
                Text = "SI",
                Value = "S"
            });
            Requerido.Add(new SelectListItem
            {
                Text = "NO",
                Value = "N"
            });
        }

        public List<SelectListItem> TiposProdServEsp = new List<SelectListItem>();
        public void getTiposProdServEsp()
        {
            var Tipos = _context.cat_prod_serv_especifico;

            foreach (cat_prod_serv_especifico d in Tipos)
            {
                if (res_evento_servicios != null)
                    if (res_evento_servicios.IdProdServ == d.IdProdServ)
                        TiposProdServEsp.Add(new SelectListItem
                        {
                            Text = d.ClaveProdServEsp,
                            Value = d.IdProdServEsp.ToString()
                        });
            }
        }

        public Boolean SeleccionoProductoServicio()
        {
            if (res_evento_servicios != null)
            {
                var Tipos = _context.cat_productos_servicios;
                int select = res_evento_servicios.IdProdServ; ;
                foreach (cat_productos_servicios d in Tipos)
                {
                    if (select == d.IdProdServ)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
