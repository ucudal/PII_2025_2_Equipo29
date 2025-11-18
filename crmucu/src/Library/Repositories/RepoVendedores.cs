
using CrmUcu.Models.Personas;

namespace CrmUcu.Repositories
{
    public class RepositorioVendedor
    {
        private static RepositorioVendedor? _instancia;
        private static readonly object _lock = new object();
        public List<Vendedor> _vendedores;
        private int _proximoId;

        private RepositorioVendedor()
        {
            _vendedores = new List<Vendedor>();
            _proximoId = 0;
        }
        

        //Implementar el patrón singleton
        public static RepositorioVendedor ObtenerInstancia()
        {
            if (_instancia == null)
            {
                lock (_lock)
                {
                    if (_instancia == null)
                    {
                        _instancia = new RepositorioVendedor();
                    }
                }
            }
            return _instancia;
        }

    

    }
}
