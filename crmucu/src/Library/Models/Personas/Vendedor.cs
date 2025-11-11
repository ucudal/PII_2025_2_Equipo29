using CrmUcu.Models.Enums;
namespace CrmUcu.Models.Personas
{
    public class Vendedor : Usuario
    {
        public List<Cliente> Clientes { get; set; } = new();

        public Vendedor() : base() { }

        public Vendedor(int id, string nombre, string apellido, string mail,
                       string telefono, string nombreUsuario, string password, decimal comision)
            : base(id, nombre, apellido, mail, telefono, nombreUsuario, password)
        {
        }

        public override bool Autenticar()
        {
          
            return EstaActivo();
        }
        
        public void AsignarCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            if (!Clientes.Contains(cliente))
            {
                Clientes.Add(cliente);
                cliente.Vendedor = this;
                Console.WriteLine($"Cliente {cliente.NombreCompleto} asignado a vendedor {this.NombreCompleto}");
            }
        }

        public void RemoverCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            if (Clientes.Remove(cliente))
            {
                cliente.Vendedor = null;
                Console.WriteLine($"Cliente {cliente.NombreCompleto} removido del vendedor {this.NombreCompleto}");
            }
        }
            
        public List<Cliente> ObtenerClientes()
        {
            return Clientes.ToList();
        }


        public int CantidadClientes()
        {
            return Clientes.Count;
        }


    }
}
