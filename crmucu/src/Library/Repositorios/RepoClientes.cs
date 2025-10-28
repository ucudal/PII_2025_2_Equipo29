using CrmUcu.Models.Personas;

namespace CrmUcu.Repositories
{
    public class RepositorioClientes
    {
        private List<Cliente> clientes = new();
        private int siguienteId = 1;

               private static RepositorioClientes? instancia;
        
        private RepositorioClientes() { }

        public static RepositorioClientes ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new RepositorioClientes();
            }
            return instancia;
        }

        public void Agregar(Cliente cliente)
        {
            if (cliente.Id == 0)
            {
                cliente.Id = siguienteId++;
            }
            
            if (clientes.Any(c => c.Id == cliente.Id))
            {
                throw new InvalidOperationException($"Ya existe un cliente con ID {cliente.Id}");
            }
            
            clientes.Add(cliente);
        }




        public List<Cliente> ObtenerTodos()
        {
            return clientes.ToList();
        }

        public void Eliminar(Cliente cliente)
        {
            clientes.Remove(cliente);
        }


        public int ObtenerTotal()
        {
            return clientes.Count;
        }


    }
}
