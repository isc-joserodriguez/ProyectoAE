using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.CatProductoServicios
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

        public IList<cat_productos_servicios> cat_productos_servicios { get; set; }

        public async Task OnGetAsync(string sortOrder, string orden, string busqueda)
        {

            IQueryable<cat_productos_servicios> productos_servicios = from s in _context.cat_productos_servicios
                                                                         select s;
            CurrentFilter = busqueda;
            if (!String.IsNullOrEmpty(busqueda))
            {
                productos_servicios = productos_servicios.Where(s => s.ClaveProdServ.Contains(busqueda) || s.CodigoBarras.ToString().Contains(busqueda) || s.ProductoServicio.ToString().Contains(busqueda));

            }

            if (sortOrder == "clave" && orden == "ASC")
            {
                ASC = "DESC";
                productos_servicios = productos_servicios.OrderBy(s => s.ClaveProdServ);
            }
            else if (sortOrder == "clave" && orden == "DESC")
            {
                ASC = "ASC";
                productos_servicios = productos_servicios.OrderByDescending(s => s.ClaveProdServ);
            }
            else if (sortOrder == "Codigo" && orden == "ASC")
            {
                ASC = "DESC";
                productos_servicios = productos_servicios.OrderBy(s => s.CodigoBarras);
            }
            else if (sortOrder == "codigo" && orden == "DESC")
            {
                ASC = "ASC";
                productos_servicios = productos_servicios.OrderByDescending(s => s.CodigoBarras);
            }
            else
            {
                ASC = (String.IsNullOrEmpty(orden)) ? "ASC" : "";
                productos_servicios = productos_servicios.OrderBy(s => s.ClaveProdServ);
            }

            x = sortOrder + " : " + orden;

            cat_productos_servicios = await productos_servicios.AsNoTracking().ToListAsync();
        }

        public String getProductoServicio(String valor) {
            if (valor.Equals("P")) return "Producto";
            if (valor.Equals("S")) return "Servicio";
            return "Desconocido";
        }
    }
}
