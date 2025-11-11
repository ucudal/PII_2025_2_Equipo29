using CrmUcu.Models.Personas;

namespace CrmUcu.Repositories
{
    public class RepositorioAdministradores
    {
        private List<Administrador> administradores = new();
        private int siguienteId = 1;

        private static RepositorioAdministradores? instancia;
        
        private RepositorioAdministradores() { }

        public static RepositorioAdministradores ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new RepositorioAdministradores();
            }
            return instancia;
        }

        public void Agregar(Administrador administrador)
        {
            if (administrador.Id == 0)
            {
                administrador.Id = siguienteId++;
            }
            
            if (administradores.Any(a => a.Id == administrador.Id))
            {
                throw new InvalidOperationException($"Ya existe un administrador con ID {administrador.Id}");
            }
            
            administradores.Add(administrador);
        }

        public Administrador? BuscarPorId(int id)
        {
            return administradores.FirstOrDefault(a => a.Id == id);
        }

        public Administrador? BuscarPorNombreUsuario(string nombreUsuario)
        {
            return administradores.FirstOrDefault(a => 
                a.NombreDeUsuario.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase));
        }

        public Administrador? BuscarPorEmail(string email)
        {
            return administradores.FirstOrDefault(a => 
                a.Mail.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public List<Administrador> ObtenerTodos()
        {
            return administradores.ToList();
        }

        public List<Administrador> ObtenerActivos()
        {
            return administradores.Where(a => a.EstaActivo()).ToList();
        }

        public void Eliminar(Administrador administrador)
        {
            administradores.Remove(administrador);
        }

        public int ObtenerTotal()
        {
            return administradores.Count;
        }

        public bool Existe(int id)
        {
            return administradores.Any(a => a.Id == id);
        }
    }
}
