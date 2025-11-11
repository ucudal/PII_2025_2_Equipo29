using System;
using System.Collections.Generic;
using System.Linq;
using CrmUcu.Models.Personas;
using CrmUcu.Models.Enums;
using NUnit.Framework;

namespace CrmUcu.Tests
{
    // Clase derivada concreta para Usuario solo en este test
    public class UsuarioTestAdministrador : Usuario
    {
        public override bool Autenticar() => true;
    }

    [TestFixture]
    public class AdministradorTests
    {
        private Administrador _admin;

        [SetUp]
        public void Setup()
        {
            _admin = new Administrador
            {
                Nombre = "Admin",
                Apellido = "Test",
                UsuariosCreados = new List<Usuario>()
            };
        }

        [Test]
        public void Autenticar()
        {
            Assert.That(_admin.Autenticar(), Is.EqualTo(_admin.EstaActivo()));
        }

        [Test]
        public void CrearVendedor()
        {
            var vendedor = _admin.CrearVendedor("Juan", "Perez", "mail@dominio.com", "123456",
                                                "juanp", "password", 10);

            Assert.That(_admin.UsuariosCreados, Does.Contain(vendedor));
            Assert.That(vendedor.Nombre, Is.EqualTo("Juan"));
            Assert.That(vendedor.ComisionPorcentaje, Is.EqualTo(10));
        }

        [Test]
        public void CrearAdministrador()
        {
            var nuevoAdmin = _admin.CrearAdministrador("Ana", "Silva", "ana@mail.com", "123", "ana", "pass");

            Assert.That(_admin.UsuariosCreados, Does.Contain(nuevoAdmin));
            Assert.That(nuevoAdmin.Nombre, Is.EqualTo("Ana"));
        }

        [Test]
        public void CantidadUsuariosCreados()
        {
            _admin.CrearVendedor("Juan", "Perez", "mail@dominio.com", "123456", "juanp", "pass");
            _admin.CrearAdministrador("Ana", "Silva", "ana@mail.com", "123", "ana", "pass");

            Assert.That(_admin.CantidadUsuariosCreados(), Is.EqualTo(2));
            Assert.That(_admin.ObtenerUsuariosCreados().Count, Is.EqualTo(2));
        }

        [Test]
        public void ContenerNombreUUsuariosCreados()
        {
            _admin.CrearVendedor("Juan", "Perez", "mail@dominio.com", "123456", "juanp", "pass");

            var texto = _admin.ToString();
            Assert.That(texto, Does.Contain("Admin Test - Administrador"));
            Assert.That(texto, Does.Contain("1 usuarios creados"));
        }
    }
}