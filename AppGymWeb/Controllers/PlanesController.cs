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
            return View(new Plan());
        }


        [HttpPost]
        public IActionResult CrearPlan(Plan plan)
        {

            if (!ModelState.IsValid)
            {
                return View(plan);
            }

            _context.Planes.Add(plan);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult AgregarActividad()
        {
            var planes = _context.Planes.ToList();

            var modelo = new ActividadFormulario
            {
                PlanesDisponibles = planes.Select(p => new SelectListItem
                {
                    Text = p.Nombre,
                    Value = p.Id.ToString()
                }).ToList()
            };

            return View(modelo);
        }

        [HttpPost]
        public IActionResult AgregarActividad(ActividadFormulario modelo)
        {

            if (!ModelState.IsValid)
            {
                modelo.PlanesDisponibles = _context.Planes.Select(p => new SelectListItem
                {
                    Text = p.Nombre,
                    Value = p.Id.ToString()
                }).ToList();

                return View(modelo);
            }
            bool existe = _context.Planes.Any(p => p.Id == modelo.Actividad.PlanId);
            if (!existe)
            {
                ModelState.AddModelError("", "El plan seleccionado no existe.");
                modelo.PlanesDisponibles = _context.Planes.Select(p => new SelectListItem
                {
                    Text = p.Nombre,
                    Value = p.Id.ToString()
                }).ToList();

                return View(modelo);
            }

            _context.Actividades.Add(modelo.Actividad);
            _context.SaveChanges();
            return RedirectToAction("Detalle", new {id = modelo.Actividad.PlanId});
        }

        [HttpGet]
        public IActionResult Detalle(int id)
        {
            var plan = _context.Planes
           .Include(p => p.Actividades)
           .FirstOrDefault(p => p.Id == id);

            if (plan == null) return NotFound();

            return View(plan);
        }
    }
}
