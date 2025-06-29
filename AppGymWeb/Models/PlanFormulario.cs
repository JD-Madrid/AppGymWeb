using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppGymWeb.Models
{
    public class PlanFormulario
    {

        public string Nombre { get; set; }

        public List<int> ActividadesSeleccionadas { get; set; } = new();

        public List<SelectListItem> ActividadesDisponibles { get; set; } = new();
    }
}
