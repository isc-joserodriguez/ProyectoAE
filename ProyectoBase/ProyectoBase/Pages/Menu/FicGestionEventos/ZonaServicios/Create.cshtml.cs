using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.Menu.FicGestionEventos.ZonaServicios
{
    public class CreateModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public CreateModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
            
        }

        public IActionResult OnGet(int edificio,
            int espacio,
            int zona)
        {
            IdEspacio = espacio;
            IdEdificio = edificio;
            IdZona = zona;
            getProdServEsp();
            return Page();
        }

        [BindProperty]
        public res_zonas_servicios res_zonas_servicios { get; set; }
        public int IdEdificio { get; set; }
        public int IdEspacio { get; set; }
        public int IdZona { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            res_zonas_servicios.IdProdServ = getIDProductoServicio(res_zonas_servicios.IdProdServEsp);

            _context.res_zonas_servicios.Add(res_zonas_servicios);
            await _context.SaveChangesAsync();

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

        public List<SelectListItem> ProdServEsp = new List<SelectListItem>();
        public void getProdServEsp()
        {
            var Tipos = _context.cat_prod_serv_especifico;
            foreach (cat_prod_serv_especifico d in Tipos)
            {
                if (existe(IdEdificio, IdEspacio, IdZona, d.IdProdServ, d.IdProdServEsp))
                {
                    if(esProducto(d.IdProdServ.ToString()))
                    ProdServEsp.Add(new SelectListItem
                    {
                        Text = getProductoServicio(d.IdProdServ.ToString()) + " - " + d.ClaveProdServEsp,
                        Value = d.IdProdServEsp.ToString()
                    });
                }
            }
        }
        
        public Boolean esProducto(string ID)
        {
            var Tipos = _context.cat_productos_servicios;
            foreach (cat_productos_servicios d in Tipos)
            {
                if (ID == d.IdProdServ.ToString())
                {

                    return d.ProductoServicio.Equals("S");
                }
            }
            return false;
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

        public int getIDProductoServicio(int ID)
        {
            var Tipos = _context.cat_prod_serv_especifico;
            foreach (cat_prod_serv_especifico d in Tipos)
            {
                if(ID == d.IdProdServEsp)
                    return d.IdProdServ;
            }
            return -1;
        }

        public Boolean existe(int IdEdificio, int IDEspacio, int IdZona, int PS, int PSE) {
            var Tipos = _context.res_zonas_servicios;
            foreach (res_zonas_servicios d in Tipos)
            {
                if (IdEdificio == d.IdEdificio && IDEspacio == d.IdEspacio && IdZona == d.IdZona && PS == d.IdProdServ && PSE == d.IdProdServEsp)
                {
                    return false;
                }
            }
            return true; ;
        }
    }
}