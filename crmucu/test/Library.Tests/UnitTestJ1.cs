using NUnit.Framework;
using CrmUcu;
using CrmUcu.Repositories;
using System;
using System.Linq;

namespace CrmUcu.Tests
{
    public class SistemaCRMTests
    {
        [SetUp]
        public void Setup()
        {
            var repo = RepositorioClientes.ObtenerInstancia();
            foreach (var cliente in repo.ObtenerTodos().ToList())
            {
                repo.Eliminar(cliente);
            }
        }

        [Test]
        public void RegistrarNuevoCliente_DeberiaRegistrarClienteValido()
        {
            var sistema = new SistemaCRM();
            var repo = RepositorioClientes.ObtenerInstancia();

            bool resultado = sistema.RegistrarNuevoCliente("Juan", "Pérez", "099123456", "juan@mail.com");

            Assert.That(resultado, Is.True);
            Assert.That(repo.ObtenerTodos().Any(c => c.Mail == "juan@mail.com"), Is.True);
        }

        [Test]
        public void RegistrarNuevoCliente_DeberiaLanzarErrorPorCorreoDuplicado()
        {
            var sistema = new SistemaCRM();
            sistema.RegistrarNuevoCliente("Ana", "Lopez", "099987654", "ana@mail.com");

            Assert.Throws<InvalidOperationException>(() =>
                sistema.RegistrarNuevoCliente("Ana", "Lopez", "099000111", "ana@mail.com"));
        }

        [Test]
        public void RegistrarNuevoCliente_DeberiaLanzarErrorPorCorreoInvalido()
        {
            var sistema = new SistemaCRM();

            Assert.Throws<ArgumentException>(() =>
                sistema.RegistrarNuevoCliente("Carlos", "Diaz", "099555555", "correo_invalido"));
        }
    }
}