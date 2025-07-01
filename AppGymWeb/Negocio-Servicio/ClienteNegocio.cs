using AppGymWeb.Models;
using AppGymWeb.Persistencia;

namespace AppGymWeb.Negocio_Servicio
{


    // Aqui toda la logica y validaciones
    public class ClienteNegocio
    {
        //Variable con la que nos comunicamos con la base de datos
        private readonly ClientePersistencia ClientePersistencia;

        public ClienteNegocio()
        {
            ClientePersistencia = new ClientePersistencia();
        }


        public void RegistrarCliente(Cliente c)
        {
            //Aqui hacemos las validaciones necesarias con un try-cath 

            ClientePersistencia.AgregarCliente(c);
        }

        public List<Cliente> ListarClientes()
        {
            return ClientePersistencia.ListaClientes();
        }

    }
}
