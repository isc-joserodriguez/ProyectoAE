using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.EventoZonaBoletosVenta
{
    public class IndexModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public IndexModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; } = "Nombre";
        public string DateSort { get; set; } = "Fecha";
        public string DateEndSort { get; set; } = "FechaFin";
        public string IdSort { get; set; } = "Id";
        public string ASC { get; set; } = "ASC";
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public string x { get; set; }

        [BindProperty]
        public res_evento_clientes res_evento_clientes { get; set; }
        

        public IList<res_evento_zona_boletos> res_evento_zona_boletos { get; set; }
        public int IdEdificio { get; set; }
        public int IdEspacio { get; set; }
        public int IdEvento { get; set; }
        public int IdClienteReserva { get; set; }
        public int IdZona { get; set; }


        public async Task<IActionResult> OnGetAsync(int id, int edificio, int espacio, int evento, string busqueda)
        {
            int num = Zona(busqueda);

            IdEdificio = edificio;
            IdEspacio = espacio;
            IdEvento = evento;
            IdClienteReserva = id;

           
            IQueryable<res_evento_zona_boletos> _res_evento_zona_boletos = from s in _context.res_evento_zona_boletos
                                                                           select s;

            res_evento_zona_boletos = await _context.res_evento_zona_boletos.ToListAsync();

            if (res_evento_zona_boletos == null)
            {
                return NotFound();
            }

            if (!String.IsNullOrEmpty(busqueda) && !busqueda.Equals("")) {
                res_evento_zona_boletos = await _res_evento_zona_boletos.Where(m =>
          m.IdEvento == IdEvento &&
          m.IdEdificio == IdEdificio &&
          m.IdEspacio == IdEspacio)
              .AsNoTracking()
              .ToListAsync();
                return Page();
            
        }
            res_evento_zona_boletos = await _res_evento_zona_boletos.Where(m =>
            m.IdEvento == IdEvento &&
            m.IdEdificio == IdEdificio &&
            m.IdEspacio == IdEspacio &&
            m.IdZona==num)
                .AsNoTracking()
                .ToListAsync();
            return Page();
        }

        public int Zona(string ID)
        {
            var Tipos = _context.res_cat_zonas;
            foreach (res_cat_zonas d in Tipos)
            {
                if (ID == d.DesZona.ToString())
                {
                    return d.IdZona;
                }
            }
            return -1;
        }

        public String getEdificio(string ID)
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

        public String getEspacio(string ID)
        {
            var Tipos = _context.eva_cat_espacios;
            foreach (eva_cat_espacios d in Tipos)
            {
                if (ID == d.IdEspacio.ToString())
                {
                    return d.Alias;
                }
            }
            return "Desconocido";
        }

        public String getZona(string ID)
        {
            var Tipos = _context.res_cat_zonas;
            foreach (res_cat_zonas d in Tipos)
            {
                if (ID == d.IdZona.ToString())
                {
                    return d.DesZona;
                }
            }
            return "Desconocido";
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

        public Boolean Existe(string ID)
        {
            var Tipos = _context.res_evento_cliente_boletos;
            foreach (res_evento_cliente_boletos d in Tipos)
            {
                if (ID == d.IdBoleto.ToString())
                {
                    return false;
                }
            }
            return true;
        }

    }
}