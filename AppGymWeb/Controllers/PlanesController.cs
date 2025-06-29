using AppGymWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppGymWeb.Controllers
{
    public class PlanesController : Controller
    {

        GymContext _context = new GymContext();


        [HttpGet]
        public IActionResult CrearPlan()
        {

            var actividades = _context.Actividades.ToList();

            var modelo = new PlanFormulario
            {
                ActividadesDisponibles = actividades.Select(a => new SelectListItem
                {
                    Text = $"{a.Nombre} (${a.Precio})",
                    Value = a.Id.ToString()
                }).ToList(), 
            };
            return View(modelo);
        }


        [HttpPost]
        public IActionResult CrearPlan(PlanFormulario modelo)
        {

            if (!ModelState.IsValid)
            {
                modelo.ActividadesDisponibles = _context.Actividades.Select(a => new SelectListItem
                {
                    Text = a.Nombre,
                    Value = a.Id.ToString()
                }).ToList();

                return View(modelo);
            }

            var actividadesSeleccionadas = _context.Actividades.Where(a => modelo.ActividadesSeleccionadas.Contains(a.Id)).ToList();

            var nuevoPlan = new Plan
            {
                Nombre = modelo.Nombre,
                Actividades = actividadesSeleccionadas
            }; 

            _context.Planes.Add(nuevoPlan);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AgregarActividad()
        {
          return View();
        }

        [HttpPost]
        public IActionResult AgregarActividad(Actividad actividad)
        {
            if (!ModelState.IsValid)
            {
                return View(actividad);
            }
            _context.Actividades.Add(actividad);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }



    }
}
