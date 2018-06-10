using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.Menu.FicGestionEventos.ResEventoClienteBoletos
{
    public class CreateModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public CreateModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
            getPersonas();
        }

        public IActionResult OnGet( int cliente, int evento, int boleto, int edificio, int espacio)
        {
            IdCliente = cliente;
            IdEvento = evento;
            IdBoleto = boleto;
            IdEdificio = edificio;
            IdEspacio = espacio;
            return Page();
        }

        [BindProperty]
        public res_evento_cliente_boletos res_evento_cliente_boletos { get; set; }
        public int IdCliente { get; set; }
        public int IdEvento { get; set; }
        public int IdBoleto { get; set; }
        public int IdEdificio { get; set; }
        public int IdEspacio { get; set; }

        public async Task<IActionResult> OnPostAsync(int id_, int edificio_, int espacio_, int evento_)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.res_evento_cliente_boletos.Add(res_evento_cliente_boletos);
            await _context.SaveChangesAsync();

            return RedirectToPage("../EventoZonaBoletosVenta/Index", new { id = id_, edificio = edificio_, espacio = espacio_, evento = evento_ });
        }

        public List<SelectListItem> Personas = new List<SelectListItem>();
        public void getPersonas()
        {
            var Tipos = _context.rh_cat_personas;
            foreach (rh_cat_personas d in Tipos)
            {
                Personas.Add(new SelectListItem
                {
                    Text = d.Nombre,
                    Value = d.IdPersona.ToString()
                });
            }
        }
    }
}