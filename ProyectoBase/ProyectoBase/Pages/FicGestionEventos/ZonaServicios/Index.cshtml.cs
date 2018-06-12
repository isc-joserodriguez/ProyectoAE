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
    public class IndexModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public IndexModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<res_zonas_servicios> res_zonas_servicios { get;set; }
        public res_cat_zonas res_cat_zonas { get; set; }
        public int IdEspacio { get; set; }
        public int IdEdificio { get; set; }
        public int IdZona { get; set; }

        public async Task<IActionResult> OnGetAsync(
            int edificio,
            int espacio,
            int zona)
        {
            IQueryable<res_zonas_servicios> ZonasServicios = from s in _context.res_zonas_servicios
                                                        select s;

            IdEdificio = edificio;
            IdEspacio = espacio;
            IdZona = zona;
            res_zonas_servicios = await _context
                .res_zonas_servicios
                .ToListAsync();
            res_cat_zonas = await _context
                .res_cat_zonas
                .SingleOrDefaultAsync(m => m.IdZona == zona);

            if (res_zonas_servicios == null)
            {
                return NotFound();
            }

            res_zonas_servicios = await ZonasServicios.Where(m => m.IdEspacio == espacio && m.IdEdificio == edificio && m.IdZona == zona).AsNoTracking().ToListAsync();
            return Page();
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
    }
}
