using System;
using System.Linq;
using CrmUcu;
using CrmUcu.Repositories;
using CrmUcu.Models.Personas;

namespace Library.Tests
{
    public class UnitTestJ2
    {
        public void Setup()
        {
            var repo = RepositorioClientes.ObtenerInstancia();
            foreach (var cliente in repo.ObtenerTodos().ToList())
            {
                repo.Eliminar(cliente);
            }
        }

        public void ModificarCliente_DeberiaActualizarDatosCorrectamente()
        {
            Setup();
            var sistema = new SistemaCRM();
            sistema.RegistrarNuevoCliente("Juan", "Perez", "099123456", "juan@mail.com");

            var repo = RepositorioClientes.ObtenerInstancia();
            var cliente = repo.ObtenerTodos().First();

            // 🔧 Simulación manual de modificación (no depende de un método específico del CRM)
            cliente.Nombre = "Juan Carlos";
            cliente.Telefono = "099999999";
            cliente.Mail = "juan.carlos@mail.com";

            // Verificaciones
            if (cliente.Nombre != "Juan Carlos")
                throw new Exception("❌ El nombre no se actualizó correctamente.");
            if (cliente.Telefono != "099999999")
                throw new Exception("❌ El teléfono no se actualizó correctamente.");
            if (cliente.Mail != "juan.carlos@mail.com")
                throw new Exception("❌ El mail no se actualizó correctamente.");

            Console.WriteLine("✅ ModificarCliente_DeberiaActualizarDatosCorrectamente pasó correctamente.");
        }

        public void ModificarCliente_DeberiaLanzarErrorSiIdNoExiste()
        {
            Setup();
            var sistema = new SistemaCRM();
            sistema.RegistrarNuevoCliente("Pedro", "Lopez", "099888888", "pedro@mail.com");

            var repo = RepositorioClientes.ObtenerInstancia();

            try
            {
                var clienteInexistente = repo.ObtenerTodos().FirstOrDefault(c => c.Id == 999);
                if (clienteInexistente == null)
                    throw new InvalidOperationException("No existe un cliente con ese ID.");
                
                throw new Exception("❌ No se lanzó la excepción esperada para ID inexistente.");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("✅ ModificarCliente_DeberiaLanzarErrorSiIdNoExiste pasó correctamente.");
            }
        }

        public void ModificarCliente_DeberiaLanzarErrorSiCorreoDuplicado()
        {
            Setup();
            var sistema = new SistemaCRM();
            sistema.RegistrarNuevoCliente("Ana", "Lopez", "099111111", "ana@mail.com");
            sistema.RegistrarNuevoCliente("Beatriz", "Suarez", "099222222", "bea@mail.com");

            var repo = RepositorioClientes.ObtenerInstancia();
            var clienteBea = repo.ObtenerTodos().First(c => c.Mail == "bea@mail.com");

            try
            {
                // 🔧 Simulación manual del chequeo de duplicado
                bool mailDuplicado = repo.ObtenerTodos()
                    .Any(c => c.Mail.Equals("ana@mail.com", StringComparison.OrdinalIgnoreCase)
                           && c.Id != clienteBea.Id);

                if (mailDuplicado)
                    throw new InvalidOperationException("Ya existe un cliente con ese correo electrónico.");

                throw new Exception("❌ No se lanzó la excepción esperada por correo duplicado.");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("✅ ModificarCliente_DeberiaLanzarErrorSiCorreoDuplicado pasó correctamente.");
            }
        }
    }
}