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

namespace ProyectoBase.Pages.Menu.FicGestionEventos.ZonaServicios
{
    public class EditModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public EditModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public res_zonas_servicios res_zonas_servicios { get; set; }

        public List<SelectListItem> Edificios = new List<SelectListItem>();
        public List<SelectListItem> Espacios = new List<SelectListItem>();
        public List<SelectListItem> Zonas = new List<SelectListItem>();
        public List<SelectListItem> ProdServ= new List<SelectListItem>();
        public List<SelectListItem> ProdServEsp = new List<SelectListItem>();

        public async Task<IActionResult> OnGetAsync(
            int? IdEdificio,
            int? IdEspacio,
            int? IdZona,
            int? IdProdServ,
            int? IdProdServEsp)
        {
            if (IdEdificio == null || IdEspacio ==null || IdZona == null || IdProdServ == null || IdProdServEsp == null)
            {
                return NotFound();
            }

            getEdificio();
            getEspacio();
            getZona();
            getProdServEsp();
            getProdServ();



            res_zonas_servicios = await _context
                .res_zonas_servicios
                .SingleOrDefaultAsync(m => m.IdEdificio == IdEdificio &&
                                           m.IdEspacio == IdEspacio &&
                                           m.IdZona == IdZona &&
                                           m.IdProdServ == IdProdServ &&
                                           m.IdProdServEsp == IdProdServEsp);

            if (res_zonas_servicios == null)
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

            _context.Attach(res_zonas_servicios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!res_zonas_serviciosExists(res_zonas_servicios.IdEdificio,
                                               res_zonas_servicios.IdEspacio,
                                               res_zonas_servicios.IdZona,
                                               res_zonas_servicios.IdProdServ,
                                               res_zonas_servicios.IdProdServEsp))
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

        private bool res_zonas_serviciosExists(int? IdEdificio,
            int? IdEspacio,
            int? IdZona,
            int? IdProdServ,
            int? IdProdServEsp)
        {
            return _context.res_zonas_servicios.Any(m => m.IdEdificio == IdEdificio &&
                                           m.IdEspacio == IdEspacio &&
                                           m.IdZona == IdZona &&
                                           m.IdProdServ == IdProdServ &&
                                           m.IdProdServEsp == IdProdServEsp);
        }

        public void getProdServEsp()
        {
            var Tipos = _context.cat_prod_serv_especifico;
            foreach (cat_prod_serv_especifico d in Tipos)
            {
                ProdServEsp.Add(new SelectListItem
                {
                    Text = d.DesProdServEsp,
                    Value = d.IdProdServEsp.ToString()
                });
            }
        }

        public void getEdificio()
        {
            var Tipos = _context.eva_cat_edificios;
            foreach (eva_cat_edificios d in Tipos)
            {
                Edificios.Add(new SelectListItem
                {
                    Text = d.Alias,
                    Value = d.IdEdificio.ToString()
                });
            }
        }

        public void getEspacio()
        {
            var Tipos = _context.eva_cat_espacios;
            foreach (eva_cat_espacios d in Tipos)
            {
                Espacios.Add(new SelectListItem
                {
                    Text = d.Alias,
                    Value = d.IdEspacio.ToString()
                });
            }
        }

        public void getZona()
        {
            var Tipos = _context.res_cat_zonas;
            foreach (res_cat_zonas d in Tipos)
            {
                Zonas.Add(new SelectListItem
                {
                    Text = d.DesZona,
                    Value = d.IdZona.ToString()
                });
            }
        }

        public void getProdServ()
        {
            var Tipos = _context.cat_productos_servicios;
            foreach (cat_productos_servicios d in Tipos)
            {
                ProdServ.Add(new SelectListItem
                {
                    Text = d.DesProdServ,
                    Value = d.IdProdServ.ToString()
                });
            }
        }
    }
}