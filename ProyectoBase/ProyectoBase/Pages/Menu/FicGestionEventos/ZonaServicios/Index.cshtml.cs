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
    public class IndexModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public IndexModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<res_zonas_servicios> res_zonas_servicios { get;set; }

        public async Task OnGetAsync()
        {
            res_zonas_servicios = await _context.res_zonas_servicios.ToListAsync();
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
