using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.EventoClienteProdServ
{
    public class CreateModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public CreateModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
            getProdServEsp();
            getClientes();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public res_evento_cliente_prod_serv res_evento_cliente_prod_serv { get; set; }

        public async Task<IActionResult> OnPostAsync(String search)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            res_evento_cliente_prod_serv.IdProdServ = getIDProductoServicio(res_evento_cliente_prod_serv.IdProdServEsp);
            res_evento_cliente_prod_serv.IdEvento = getIdEvento(res_evento_cliente_prod_serv.IdReservaCliente);
            res_evento_cliente_prod_serv.Importe = res_evento_cliente_prod_serv.Cantidad * (
                res_evento_cliente_prod_serv.Precio + res_evento_cliente_prod_serv.Precio * res_evento_cliente_prod_serv.IVA/100);
            _context.res_evento_cliente_prod_serv.Add(res_evento_cliente_prod_serv);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public List<SelectListItem> ProdServEsp = new List<SelectListItem>();
        public void getProdServEsp()
        {
            var Tipos = _context.cat_prod_serv_especifico;
            foreach (cat_prod_serv_especifico d in Tipos)
            {
                if (esProducto(d.IdProdServ.ToString()))
                    ProdServEsp.Add(new SelectListItem
                    {
                        Text = getProductoServicio(d.IdProdServ.ToString()) + " - " + d.ClaveProdServEsp,
                        Value = d.IdProdServEsp.ToString()
                    });
            }
        }

        public Boolean esProducto(string ID)
        {
            var Tipos = _context.cat_productos_servicios;
            foreach (cat_productos_servicios d in Tipos)
            {
                if (ID == d.IdProdServ.ToString())
                {

                    return d.ProductoServicio.Equals("P");
                }
            }
            return false;
        }

        public String getProductoServicio(string ID)
        {
            var Tipos = _context.cat_productos_servicios;
            foreach (cat_productos_servicios d in Tipos)
            {
                if (ID == d.IdProdServ.ToString())
                {
                    return d.ClaveProdServ;
                }
            }
            return "Desconocido";
        }

        public int getIDProductoServicio(int ID)
        {
            var Tipos = _context.cat_prod_serv_especifico;
            foreach (cat_prod_serv_especifico d in Tipos)
            {
                if (ID == d.IdProdServEsp)
                    return d.IdProdServ;
            }
            return -1;
        }

        public List<SelectListItem> Clientes = new List<SelectListItem>();
        public void getClientes()
        {
            var Tipos = _context.res_evento_clientes;
            foreach (res_evento_clientes d in Tipos)
            {
                //if(search.Contains(d.IdReservaCliente.ToString()))
                Clientes.Add(new SelectListItem
                {
                    Text = d.IdReservaCliente.ToString(),
                    Value = d.IdReservaCliente.ToString()
                });
            }
        }

        public int getIdEvento(int ID)
        {
            var Tipos = _context.res_evento_clientes;
            foreach (res_evento_clientes d in Tipos)
            {
                if (ID == d.IdReservaCliente)
                    return d.IdEvento;
            }
            return -1;
        }
    }
}