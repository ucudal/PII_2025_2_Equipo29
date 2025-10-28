using CrmUcu.Models.Enums;
namespace CrmUcu.Models.Personas
{
    public class Administrador : Usuario
    {
        public List<Usuario> UsuariosCreados { get; set; } 

        public Administrador() : base() { }

        public Administrador(int id, string nombre, string apellido, string mail,
                           string telefono, string nombreUsuario, string password)
            : base(id, nombre, apellido, mail, telefono, nombreUsuario, password)
        {
        }

        public override bool Autenticar()
        {
            //login de los admins, tendría que ser mas polenta que los normales.
            return EstaActivo();
        }
        
        //aplicando creator. Admins pueden crear vendedores.
        public Vendedor CrearVendedor(string nombre, string apellido, string email,
                                     string telefono, string nombreUsuario, string password,
                                     decimal comisionPorcentaje = 0)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre es requerido", nameof(nombre));
            
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido es requerido", nameof(apellido));
            
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("El email es requerido", nameof(email));
            
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException("El nombre de usuario es requerido", nameof(nombreUsuario));
            
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("La contraseña es requerida", nameof(password));

            var vendedor = new Vendedor
            {
                Id = 0,
                Nombre = nombre,
                Apellido = apellido,
                Mail = email,
                Telefono = telefono,
                NombreDeUsuario = nombreUsuario,
                Password = password,
                ComisionPorcentaje = comisionPorcentaje,
                Estado = EstadoUsuario.Activo
            };

            UsuariosCreados.Add(vendedor);
            Console.WriteLine($"Vendedor {vendedor.NombreCompleto} creado por {this.NombreCompleto}");
            
            return vendedor;
        }

        public Administrador CrearAdministrador(string nombre, string apellido, string email,
                                               string telefono, string nombreUsuario, string password)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre es requerido", nameof(nombre));
            
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido es requerido", nameof(apellido));

            var administrador = new Administrador
            {
                Id = 0, 
                Nombre = nombre,
                Apellido = apellido,
                Mail = email,
                Telefono = telefono,
                NombreDeUsuario = nombreUsuario,
                Password = password, 
                Estado = EstadoUsuario.Activo
            };

            UsuariosCreados.Add(administrador);
            Console.WriteLine($"✓ Administrador {administrador.NombreCompleto} creado por {this.NombreCompleto}");
            
            return administrador;
        }
        
        // gestóin de users.

        public void SuspenderUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            if (usuario == this)
            {
                throw new InvalidOperationException("No puedes suspenderte a ti mismo");
            }

            usuario.Suspender();
            Console.WriteLine($"Usuario {usuario.NombreCompleto} suspendido por {this.NombreCompleto}");
        }

        public void EliminarUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            if (usuario == this)
            {
                throw new InvalidOperationException("No podes eliminarte a vos mismo");
            }

            usuario.Eliminar();
            Console.WriteLine($"Usuario {usuario.NombreCompleto} eliminado por {this.NombreCompleto}");
        }

        public void ActivarUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            usuario.Activar();
            Console.WriteLine($"Usuario {usuario.NombreCompleto} activado por {this.NombreCompleto}");
        }


        public void AsignarClienteAVendedor(Cliente cliente, Vendedor vendedor)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));
            
            if (vendedor == null)
                throw new ArgumentNullException(nameof(vendedor));

            vendedor.AsignarCliente(cliente);
        }

        public List<Usuario> ObtenerUsuariosCreados()
        {
            return UsuariosCreados.ToList();
        }

        public int CantidadUsuariosCreados()
        {
            return UsuariosCreados.Count;
        }

        public override string ToString()
        {
            return $"{NombreCompleto} - Administrador - {UsuariosCreados.Count} usuarios creados";
        }
    }
}
