using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.CatProdServEspecifico
{
    public class CreateModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public CreateModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            IdProdServ = id;
            return Page();
        }

        [BindProperty]
        public cat_prod_serv_especifico cat_prod_serv_especifico { get; set; }
        public int IdProdServ { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.cat_prod_serv_especifico.Add(cat_prod_serv_especifico);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id= cat_prod_serv_especifico.IdProdServ });
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