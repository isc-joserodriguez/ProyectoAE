using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;


namespace ProyectoBase.Pages.Menu.FicGestionEventos.Eventos
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

        public IList<res_eventos> res_eventos { get;set; }

        public async Task OnGetAsync(string sortOrder, string orden, string busqueda)
        {

            IQueryable<res_eventos> eventos = from s in _context.res_eventos
                                              select s;
            CurrentFilter = busqueda;
            if (!String.IsNullOrEmpty(busqueda)) {
                eventos = eventos.Where(s => s.NombreEvento.Contains(busqueda) || s.IdEvento.ToString().Contains(busqueda) || s.FechaIn.ToString().Equals(busqueda));

            }

            if (sortOrder == "Nombre" && orden == "ASC")
            {
                ASC = "DESC";
                eventos = eventos.OrderBy(s => s.NombreEvento);
            }
            else if (sortOrder == "Nombre" && orden == "DESC")
            {
                ASC = "ASC";
                eventos = eventos.OrderByDescending(s => s.NombreEvento);
            }
            else if (sortOrder == "Fecha" && orden == "ASC")
            {
                ASC = "DESC";
                eventos = eventos.OrderBy(s => s.FechaIn);
            }
            else if (sortOrder == "Fecha" && orden == "DESC")
            {
                ASC = "ASC";
                eventos = eventos.OrderByDescending(s => s.FechaIn);
            }
            else if (sortOrder == "FechaFin" && orden == "ASC")
            {
                ASC = "DESC";
                eventos = eventos.OrderBy(s => s.FechaFin);
            }
            else if (sortOrder == "FechaFin" && orden == "DESC")
            {
                ASC = "ASC";
                eventos = eventos.OrderByDescending(s => s.FechaFin);
            }
            else if (sortOrder == "Id" && orden == "ASC")
            {
                ASC = "DESC";
                eventos = eventos.OrderBy(s => s.IdEvento);
            }
            else if (sortOrder == "Id" && orden == "DESC")
            {
                ASC = "ASC";
                eventos = eventos.OrderByDescending(s => s.IdEvento);
            }
            else
            {
                ASC = (String.IsNullOrEmpty(orden))?"ASC":"";
                eventos = eventos.OrderBy(s => s.NombreEvento);
            }

            x = sortOrder+" : "+orden;

            res_eventos = await eventos.AsNoTracking().ToListAsync();
        }

        public String TipoGenEvento(string ID)
        {
            var Tipos = _context.cat_tipos_generales;
            foreach (cat_tipos_generales d in Tipos) {
                if (ID == d.Id.ToString()) {
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
                if (ID == d.Id.ToString())
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
                if (ID == d.Id.ToString())
                {
                    return d.DesGeneral;
                }
            }
            return "Desconocido";
        }
    }
}
