using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.Menu.FicGestionEventos.EventoZonaBoletosEstatus
{
    public class IndexModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public IndexModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<res_evento_zona_boleto_estatus> res_evento_zona_boleto_estatus { get;set; }
        public int IdEdificio { get; set; }
        public int IdEspacio { get; set; }
        public int IdEvento { get; set; }
        public int IdZona { get; set; }
        public int IdHorario { get; set; }

        public async Task OnGetAsync(int edificio, int espacio, int evento, int zona, int horario)
        {
            IdEdificio = edificio;
            IdEspacio = espacio;
            IdEvento = evento;
            IdZona = zona;
            IdHorario = horario;
            res_evento_zona_boleto_estatus = await _context.res_evento_zona_boleto_estatus.ToListAsync();
        }
    }
}
