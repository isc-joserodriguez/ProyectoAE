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
        public int IdEvento = 0;
        public int IdEdificio = 0;

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
            getDias();
            getEspacios();
            return Page();
        }

        

        public async Task<IActionResult> OnPostAsync()
        {
            res_evento_horarios.FechaReg = DateTime.Now;
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