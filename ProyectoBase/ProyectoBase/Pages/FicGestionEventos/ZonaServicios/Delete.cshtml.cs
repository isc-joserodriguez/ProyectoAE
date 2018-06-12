using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.ZonaServicios
{
    public class DeleteModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public DeleteModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public res_zonas_servicios res_zonas_servicios { get; set; }

        public async Task<IActionResult> OnGetAsync(
            int edificio,
            int espacio,
            int zona,
            int prodserv,
            int prodservesp)
        {
            

            res_zonas_servicios = await _context.res_zonas_servicios.SingleOrDefaultAsync(m =>
                m.IdEdificio == edificio &&
                m.IdEspacio == espacio &&
                m.IdZona == zona &&
                m.IdProdServ == prodserv &&
                m.IdProdServEsp == prodservesp);

            if (res_zonas_servicios == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(
            int edificio,
            int espacio,
            int zona,
            int prodserv,
            int prodservesp)
        {

            res_zonas_servicios = await _context.res_zonas_servicios.SingleOrDefaultAsync(m =>
                m.IdEdificio == edificio &&
                m.IdEspacio == espacio &&
                m.IdZona == zona &&
                m.IdProdServ == prodserv &&
                m.IdProdServEsp == prodservesp);

            if (res_zonas_servicios != null)
            {
                _context.res_zonas_servicios.Remove(res_zonas_servicios);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { edificio = res_zonas_servicios.IdEdificio, espacio = res_zonas_servicios.IdEspacio, zona = res_zonas_servicios.IdZona });
        }

        public String getEdificio(string ID)
        {
            var Tipos = _context.eva_cat_edificios;
            foreach (eva_cat_edificios d in Tipos)
            {
                if (ID == d.IdEdificio.ToString())
                {
                    return d.Clave;
                }
            }
            return "Desconocido";
        }

        public String getEspacio(string ID)
        {
            var Tipos = _context.eva_cat_espacios;
            foreach (eva_cat_espacios d in Tipos)
            {
                if (ID == d.IdEspacio.ToString())
                {
                    return d.Alias;
                }
            }
            return "Desconocido";
        }

        public String getProductoServicio(string ID)
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

        public String getProductoServicioEsp(string ID)
        {
            var Tipos = _context.cat_prod_serv_especifico;
            foreach (cat_prod_serv_especifico d in Tipos)
            {
                if (ID == d.IdProdServEsp.ToString())
                {
                    return d.ClaveProdServEsp;
                }
            }
            return "Desconocido";
        }

        public String getZona(string ID)
        {
            var Tipos = _context.res_cat_zonas;
            foreach (res_cat_zonas d in Tipos)
            {
                if (ID == d.IdZona.ToString())
                {
                    return d.DesZona;
                }
            }
            return "Desconocido";
        }
    }
}
