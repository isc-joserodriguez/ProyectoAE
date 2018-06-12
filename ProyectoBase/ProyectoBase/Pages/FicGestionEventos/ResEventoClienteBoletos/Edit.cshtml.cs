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

namespace ProyectoBase.Pages.FicGestionEventos.ResEventoClienteBoletos
{
    public class EditModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public EditModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
            getConfirmarAsistencia();
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(res_evento_cliente_boletos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!res_evento_cliente_boletosExists(res_evento_cliente_boletos.IdReservaCliente, res_evento_cliente_boletos.IdEvento, res_evento_cliente_boletos.IdBoleto))
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

        private bool res_evento_cliente_boletosExists(int reserva, int evento, int boleto)
        {
            return _context.res_evento_cliente_boletos.Any(e =>
            e.IdBoleto == boleto &&
            e.IdEvento == evento &&
            e.IdReservaCliente == reserva);
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

        public List<SelectListItem> ConfirmarAsistencia = new List<SelectListItem>();
        public void getConfirmarAsistencia()
        {
            ConfirmarAsistencia.Add(new SelectListItem
            {
                Text = "NO",
                Value = "N"
            });
            ConfirmarAsistencia.Add(new SelectListItem
            {
                Text = "SI",
                Value = "S"
            });
        }
    }
}
