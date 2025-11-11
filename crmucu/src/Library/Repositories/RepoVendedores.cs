using CrmUcu.Models.Personas;

namespace CrmUcu.Repositories
{
    public class RepositorioVendedores
    {
        private List<Vendedor> vendedores = new();
        private int siguienteId = 1;

        private static RepositorioVendedores? instancia;
        
        private RepositorioVendedores() { }

        public static RepositorioVendedores ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new RepositorioVendedores();
            }
            return instancia;
        }

        public void Agregar(Vendedor vendedor)
        {
            if (vendedor.Id == 0)
            {
                vendedor.Id = siguienteId++;
            }
            
            if (vendedores.Any(v => v.Id == vendedor.Id))
            {
                throw new InvalidOperationException($"Ya existe un vendedor con ID {vendedor.Id}");
            }
            
            vendedores.Add(vendedor);
        }

        public List<Vendedor> ObtenerTodos()
        {
            return vendedores.ToList();
        }


        public void Eliminar(Vendedor vendedor)
        {
            vendedores.Remove(vendedor);
        }

        public int ObtenerTotal()
        {
            return vendedores.Count;
        }

    }
}
