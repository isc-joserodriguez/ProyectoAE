using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.EventoServicios
{
    public class DeleteModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public DeleteModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public res_evento_servicios res_evento_servicios { get; set; }
        public int IdEvento { get; set; }
        public String Requerido { get; set; }
        public int IdProdServ { get; set; }
        public int IdProdServEsp { get; set; }

        public async Task<IActionResult> OnGetAsync(int evento, string requerido, int prodserv, int prodservesp)
        {
            IdEvento = evento;
            Requerido = requerido;
            IdProdServ = prodserv;
            IdProdServEsp = prodservesp;

            res_evento_servicios = await _context.res_evento_servicios.SingleOrDefaultAsync(m =>
            m.IdEvento == evento &&
            m.Requerido.Contains(requerido) &&
            m.IdProdServ == prodserv &&
            m.IdProdServEsp == prodservesp);

            if (res_evento_servicios == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int evento, string requerido, int prodserv, int prodservesp)
        {
            res_evento_servicios = await _context.res_evento_servicios.SingleOrDefaultAsync(m =>
            m.IdEvento == evento &&
            m.Requerido.Contains(requerido) &&
            m.IdProdServ == prodserv &&
            m.IdProdServEsp == prodservesp);

            if (res_evento_servicios != null)
            {
                _context.res_evento_servicios.Remove(res_evento_servicios);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { id = res_evento_servicios.IdEvento});
        }

        public String getProductoServicoEsp(string ID, string PS)
        {
            var Tipos = _context.cat_prod_serv_especifico;
            foreach (cat_prod_serv_especifico d in Tipos)
            {
                if (ID == d.IdProdServEsp.ToString() && PS == d.IdProdServ.ToString())
                {
                    return d.ClaveProdServEsp;
                }
            }
            return "Desconocido";
        }

        public String getRequerido(string ID)
        {
            if (ID.Equals("S")) return "SI";
            if (ID.Equals("N")) return "NO";
            return "Desconocido";
        }

        public String Evento(string ID)
        {
            var Tipos = _context.res_eventos;
            foreach (res_eventos d in Tipos)
            {
                if (ID == d.IdEvento.ToString())
                {
                    return d.NombreEvento;
                }
            }
            return "Desconocido";
        }
    }
}
