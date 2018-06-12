using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.RhCatPersonas
{
    public class IndexModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public IndexModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<rh_cat_personas> rh_cat_personas { get;set; }

        public async Task OnGetAsync()
        {
            rh_cat_personas = await _context.rh_cat_personas.ToListAsync();
        }

        public String getSexo(String sexo) {
            if (sexo.Equals("M")) return "Masculino";
            if (sexo.Equals("F")) return "Femenino";
            return "Desconocido";
        }

        public String getTipoPersona(String tipo)
        {
            if (tipo.Equals("M")) return "Moral";
            if (tipo.Equals("F")) return "Fisica";
            return "Desconocido";
        }
    }
}
