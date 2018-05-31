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

namespace ProyectoBase.Pages.Menu.FicGestionEventos.Eventos
{
    public class EditModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public EditModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public res_eventos res_eventos { get; set; }

        public List<SelectListItem> TiposGenerales = new List<SelectListItem>();
        public List<SelectListItem> Generales = new List<SelectListItem>();
        public List<SelectListItem> Personas = new List<SelectListItem>();
        public List<SelectListItem> Edificios = new List<SelectListItem>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            getTiposGenerales();
            getGenerales();
            getPersonas();
            getEdificios();

            res_eventos = await _context.res_eventos.SingleOrDefaultAsync(m => m.IdEvento == id);

            if (res_eventos == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(res_eventos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!res_eventosExists(res_eventos.IdEvento))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool res_eventosExists(int id)
        {
            return _context.res_eventos.Any(e => e.IdEvento == id);
        }

        public void getTiposGenerales() {
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

        public void getGenerales() {
            var Tipos = _context.cat_generales;
            foreach (cat_generales d in Tipos)
            {
                //if(d.Activo.Equals("A"))
                Generales.Add(new SelectListItem
                {
                    Text = d.DesGeneral,
                    Value = d.IdGeneral.ToString()
                });
            }
        }

        public void getPersonas() {
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

        public void getEdificios() {
            var Tipos = _context.eva_cat_edificios;
            foreach (eva_cat_edificios d in Tipos)
            {
                Edificios.Add(new SelectListItem
                {
                    Text = d.DesEdificio,
                    Value = d.IdEdificio.ToString()
                });
            }
        }
    }
}
/*
 
    [Key]
        
        public int IdEvento { get; set; }


        [ForeignKey("IdTipoGenEvento")]
        public int IdTipoGenEvento { get; set; }
        public virtual cat_tipos_generales cat_tipos_generales { get; set; }

        [ForeignKey("IdGenEvento")]
        public int IdGenEvento { get; set; }
        public virtual cat_generales cat_generales { get; set; }

        [ForeignKey("IdPersonaReg")]
        public int IdPersonaReg { get; set; }
        public virtual rh_cat_personas rh_cat_personas { get; set; }

        public string NombreEvento { get; set; }
        public string Observacion { get; set; }
        public string Explicacion { get; set; }
        public string URL { get; set; }
        public DateTime FechaIn { get; set; }
        public DateTime FechaFin { get; set; }

        [ForeignKey("IdEdificio")]
        public int IdEdificio { get; set; }
        public virtual eva_cat_edificios eva_cat_edificios { get; set; }

        public DateTime FechaReg { get; set; }
        public int UsuarioReg { get; set; }

     */
