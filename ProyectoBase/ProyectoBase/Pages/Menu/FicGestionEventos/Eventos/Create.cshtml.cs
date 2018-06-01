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
            getTiposGenerales();
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

        public List<SelectListItem> TiposGenerales = new List<SelectListItem>();
        public List<SelectListItem> Generales = new List<SelectListItem>();
        public List<SelectListItem> Personas = new List<SelectListItem>();
        public List<SelectListItem> Edificios = new List<SelectListItem>();

        public async Task<IActionResult> OnPostAsync()
        {
            if (SeleccionoGenerales()) getGenerales();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            

            _context.res_eventos.Add(res_eventos);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public void getTiposGenerales()
        {
            var Tipos = _context.cat_tipos_generales;
            foreach (cat_tipos_generales d in Tipos)
            {
                //if(d.Activo.Equals("A"))
                TiposGenerales.Add(new SelectListItem
                {
                    Text = d.DesTipo,
                    Value = d.IdTipoGeneral.ToString()
                });
            }
        }

        public void getGenerales()
        {
            var Tipos = _context.cat_generales;

            foreach (cat_generales d in Tipos)
            {

                if(res_eventos != null)
                    if(d.IdTipoGeneral == res_eventos.IdTipoGenEvento)
                        Generales.Add(new SelectListItem
                        {
                            Text = d.Clave,
                            Value = d.IdGeneral.ToString()
                        });
            }
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

        public Boolean SeleccionoGenerales()
        {
            var Tipos = _context.cat_generales;
            int select = res_eventos.IdTipoGenEvento;
            foreach (cat_generales d in Tipos)
            {
                if (select == d.IdGeneral)
                {
                    return true;
                }
            }
            return false;
        }

    }
}