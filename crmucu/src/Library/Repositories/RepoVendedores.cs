
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
            _proximoId = 1;
            
            var vendedorPorMeme = new Vendedor(
                id: _proximoId,
                nombre: "LaFokin",
                apellido: "Cabra",
                mail: "ElMehoVendedol@gmail.com",
                telefono: "123236234",
                nombreUsuario: "Sergio Ramirez",
                password: "ComeAndShakeYourBodyBabyDoThatConga"
            );

            _vendedores.Add(vendedorPorMeme);
            _proximoId++;

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
