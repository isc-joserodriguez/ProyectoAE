using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.EventoZonas
{
    public class CreateModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public CreateModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int edificio, int espacio, int evento, int horario)
        {
            IdEdificio = edificio;
            IdEspacio = espacio;
            IdEvento = evento;
            IdHorario = horario;
            getZonas();
            return Page();
        }

        [BindProperty]
        public res_evento_zonas res_evento_zonas { get; set; }
        public int IdEdificio { get; set; }
        public int IdEspacio { get; set; }
        public int IdEvento { get; set; }
        public int IdHorario { get; set; }

        public async Task<IActionResult> OnPostAsync(int horario)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            res_evento_zonas.FechaReg = DateTime.Now;
            _context.res_evento_zonas.Add(res_evento_zonas);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new
            {
                edificio = res_evento_zonas.IdEdificio,
                espacio = res_evento_zonas.IdEspacio,
                evento = res_evento_zonas.IdEvento,
                horario = horario
            });
        }

        public String Edificio(string ID)
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

        public String Espacio(string ID)
        {
            var Tipos = _context.eva_cat_espacios;
            foreach (eva_cat_espacios d in Tipos)
            {
                if (ID == d.IdEspacio.ToString())
                {
                    return d.Clave;
                }
            }
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

        public List<SelectListItem> Zonas = new List<SelectListItem>();
        public void getZonas()
        {
            var Tipos = _context.res_cat_zonas;
            foreach (res_cat_zonas d in Tipos)
            {
                if(IdEdificio == d.IdEdificio && IdEspacio == d.IdEspacio)
                    if(valido(d.IdZona))
                    Zonas.Add(new SelectListItem
                    {
                        Text = d.DesZona,
                        Value = d.IdZona.ToString()
                    });
            }
        }

        public Boolean valido(int idZona) {
            var Tipos = _context.res_evento_zonas;
            foreach (res_evento_zonas d in Tipos)
            {
                if (IdEdificio == d.IdEdificio && IdEspacio == d.IdEspacio && IdEvento == d.IdEvento && idZona == d.IdZona)
                    return false;
            }
            return true;
        }
    }
}