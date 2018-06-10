using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.Menu.FicGestionEventos.EventoZonaBoletosEstatus
{
    public class CreateModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public CreateModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id, int edificio, int espacio, int evento, int zona, int horario)
        {
            IdEdificio = edificio;
            IdEspacio = espacio;
            IdEvento = evento;
            IdZona = zona;
            IdHorario = horario;
            IdBoleto = id;
            getEstatus();
            getActivo();
            return Page();
        }

        [BindProperty]
        public res_evento_zona_boleto_estatus res_evento_zona_boleto_estatus { get; set; }
        public int IdEdificio { get; set; }
        public int IdEspacio { get; set; }
        public int IdEvento { get; set; }
        public int IdZona { get; set; }
        public int IdHorario { get; set; }
        public int IdBoleto { get; set; }
        public IList<res_evento_zona_boleto_estatus> anteriores_res_evento_zona_boleto_estatus { get; set; }

        public async Task<IActionResult> OnPostAsync(int edificio_, int espacio_, int evento_, int zona_, int horario_, int boleto_)
        {
            res_evento_zona_boleto_estatus.FechaEstatus = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return Page();
            }


            IQueryable<res_evento_zona_boleto_estatus> eventos = from s in _context.res_evento_zona_boleto_estatus
                                                                 select s;
            anteriores_res_evento_zona_boleto_estatus = await eventos.Where(m => m.IdBoleto == boleto_)
                .AsNoTracking()
                .ToListAsync();

            _context.res_evento_zona_boleto_estatus.Add(res_evento_zona_boleto_estatus);
            await _context.SaveChangesAsync();
            foreach (res_evento_zona_boleto_estatus d in anteriores_res_evento_zona_boleto_estatus)
            {
                d.Actual = "N";
                _context.Attach(d).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }


            

            return RedirectToPage("./Index", new { id = res_evento_zona_boleto_estatus.IdBoleto,
                edificio = edificio_,
                espacio = espacio_,
                evento = evento_,
                zona = zona_,
                horario = horario_
            });
        }

        public List<SelectListItem> Estatus = new List<SelectListItem>();
        public void getEstatus()
        {
            //if(d.Activo.Equals("A"))
            Estatus.Add(new SelectListItem
            {
                Text = "Activo",
                Value = "6"
            });
            Estatus.Add(new SelectListItem
            {
                Text = "Inactivo",
                Value = "7"
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