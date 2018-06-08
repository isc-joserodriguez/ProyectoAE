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
    public class DeleteModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public DeleteModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public cat_prod_serv_especifico cat_prod_serv_especifico { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            cat_prod_serv_especifico = await _context.cat_prod_serv_especifico.SingleOrDefaultAsync(m => m.IdProdServEsp == id);

            if (cat_prod_serv_especifico == null)
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

            cat_prod_serv_especifico = await _context.cat_prod_serv_especifico.SingleOrDefaultAsync(m => m.IdProdServEsp == id);

            if (cat_prod_serv_especifico != null)
            {
                _context.cat_prod_serv_especifico.Remove(cat_prod_serv_especifico);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { id = cat_prod_serv_especifico.IdProdServ });
        }

        public String getProdServ(string ID)
        {
            var Tipos = _context.cat_productos_servicios;
            foreach (cat_productos_servicios d in Tipos)
            {
                if (ID == d.IdProdServ.ToString())
                {
                    return d.ClaveProdServ;
                }
            }
            return "Desconocido";
        }
    }
}
