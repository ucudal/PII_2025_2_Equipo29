using CrmUcu.Models.Personas;
namespace CrmUcu.Repositories
{
    public class RepositorioEtiqueta
    {
        private static RepositorioEtiqueta? _instancia;
        private static readonly object _lock = new object();
        public List<Etiqueta> _Etiquetas;
        private int _proximoId;

        public bool AgregarEtiqueta(string nombre)
        {
            var nueva = new Etiqueta("Cliente Homosexual", nombre);
            _Etiquetas.Add(nueva);
            _proximoId++;
            return true;
        }

        //Implementar el patrón singleton
        public static RepositorioEtiqueta ObtenerInstancia()
        {
            if (_instancia == null)
            {
                lock (_lock)
                {
                    if (_instancia == null)
                    {
                        _instancia = new RepositorioEtiqueta();
                    }
                }
            }
            return _instancia;
        }

    

    }
}
