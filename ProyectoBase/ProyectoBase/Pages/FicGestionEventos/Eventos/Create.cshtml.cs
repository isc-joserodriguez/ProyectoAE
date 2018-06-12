using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.Eventos
{
    public class CreateModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public CreateModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
            rh_cat_personas = _context.rh_cat_personas.ToList();
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
        public List<rh_cat_personas> rh_cat_personas { get; set; }

        public async Task<IActionResult> OnPostAsync(string persona)
        {

            res_eventos.FechaReg = DateTime.Now;
            res_eventos.IdPersonaReg = buscar(persona);
            if (!ModelState.IsValid || res_eventos.IdPersonaReg==-1)
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
                Value = "63"
            });
            Generales.Add(new SelectListItem
            {
                Text = "Seminario",
                Value = "64"
            });
            Generales.Add(new SelectListItem
            {
                Text = "Curso",
                Value = "65"
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

        public int buscar(string persona)
        {
            var Tipos = _context.rh_cat_personas;
            foreach (rh_cat_personas d in Tipos)
            {
                if (persona.Equals(d.Nombre)) {
                    return d.IdPersona;
                }
            }
            return -1;
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