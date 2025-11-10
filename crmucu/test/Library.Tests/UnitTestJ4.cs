using System;
using System.Linq;
using CrmUcu;
using CrmUcu.Repositories;

namespace Library.Tests
{
    public class UnitTestJ4
    {
        public void Setup()
        {
            var repo = RepositorioClientes.ObtenerInstancia();
            foreach (var cliente in repo.ObtenerTodos().ToList())
            {
                repo.Eliminar(cliente);
            }
        }

        public void BuscarCliente_PorNombre_DeberiaEncontrarCorrectamente()
        {
            Setup();
            var sistema = new SistemaCRM();

            sistema.RegistrarNuevoCliente("Lucia", "Gomez", "099111111", "lucia@mail.com");
            sistema.RegistrarNuevoCliente("Martin", "Perez", "099222222", "martin@mail.com");

            var repo = RepositorioClientes.ObtenerInstancia();
            var resultados = repo.ObtenerTodos()
                                 .Where(c => c.Nombre.Contains("Lucia", StringComparison.OrdinalIgnoreCase))
                                 .ToList();

            if (resultados.Count != 1)
                throw new Exception("❌ No se encontró correctamente el cliente por nombre.");

            Console.WriteLine("✅ BuscarCliente_PorNombre_DeberiaEncontrarCorrectamente pasó correctamente.");
        }

        public void BuscarCliente_PorApellido_DeberiaEncontrarCorrectamente()
        {
            Setup();
            var sistema = new SistemaCRM();

            sistema.RegistrarNuevoCliente("Andres", "Lopez", "099333333", "andres@mail.com");
            sistema.RegistrarNuevoCliente("Maria", "Rodriguez", "099444444", "maria@mail.com");

            var repo = RepositorioClientes.ObtenerInstancia();
            var resultados = repo.ObtenerTodos()
                                 .Where(c => c.Apellido.Contains("Lopez", StringComparison.OrdinalIgnoreCase))
                                 .ToList();

            if (resultados.Count != 1)
                throw new Exception("❌ No se encontró correctamente el cliente por apellido.");

            Console.WriteLine("✅ BuscarCliente_PorApellido_DeberiaEncontrarCorrectamente pasó correctamente.");
        }

        public void BuscarCliente_PorTelefono_DeberiaEncontrarCorrectamente()
        {
            Setup();
            var sistema = new SistemaCRM();

            sistema.RegistrarNuevoCliente("Rosa", "Mendez", "099555555", "rosa@mail.com");
            sistema.RegistrarNuevoCliente("Tomas", "Diaz", "099666666", "tomas@mail.com");

            var repo = RepositorioClientes.ObtenerInstancia();
            var resultados = repo.ObtenerTodos()
                                 .Where(c => c.Telefono.Contains("099555555"))
                                 .ToList();

            if (resultados.Count != 1)
                throw new Exception("❌ No se encontró correctamente el cliente por teléfono.");

            Console.WriteLine("✅ BuscarCliente_PorTelefono_DeberiaEncontrarCorrectamente pasó correctamente.");
        }

        public void BuscarCliente_PorCorreo_DeberiaEncontrarCorrectamente()
        {
            Setup();
            var sistema = new SistemaCRM();

            sistema.RegistrarNuevoCliente("Nicolas", "Sosa", "099777777", "nicolas@mail.com");
            sistema.RegistrarNuevoCliente("Carla", "Suarez", "099888888", "carla@mail.com");

            var repo = RepositorioClientes.ObtenerInstancia();
            var resultados = repo.ObtenerTodos()
                                 .Where(c => c.Mail.Equals("carla@mail.com", StringComparison.OrdinalIgnoreCase))
                                 .ToList();

            if (resultados.Count != 1)
                throw new Exception("❌ No se encontró correctamente el cliente por correo.");

            Console.WriteLine("✅ BuscarCliente_PorCorreo_DeberiaEncontrarCorrectamente pasó correctamente.");
        }
    }
}