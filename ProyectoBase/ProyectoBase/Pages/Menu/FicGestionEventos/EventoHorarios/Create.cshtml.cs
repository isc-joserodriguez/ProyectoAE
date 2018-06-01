using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.Menu.FicGestionEventos.EventoHorarios
{
    public class CreateModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public CreateModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
            getDisponibilidad();
            getDias();
            getEventos();
            getEdificios();
            getEspacios();
        }

        public IActionResult OnGet()
        {
            
            return Page();
        }

        [BindProperty]
        public res_evento_horarios res_evento_horarios { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (SeleccionoEspacio()) getEspacios();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.res_evento_horarios.Add(res_evento_horarios);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public Boolean SeleccionoEspacio()
        {
            var Tipos = _context.eva_cat_espacios;
            int select = res_evento_horarios.IdEdificio;
            foreach (eva_cat_espacios d in Tipos)
            {
                if (select == d.IdEdificio)
                {
                    return true;
                }
            }
            return false;
        }

        public List<SelectListItem> Espacio = new List<SelectListItem>();
        public void getEspacios()
        {
            var Tipos = _context.eva_cat_espacios;
            foreach (eva_cat_espacios d in Tipos)
            {
                if (res_evento_horarios != null)
                    if (d.IdEdificio == res_evento_horarios.IdEdificio)
                        Espacio.Add(new SelectListItem
                        {
                            Text = d.Clave,
                            Value = d.IdEspacio.ToString()
                        });
            }
        }

        public List<SelectListItem> Edificios = new List<SelectListItem>();
        public void getEdificios()
        {
            var Tipos = _context.eva_cat_edificios;
            foreach (eva_cat_edificios d in Tipos)
            {
                Edificios.Add(new SelectListItem
                {
                    Text = d.Clave,
                    Value = d.IdEdificio.ToString()
                });
            }
        }

        public List<SelectListItem> Eventos = new List<SelectListItem>();
        public void getEventos()
        {
            var Tipos = _context.res_eventos;
            foreach (res_eventos d in Tipos)
            {
                Eventos.Add(new SelectListItem
                {
                    Text = d.NombreEvento,
                    Value = d.IdEvento.ToString()
                });
            }
        }

        public List<SelectListItem> Dias = new List<SelectListItem>();
        public void getDias()
        {
            Dias.Add(new SelectListItem { Text = "Domingo", Value = "Domingo" });
            Dias.Add(new SelectListItem { Text = "Lunes", Value = "Lunes" });
            Dias.Add(new SelectListItem { Text = "Martes", Value = "Martes" });
            Dias.Add(new SelectListItem { Text = "Miercoles", Value = "Miercoles" });
            Dias.Add(new SelectListItem { Text = "Jueves", Value = "Jueves" });
            Dias.Add(new SelectListItem { Text = "Viernes", Value = "Viernes" });
            Dias.Add(new SelectListItem { Text = "Sabado", Value = "Sabado" });

        }

        public List<SelectListItem> Disponibilidad = new List<SelectListItem>();
        public void getDisponibilidad()
        {
            Disponibilidad.Add(new SelectListItem { Text = "Disponible", Value = "S" });
            Disponibilidad.Add(new SelectListItem { Text = "No Disponible", Value = "N" });
        }
    }
}