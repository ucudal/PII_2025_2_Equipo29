using CrmUcu.Models.Personas;

namespace CrmUcu.Repositories
{
    public class RepositorioCliente
    {
        private static RepositorioCliente? _instancia;
        private static readonly object _lock = new object();
        public List<Cliente> _clientes;
        private int _proximoId;

        private RepositorioCliente()
        {
            _clientes = new List<Cliente>();
            _proximoId = 0;
        }
        

        //Implementar el patrón singleton
        

        public static RepositorioCliente ObtenerInstancia()
        {
            if (_instancia == null)
            {
                lock (_lock)
                {
                    if (_instancia == null)
                    {
                        _instancia = new RepositorioCliente();
                    }
                }
            }
            return _instancia;
        }

        public Cliente CrearCliente(string mail, string nombre, string apellido, string telefono, int idVendedor)
        {
            var cliente = new Cliente(_proximoId, mail, nombre, apellido, telefono, idVendedor);
            _clientes.Add(cliente);
            Console.WriteLine("cliente creado!");
            cliente.MostrarInfo();
            _proximoId++;
            return cliente;
        }

        public Cliente BuscarPorId(int id)
        {
            for (int i=0; i<_clientes.Count(); i++){
                if(_clientes[i].Id == id){
                    return _clientes[i];
                }
            }
            return null;
        }
        
        public void EliminarCliente(int id){
            for (int i=0; i<_clientes.Count(); i++){
                if(_clientes[i].Id == id){
                     _clientes.Remove(_clientes[i]);
                }
            }
        }


        public List<Cliente> ObtenerTodos()
        {
            return _clientes;
        }
    }
}
