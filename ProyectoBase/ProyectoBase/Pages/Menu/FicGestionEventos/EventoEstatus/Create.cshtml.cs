using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.Menu.FicGestionEventos.EventoEstatus
{
    public class CreateModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public CreateModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
            getActivo();
            getEstatus();
        }

        public IActionResult OnGet(int evento)
        {
            IdEvento = evento;
            return Page();
        }

        [BindProperty]
        public res_evento_estatus res_evento_estatus { get; set; }
        public int IdEvento { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            res_evento_estatus.FechaEstatus = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            

            _context.res_evento_estatus.Add(res_evento_estatus);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id = res_evento_estatus.IdEvento});
        }

        public List<SelectListItem> Estatus = new List<SelectListItem>();
        public void getEstatus()
        {
            //if(d.Activo.Equals("A"))
            Estatus.Add(new SelectListItem
            {
                Text = "Activo",
                Value = "1"
            });
            Estatus.Add(new SelectListItem
            {
                Text = "Inactivo",
                Value = "2"
            });
        }

        public List<SelectListItem> Activo = new List<SelectListItem>();
        public void getActivo()
        {
            //if(d.Activo.Equals("A"))
            Activo.Add(new SelectListItem
            {
                Text = "Si",
                Value = "S"
            });
            Activo.Add(new SelectListItem
            {
                Text = "No",
                Value = "N"
            });
        }
    }
}