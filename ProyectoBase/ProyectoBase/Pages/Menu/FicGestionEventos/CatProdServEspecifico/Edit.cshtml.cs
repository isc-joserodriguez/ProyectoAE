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

namespace ProyectoBase.Pages.Menu.FicGestionEventos.CatProdServEspecifico
{
    public class EditModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public EditModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public cat_prod_serv_especifico cat_prod_serv_especifico { get; set; }
        public int IdProdServ { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            IdProdServ = id;

            cat_prod_serv_especifico = await _context.cat_prod_serv_especifico.SingleOrDefaultAsync(m => m.IdProdServEsp == id);

            if (cat_prod_serv_especifico == null)
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

            _context.Attach(cat_prod_serv_especifico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cat_prod_serv_especificoExists(cat_prod_serv_especifico.IdProdServEsp))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { id = cat_prod_serv_especifico.IdProdServ });
        }

        private bool cat_prod_serv_especificoExists(int id)
        {
            return _context.cat_prod_serv_especifico.Any(e => e.IdProdServEsp == id);
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
