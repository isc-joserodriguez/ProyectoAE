using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.Menu.FicGestionEventos.Eventos
{
    public class CreateModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public CreateModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
            getGenerales();
            getPersonas();
            getEdificios();
        }

        public IActionResult OnGet()
        {
            

            return Page();
        }

        [BindProperty]
        public res_eventos res_eventos { get; set; }
        public List<SelectListItem> Generales = new List<SelectListItem>();
        public List<SelectListItem> Personas = new List<SelectListItem>();
        public List<SelectListItem> Edificios = new List<SelectListItem>();

        public async Task<IActionResult> OnPostAsync()
        {

            res_eventos.FechaReg = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return Page();
            }


            _context.res_eventos.Add(res_eventos);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public void getGenerales()
        {
            var Tipos = _context.cat_generales;
            Generales.Add(new SelectListItem
            {
                Text = "Conferencia",
                Value = "1"
            });
            Generales.Add(new SelectListItem
            {
                Text = "Seminario",
                Value = "2"
            });
            Generales.Add(new SelectListItem
            {
                Text = "Curso",
                Value = "3"
            });
        }

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

        public DateTime getFecha() {
            return DateTime.Today;
        }

    }
}