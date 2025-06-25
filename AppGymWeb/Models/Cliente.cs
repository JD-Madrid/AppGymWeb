using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace AppGymWeb.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string Nombre { get; set; } = string.Empty;
        [StringLength(20)]
        public string Apellido { get; set; } = string.Empty;
        [StringLength(20)]        
        
        public string Genero { get; set; } = string.Empty;

        public int? PlanId { get; set; }

        public Plan? Plan { get; set; }
    }
}
