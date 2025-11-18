using CrmUcu.Models.Personas;

namespace CrmUcu.Repositories
{
    public class RepositorioAdmin
    {
        private static RepositorioAdmin? _instancia;
        private static readonly object _lock = new object();
        public List<Admin> _admins;
        private int _proximoId;

        private RepositorioAdmin()
        {
            _admins = new List<Admin>();
            _proximoId = 0;
        }
        

        //Implementar el patrón singleton
        public static RepositorioAdmin ObtenerInstancia()
        {
            if (_instancia == null)
            {
                lock (_lock)
                {
                    if (_instancia == null)
                    {
                        _instancia = new RepositorioAdmin();
                    }
                }
            }
            return _instancia;
        }

    

    }
}
