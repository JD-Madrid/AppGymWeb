using System.ComponentModel.DataAnnotations;

namespace AppGymWeb.Models
{
    public class Actividad
    {
        [Key]
        public int Id { get; set; } 
        public string Nombre { get; set; } = string.Empty;

        public double duracion { get; set; }

        public double precio { get; set; }


        public int? PlanId { get; set; }

        public Plan? Plan { get; set; }
    }
}
