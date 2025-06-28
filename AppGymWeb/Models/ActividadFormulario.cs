using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppGymWeb.Models
{
    public class ActividadFormulario
    {

        public Actividad Actividad { get; set; } = new();

        public List<SelectListItem> PlanesDisponibles { get; set; } = new();
    }
}
 