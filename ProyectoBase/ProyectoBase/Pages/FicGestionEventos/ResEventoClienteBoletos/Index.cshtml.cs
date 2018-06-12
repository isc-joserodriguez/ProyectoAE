using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.ResEventoClienteBoletos
{
    public class IndexModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public IndexModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<res_evento_cliente_boletos> res_evento_cliente_boletos { get;set; }

        public async Task OnGetAsync()
        {
            IQueryable<res_evento_cliente_boletos> res_evento_cliente_boletos_ = from s in _context.res_evento_cliente_boletos
                                                                                 select s;
            res_evento_cliente_boletos_ = res_evento_cliente_boletos_.Where(s => s.ConfirmaAsistencia.Equals("N"));
            res_evento_cliente_boletos = await res_evento_cliente_boletos_.AsNoTracking().ToListAsync();
        }

        public String getEvento(string ID)
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

        public String getPersonaReg(string ID)
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
    }
}
