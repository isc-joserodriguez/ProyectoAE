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

namespace ProyectoBase.Pages.Menu.FicGestionEventos.EventoHorarios
{
    public class EditModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public EditModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public res_evento_horarios res_evento_horarios { get; set; }
        public int IdEvento = 0;
        public int IdEdificio = 0;

        public async Task<IActionResult> OnGetAsync(int? id, int evento, int edificio)
        {
            IdEvento = evento;
            IdEdificio = edificio;
            getDisponibilidad();
            getDias();
            getEspacios();

            if (id == null)
            {
                return NotFound();
            }
<<<<<<< HEAD

            res_evento_horarios = await _context.res_evento_horarios.SingleOrDefaultAsync(m => m.IdHorarioDet == id);
=======
            res_evento_horarios = await _context.res_evento_horarios.SingleOrDefaultAsync(m => m.IdHorarioDes == id);
>>>>>>> 8330238ef23d9b7223746b2d84516bb679016cde

            if (res_evento_horarios == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            res_evento_horarios.FechaReg = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(res_evento_horarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
<<<<<<< HEAD
                if (!res_evento_horariosExists(res_evento_horarios.IdHorarioDet))
=======
                if (!res_evento_horariosExists(res_evento_horarios.IdHorarioDes))
>>>>>>> 8330238ef23d9b7223746b2d84516bb679016cde
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { id = res_evento_horarios.IdEvento });
        }

        private bool res_evento_horariosExists(int id)
        {
<<<<<<< HEAD
            return _context.res_evento_horarios.Any(e => e.IdHorarioDet == id);
=======
            return _context.res_evento_horarios.Any(e => e.IdHorarioDes == id);
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
>>>>>>> 8330238ef23d9b7223746b2d84516bb679016cde
        }
    }
}
