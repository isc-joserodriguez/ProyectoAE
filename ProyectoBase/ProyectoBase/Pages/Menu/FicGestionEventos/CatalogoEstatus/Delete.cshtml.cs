﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.Menu.FicGestionEventos.CatalogoEstatus
{
    public class DeleteModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public DeleteModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public cat_estatus cat_estatus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            cat_estatus = await _context.cat_estatus.SingleOrDefaultAsync(m => m.IdEstatus == id);

            if (cat_estatus == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            cat_estatus = await _context.cat_estatus.FindAsync(id);

            if (cat_estatus != null)
            {
                _context.cat_estatus.Remove(cat_estatus);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

        public String Activo(string letra)
        {
            if (letra == "S")
            {
                return "Activo";
            }
            if (letra == "N")
            {
                return "Inactivo";
            }
            return "Desconocido";
        }

        public String TipoEstatus(string ID)
        {
            var Tipos = _context.cat_tipos_estatus;
            foreach (cat_tipos_estatus d in Tipos)
            {
                if (ID == d.IdTipoEstatus.ToString())
                {
                    return d.DesTipoEstatus;
                }
            }
            return "Desconocido";
        }
    }
}
