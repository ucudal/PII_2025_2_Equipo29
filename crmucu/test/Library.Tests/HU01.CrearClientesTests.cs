using NUnit.Framework;
using CrmUcu.Models.Personas;
using CrmUcu.Repositories;

namespace Library.Tests
{
    [TestFixture]  
    public class HU01_CrearClienteTests
    {
        [Test]  
        public void CrearCliente_ConInformacionBasica_DeberiaCrearClienteCorrectamente()
        {
            // Arrange
            var repoCliente = RepositorioCliente.ObtenerInstancia();  // ← Cambio aquí
            var vendedor = new Vendedor(1, "nacho@gmail.com", "Nacho", "Silva", "098xxxyyy", "Tachoviendo", "123nacho");
            
            string nombre = "Florencia";
            string apellido = "Ferreira";
            string mail = "flor@gmail.com";
            string celular = "098111222";
            
            // Act
            vendedor.CrearCliente(nombre, apellido, mail, celular);
            var cliente = repoCliente._clientes[0];
            // Assert - SIN el signo =
            Assert.That(cliente, Is.Not.Null);
            Assert.That(cliente.Nombre, Is.EqualTo(nombre));  // ← Sin =
            Assert.That(cliente.Apellido, Is.EqualTo(apellido));  // ← Sin =
            Assert.That(cliente.Mail, Is.EqualTo(mail));  // ← Sin =
            Assert.That(cliente.Telefono, Is.EqualTo(celular));  // ← Sin =
        }
    }
}
