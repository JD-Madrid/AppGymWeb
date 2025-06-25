using AppGymWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AppGymWeb.Persistencia
{
    public class ClientePersistencia
    {
        private readonly GymContext _context;

        public ClientePersistencia()
        {
            _context = new GymContext();
        }

        //CREATE 
        public void AgregarCliente(Cliente c)
        {
            _context.Add(c);
            _context.SaveChanges();
        }

        public List<Cliente> ListaClientes()
        {
            return _context.Clientes.Include(c => c.Plan).ToList();
        }
    }
}
