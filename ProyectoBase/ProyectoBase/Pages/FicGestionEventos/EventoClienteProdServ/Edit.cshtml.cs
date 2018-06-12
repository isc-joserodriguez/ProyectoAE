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

namespace ProyectoBase.Pages.FicGestionEventos.EventoClienteProdServ
{
    public class EditModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public EditModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public res_evento_cliente_prod_serv res_evento_cliente_prod_serv { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            res_evento_cliente_prod_serv = await _context.res_evento_cliente_prod_serv.SingleOrDefaultAsync(m => m.IdReservaServDet == id);

            if (res_evento_cliente_prod_serv == null)
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

            _context.Attach(res_evento_cliente_prod_serv).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!res_evento_cliente_prod_servExists(res_evento_cliente_prod_serv.IdReservaServDet))
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

        private bool res_evento_cliente_prod_servExists(int id)
        {
            return _context.res_evento_cliente_prod_serv.Any(e => e.IdReservaServDet == id);
        }
    }
}
