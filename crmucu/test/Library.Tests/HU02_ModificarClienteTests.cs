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
            var repoCliente = RepositorioCliente.ObtenerInstancia();  
            var vendedor = new Vendedor(1, "nacho@gmail.com", "Nacho", "Silva", "098xxxyyy", "Tachoviendo", "123nacho");
            
           // Act
           
            // Assert 
        }
    }
}
