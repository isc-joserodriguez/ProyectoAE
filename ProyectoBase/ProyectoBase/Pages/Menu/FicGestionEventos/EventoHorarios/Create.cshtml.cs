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
        public int IdEvento { get; set; }
        public int IdEdificio { get; set; }

        [BindProperty]
        public res_evento_horarios res_evento_horarios { get; set; }

        public CreateModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGetAsync(int id, int edificio)
        {
            IdEvento = id;
            IdEdificio = edificio;
            getDisponibilidad();
            getEspacios();
            return Page();
        }

        

        public async Task<IActionResult> OnPostAsync()
        {
            res_evento_horarios.FechaReg = DateTime.Now;
            res_evento_horarios.Dia = getDia(res_evento_horarios.FechaHoraIni.DayOfWeek);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.res_evento_horarios.Add(res_evento_horarios);
            await _context.SaveChangesAsync();
            return RedirectToPage("./index", new { id = res_evento_horarios.IdEvento});
        }

        public List<SelectListItem> Espacio = new List<SelectListItem>();
        public void getEspacios()
        {
            var Tipos = _context.eva_cat_espacios;
            foreach (eva_cat_espacios d in Tipos)
            {
                    if (d.IdEdificio == IdEdificio)
                        Espacio.Add(new SelectListItem
                        {
                            Text = d.Clave,
                            Value = d.IdEspacio.ToString()
                        });
            }
        }

        public string getDia(DayOfWeek i) {
            if (i.Equals(DayOfWeek.Sunday)) {
                return "Domingo";
            }
            else if (i.Equals(DayOfWeek.Monday))
            {
                return "Lunes";
            }
            else if (i.Equals(DayOfWeek.Thursday))
            {
                return "Jueves";
            }
            else if (i.Equals(DayOfWeek.Wednesday))
            {
                return "Miercoles";
            }
            else if (i.Equals(DayOfWeek.Tuesday))
            {
                return "Martes";
            }
            else if (i.Equals(DayOfWeek.Friday))
            {
                return "Viernes";
            }
            else return "Sábado";
        }

        public List<SelectListItem> Disponibilidad = new List<SelectListItem>();
        public void getDisponibilidad()
        {
            Disponibilidad.Add(new SelectListItem { Text = "Disponible", Value = "S" });
            Disponibilidad.Add(new SelectListItem { Text = "No Disponible", Value = "N" });
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

        public String Edificio(string ID)
        {
            var Tipos = _context.eva_cat_edificios;
            foreach (eva_cat_edificios d in Tipos)
            {
                if (ID == d.IdEdificio.ToString())
                {
                    return d.DesEdificio;
                }
            }
            return "Desconocido";
        }
    }
}