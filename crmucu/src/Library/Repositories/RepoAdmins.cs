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
            _proximoId = 1;
            
            var adminDePrueba = new Admin(
                id: _proximoId,
                nombre: "El Papá",
                apellido: "El Abuelo",
                mail: "ElPadreDeTodos@gmail.com",
                telefono: "00000001",
                nombreUsuario: "Adán",
                password: "ChiapasFilosofo"
            );

            _admins.Add(adminDePrueba);
            _proximoId++;
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
