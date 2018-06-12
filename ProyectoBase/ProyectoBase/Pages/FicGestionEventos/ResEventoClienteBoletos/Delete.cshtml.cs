using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.ResEventoClienteBoletos
{
    public class DeleteModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public DeleteModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public res_evento_cliente_boletos res_evento_cliente_boletos { get; set; }
        public int IdReserva { get; set; }
        public int IdEvento { get; set; }
        public int IdBoleto { get; set; }

        public async Task<IActionResult> OnGetAsync(int reserva, int evento, int boleto)
        {
            IdReserva = reserva;
            IdEvento = evento;
            IdBoleto = boleto;

            res_evento_cliente_boletos = await _context.res_evento_cliente_boletos.SingleOrDefaultAsync(m =>
            m.IdBoleto == boleto &&
            m.IdEvento == evento &&
            m.IdReservaCliente == reserva);

            if (res_evento_cliente_boletos == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int reserva, int evento, int boleto)
        {

            res_evento_cliente_boletos = await _context.res_evento_cliente_boletos.SingleOrDefaultAsync(m =>
            m.IdBoleto == boleto &&
            m.IdEvento == evento &&
            m.IdReservaCliente == reserva);

            if (res_evento_cliente_boletos != null)
            {
                _context.res_evento_cliente_boletos.Remove(res_evento_cliente_boletos);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

        public String getEvento(string ID)
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

        public String getPersonaReg(string ID)
        {
            var Tipos = _context.rh_cat_personas;
            foreach (rh_cat_personas d in Tipos)
            {
                if (ID == d.IdPersona.ToString())
                {
                    return d.Nombre;
                }
            }
            return "Desconocido";
        }
    }
}
