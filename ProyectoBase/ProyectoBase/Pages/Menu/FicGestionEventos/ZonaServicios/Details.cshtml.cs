using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.Menu.FicGestionEventos.ZonaServicios
{
    public class DetailsModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public DetailsModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public res_zonas_servicios res_zonas_servicios { get; set; }

        public async Task<IActionResult> OnGetAsync(
            int? IdEdificio,
            int? IdEspacio,
            int? IdZona,
            int? IdProdServ,
            int? IdProdServEsp)
        {
            if (IdEdificio == null || IdEspacio == null || IdZona == null || IdProdServ == null || IdProdServEsp == null)
            {
                return NotFound();
            }

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

        public string getEdificio(int IdEdificio)
        {
            var Tipos = _context.eva_cat_edificios;
            foreach (eva_cat_edificios d in Tipos)
            {
                if (IdEdificio == d.IdEdificio)
                {
                    return d.Alias;
                }
            }
            return "Desconocido";
        }

        public string getEspacio(int IdEspacio)
        {
            var Tipos = _context.eva_cat_espacios;
            foreach (eva_cat_espacios d in Tipos)
            {
                if (IdEspacio == d.IdEspacio)
                {
                    return d.Alias;
                }
            }
            return "Desconocido";
        }

        public string getZona(int IdZona)
        {
            var Tipos = _context.res_cat_zonas;
            foreach (res_cat_zonas d in Tipos)
            {
                if (IdZona == d.IdZona)
                {
                    return d.DesZona;
                }
            }
            return "Desconocida";
        }
       
        public string getProdServ(int IdProdServ)
        {
            var Tipos = _context.cat_productos_servicios;
            foreach (cat_productos_servicios d in Tipos)
            {
                if (IdProdServ == d.IdProdServ)
                {
                    return d.DesProdServ;
                }
            }
            return "Desconocida";
        }

        public string getProdServEsp(int IdProdServEsp)
        {
            var Tipos = _context.cat_prod_serv_especifico;
            foreach (cat_prod_serv_especifico d in Tipos)
            {
                if (IdProdServEsp == d.IdProdServEsp)
                {
                    return d.DesProdServEsp;
                }
            }
            return "Desconocida";
        }
    }
}
