using System;
using CrmUcu.Models.Personas;
using NUnit.Framework;

namespace CrmUcu.Tests
{
    [TestFixture]
    public class EtiquetaTests
    {
        private Etiqueta _etiqueta1;
        private Etiqueta _etiqueta2;

        [SetUp]
        public void Setup()
        {
            _etiqueta1 = new Etiqueta("VIP", "Rojo", "Cliente importante");
            _etiqueta2 = new Etiqueta("Nuevo", "Verde", "Cliente nuevo");
        }

        [Test]
        public void Constructor()
        {
            Assert.That(_etiqueta1.Nombre, Is.EqualTo("VIP"));
            Assert.That(_etiqueta1.Color, Is.EqualTo("Rojo"));
            Assert.That(_etiqueta1.Descripcion, Is.EqualTo("Cliente importante"));
            Assert.That(_etiqueta1.FechaCreacion, Is.Not.EqualTo(default(DateTime)));
        }

        [Test]
        public void EqualsTrue()
        {
            var etiquetaCopia = new Etiqueta("VIP") { Id = 1 };
            _etiqueta1.Id = 1;

            Assert.That(_etiqueta1.Equals(etiquetaCopia), Is.True);
        }

        [Test]
        public void EqualsFalse()
        {
            _etiqueta1.Id = 1;
            _etiqueta2.Id = 2;

            Assert.That(_etiqueta1.Equals(_etiqueta2), Is.False);
        }

        [Test]
        public void ToString()
        {
            var texto = _etiqueta1.ToString();
            Assert.That(texto, Does.Contain("[VIP]"));
            Assert.That(texto, Does.Contain("Cliente importante"));
        }

        [Test]
        public void ConstructorVacio()
        {
            var etiquetaVacia = new Etiqueta();
            Assert.That(etiquetaVacia.Nombre, Is.EqualTo(string.Empty));
            Assert.That(etiquetaVacia.FechaCreacion, Is.Not.EqualTo(default(DateTime)));
        }
    }
}