using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppGymWeb.Models
{
    public class ClienteFormularioPlanes
    {

        public Cliente Cliente { get; set; } = new();
        public List<SelectListItem> PlanesDisponibles { get; set; } = new();

        public double precioPlanSeleccionado { get; set; }
    }
}
