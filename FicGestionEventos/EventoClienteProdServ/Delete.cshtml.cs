using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.EventoClienteProdServ
{
    public class DeleteModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public DeleteModel(ProyectoBase.Models.ApplicationDbContext context)
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

            res_evento_cliente_prod_serv = await _context.res_evento_cliente_prod_serv.SingleOrDefaultAsync(m => m.Id == id);

            if (res_evento_cliente_prod_serv == null)
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

            res_evento_cliente_prod_serv = await _context.res_evento_cliente_prod_serv.FindAsync(id);

            if (res_evento_cliente_prod_serv != null)
            {
                _context.res_evento_cliente_prod_serv.Remove(res_evento_cliente_prod_serv);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
