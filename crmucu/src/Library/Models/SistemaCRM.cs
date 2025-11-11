namespace CrmUcu.Models.Utils
{

    public class SistemaCRM
    {
    
        public RepositorioClientes repoClientes {get; private set;}
        public RepositorioVendedores repoVendedores {get; private set;}
        public RepositorioAdministradores repoAdministradores {get; private set;}

    }

    public SistemaCRM()
    {
        repoClientes = new RepositorioClientes();
        repoVendedores = new RepositorioVendedores();
        repoAdministradores = new RepositorioAdministradores();

    }

    public void Inicializar(){
        Console.WriteLine("Sistema Iniciado! Bienvenido a tu CRM de confianza :).");
    }

    public Dictionary <string, object> ObtenerMetricasGlobales()
    {
        var metricas = new Dictionary<string, object>
        {
            {"Total de Clientes", repoClientes.ObtenerTodos().Count},
            {"TotalVendedores", repoVendedores.ObtenerTodos().Count },
            {"TotalAdministradores", repoAdministradores.ObtenerTodos().Count}
            {"ClientesActivos", repoClientes.ObtenerTodos().Count
        }

    }
    
}
