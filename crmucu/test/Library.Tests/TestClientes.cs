using System;
using System.Collections.Generic;
using CrmUcu.Models.Personas;
using CrmUcu.Models.Enums;
using NUnit.Framework;

namespace CrmUcu.Tests
{
    public class ClienteTestParaTest : Cliente
    {
        public ClienteTestParaTest(int id, string nombre, string apellido, string mail, string telefono)
            : base(id, nombre, apellido, mail, telefono)
        {
            Etiquetas = new List<Etiqueta>();
            Interacciones = new List<object>();
            Ventas = new List<object>();
            Cotizaciones = new List<object>();
        }
    }

    [TestFixture]
    public class ClienteTests
    {
        private ClienteTestParaTest _cliente;
        private Etiqueta _etiqueta1;
        private Etiqueta _etiqueta2;

        [SetUp]
        public void Setup()
        {
            _cliente = new ClienteTestParaTest(1, "Juan", "Perez", "mail@dominio.com", "123456");

            _etiqueta1 = new Etiqueta { Nombre = "VIP" };
            _etiqueta2 = new Etiqueta { Nombre = "Nuevo" };
        }

        [Test]
        public void Edad()
        {
            _cliente.FechaNacimiento = new DateTime(1990, 1, 1);
            var edadEsperada = DateTime.Today.Year - 1990;
            if (new DateTime(1990, 1, 1) > DateTime.Today.AddYears(-edadEsperada))
                edadEsperada--;

            Assert.That(_cliente.Edad, Is.EqualTo(edadEsperada));
        }

        [Test]
        public void EsCumpleAnios_()
        {
            _cliente.FechaNacimiento = DateTime.Today.AddYears(-30);
            Assert.That(_cliente.EsCumpleAnios(), Is.True);

            _cliente.FechaNacimiento = new DateTime(1990, 1, 1);
            Assert.That(_cliente.EsCumpleAnios(), Is.False);
        }

        [Test]
        public void AgregarEtiqueta()
        {
            _cliente.AgregarEtiqueta(_etiqueta1);
            Assert.That(_cliente.Etiquetas, Does.Contain(_etiqueta1));

            // No duplicados
            _cliente.AgregarEtiqueta(_etiqueta1);
            Assert.That(_cliente.Etiquetas.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoverEtiqueta()
        {
            _cliente.AgregarEtiqueta(_etiqueta1);
            _cliente.RemoverEtiqueta(_etiqueta1);
            Assert.That(_cliente.Etiquetas, Does.Not.Contain(_etiqueta1));
        }

        [Test]
        public void TieneEtiqueta()
        {
            _cliente.AgregarEtiqueta(_etiqueta1);
            _cliente.AgregarEtiqueta(_etiqueta2);

            Assert.That(_cliente.TieneEtiqueta("VIP"), Is.True);
            Assert.That(_cliente.TieneEtiqueta("vip"), Is.True);
            Assert.That(_cliente.TieneEtiqueta("NoExiste"), Is.False);
        }
    }
}