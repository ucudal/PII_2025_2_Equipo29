using NUnit.Framework;
using CrmUcu.Models.Personas;
using CrmUcu.Repositories;

namespace Library.Tests
{
    [TestFixture]  
    public class HU02_ModificarClienteTests
    {
        [Test]  
        public void modificarCliente()
        {
            // Arrange
            var repoCliente = RepositorioCliente.ObtenerInstancia();  
            var vendedor = new Vendedor(1, "nacho@gmail.com", "Nacho", "Silva", "098xxxyyy", "Tachoviendo", "123nacho");
            
           // Act
           
            // Assert 
        }
    }
}
