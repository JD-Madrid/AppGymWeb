using AppGymWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AppGymWeb.Controllers
{
    public class HomeController : Controller
    {
        GymContext _context = new GymContext();


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegistrarCliente()
        {
            var planes = _context.Planes.Include(p => p.Actividades).ToList();
            var vistaModelo = new ClienteFormularioPlanes
            {
                PlanesDisponibles = planes.Select(p => new SelectListItem
                {
                    Text = p.Nombre + p.Actividades.Sum(a => a.precio),
                    Value = p.Id.ToString(),
                }).ToList(),

                Generos = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Masculino", Value = "Masculino"},
                    new SelectListItem {Text = "Femenino", Value = "Femenino"}
                }
            };

           

            return View(vistaModelo);
        }

        [HttpPost]
        public IActionResult RegistrarCliente(ClienteFormularioPlanes model)
        {
            if (!ModelState.IsValid)
            {
                // Si hay errores, volvés a mostrar el formulario con los datos ya ingresados
                var planes = _context.Planes.Include(p => p.Actividades).ToList();
                model.PlanesDisponibles = planes.Select(p => new SelectListItem
                {
                    Text = $"{p.Nombre} (${p.Actividades.Sum(a => a.precio):F2})",
                    Value = p.Id.ToString()
                }).ToList();

                return View(model);
            }

            // Guardamos al cliente
            _context.Clientes.Add(model.Cliente);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}