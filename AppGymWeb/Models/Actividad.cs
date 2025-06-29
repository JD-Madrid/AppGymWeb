using System.ComponentModel.DataAnnotations;

namespace AppGymWeb.Models
{
    public class Actividad
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Range(1, 300, ErrorMessage = "La duración debe ser entre 1 y 300 minutos.")]
        public int Duracion { get; set; }

        [Range(0, 100000, ErrorMessage = "El precio debe ser mayor o igual a 0.")]
        public double Precio { get; set; }

        public List<Plan> Planes { get; set; } = new();
    }
}
