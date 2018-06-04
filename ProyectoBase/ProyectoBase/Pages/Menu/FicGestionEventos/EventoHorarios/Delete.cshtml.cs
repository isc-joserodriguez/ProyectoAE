using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.Menu.FicGestionEventos.EventoHorarios
{
    public class DeleteModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public DeleteModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public res_evento_horarios res_evento_horarios { get; set; }
        public int IdEvento { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int evento)
        {
            if (id == null)
            {
                return NotFound();
            }
<<<<<<< HEAD

            res_evento_horarios = await _context.res_evento_horarios.SingleOrDefaultAsync(m => m.IdHorarioDet == id);
=======
            IdEvento = evento;
            res_evento_horarios = await _context.res_evento_horarios.SingleOrDefaultAsync(m => m.IdHorarioDes == id);
>>>>>>> 8330238ef23d9b7223746b2d84516bb679016cde

            if (res_evento_horarios == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            res_evento_horarios = await _context.res_evento_horarios.FindAsync(id);

            if (res_evento_horarios != null)
            {
                _context.res_evento_horarios.Remove(res_evento_horarios);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { id= res_evento_horarios.IdEvento});
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
    }
}
