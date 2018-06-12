using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.Eventos
{
    public class DetailsModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public DetailsModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public res_eventos res_eventos { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            res_eventos = await _context.res_eventos.SingleOrDefaultAsync(m => m.IdEvento == id);

            if (res_eventos == null)
            {
                return NotFound();
            }
            return Page();
        }

        public String TipoGenEvento(string ID)
        {
            var Tipos = _context.cat_tipos_generales;
            foreach (cat_tipos_generales d in Tipos)
            {
                if (ID == d.IdTipoGeneral.ToString())
                {
                    return d.DesTipo;
                }
            }
            return "Desconocido";
        }

        public String PersonaReg(string ID)
        {
            var Tipos = _context.rh_cat_personas;
            foreach (rh_cat_personas d in Tipos)
            {
                if (ID == d.IdPersona.ToString())
                {
                    return d.Nombre;
                }
            }
            return "Desconocido";
        }

        public String GenEvento(string ID)
        {
            var Tipos = _context.cat_generales;
            foreach (cat_generales d in Tipos)
            {
                if (ID == d.IdGeneral.ToString())
                {
                    return d.Clave;
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
                    return d.Clave;
                }
            }
            return "Desconocido";
        }
    }
}
