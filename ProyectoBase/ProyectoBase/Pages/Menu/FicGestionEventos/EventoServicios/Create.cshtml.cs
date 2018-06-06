using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.Menu.FicGestionEventos.EventoServicios
{
    public class CreateModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public CreateModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
            getTiposGenerales();
            getTiposProdServEsp();
            getRequerido();
        }

        public IActionResult OnGet(int id)
        {

            if (SeleccionoProductoServicio()) { getTiposProdServEsp(); }
            else {
                IdEvento = id;
            }
            return Page();
        }

        [BindProperty]
        public res_evento_servicios res_evento_servicios { get; set; }
        public int IdEvento { get; set; }
        public Boolean seRepiteRegistro { get; set; } = false ;

        public async Task<IActionResult> OnPostAsync()
        {
            if (SeleccionoProductoServicio()) {
                getTiposProdServEsp();
                IdEvento = res_evento_servicios.IdEvento;
            }
            if (!ModelState.IsValid || res_evento_servicios.IdEvento==0)
            {
                return Page();
            }

            if (seRepite(
                res_evento_servicios.IdEvento,
                res_evento_servicios.Requerido,
                res_evento_servicios.IdProdServ,
                res_evento_servicios.IdProdServEsp)) {
                seRepiteRegistro = true;
                    return Page();
            }

            if (res_evento_servicios.Requerido != "S" && res_evento_servicios.Requerido != "N") res_evento_servicios.Requerido = "S";

            _context.res_evento_servicios.Add(res_evento_servicios);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id = res_evento_servicios.IdEvento});
        }

        public List<SelectListItem> TiposProdServ = new List<SelectListItem>();
        public void getTiposGenerales()
        {
            var Tipos = _context.cat_productos_servicios;
            foreach (cat_productos_servicios d in Tipos)
            {
                //if(d.Activo.Equals("A"))
                TiposProdServ.Add(new SelectListItem
                {
                    Text = d.ClaveProdServ,
                    Value = d.IdProdServ.ToString()
                });
            }
        }

        public List<SelectListItem> Requerido = new List<SelectListItem>();
        public void getRequerido()
        {
                Requerido.Add(new SelectListItem
                {
                    Text = "SI",
                    Value = "S"
                });
                Requerido.Add(new SelectListItem
                {
                    Text = "NO",
                    Value = "N"
                });
        }

        public List<SelectListItem> TiposProdServEsp = new List<SelectListItem>();
        public void getTiposProdServEsp()
        {
            var Tipos = _context.cat_prod_serv_especifico;

            foreach (cat_prod_serv_especifico d in Tipos) {
                if(res_evento_servicios != null)
                    if ( res_evento_servicios.IdProdServ == d.IdProdServ)
                    TiposProdServEsp.Add(new SelectListItem
                    {
                        Text = d.ClaveProdServEsp,
                        Value = d.IdProdServEsp.ToString()
                    });
            }
        }

        public Boolean SeleccionoProductoServicio()
        {
            if (res_evento_servicios != null)
            {
                var Tipos = _context.cat_productos_servicios;
                int select = res_evento_servicios.IdProdServ; ;
                foreach (cat_productos_servicios d in Tipos)
                {
                    if (select == d.IdProdServ)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Boolean seRepite(int evento, string requerido, int prodserv, int prodservesp)
        {
            var Tipos = _context.res_evento_servicios;
            foreach (res_evento_servicios d in Tipos)
            {
                if (d.IdEvento == evento && d.Requerido.Equals(requerido) && d.IdProdServ == prodserv && d.IdProdServEsp == prodservesp) {
                    return true;
                }
            }
            return false;
        }
    }
}