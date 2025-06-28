namespace AppGymWeb.Models
{
    public class Plan
    {

        public int Id { get; set; } 

        public string Nombre { get; set; } = string.Empty;

        public List<Actividad> Actividades { get; set; } = new List<Actividad> { }; 
    }
}
