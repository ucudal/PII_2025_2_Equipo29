using System;
using System.Collections.Generic;
using CrmUcu.Models.Personas;
using CrmUcu.Models.Enums;
using NUnit.Framework;

namespace CrmUcu.Tests
{
    [TestFixture]
    public class VendedorTests
    {
        private Vendedor _vendedor;
        private ClienteTestParaTest _cliente1;
        private ClienteTestParaTest _cliente2;

        [SetUp]
        public void Setup()
        {
            _vendedor = new Vendedor(1, "Juan", "Perez", "juan@mail.com", "123456", "juanp", "pass", 10);
            
            _cliente1 = new ClienteTestParaTest(1, "Cliente1", "Uno", "c1@mail.com", "111");
            _cliente2 = new ClienteTestParaTest(2, "Cliente2", "Dos", "c2@mail.com", "222");
        }

        [Test]
        public void ConstructorParametrizado_DebeAsignarPropiedades()
        {
            Assert.That(_vendedor.Id, Is.EqualTo(1));
            Assert.That(_vendedor.Nombre, Is.EqualTo("Juan"));
            Assert.That(_vendedor.Apellido, Is.EqualTo("Perez"));
            Assert.That(_vendedor.Mail, Is.EqualTo("juan@mail.com"));
            Assert.That(_vendedor.Telefono, Is.EqualTo("123456"));
            Assert.That(_vendedor.NombreDeUsuario, Is.EqualTo("juanp"));
            Assert.That(_vendedor.Password, Is.EqualTo("pass"));
            Assert.That(_vendedor.ComisionPorcentaje, Is.EqualTo(10));
            Assert.That(_vendedor.Clientes, Is.Empty);
        }

        [Test]
        public void Autenticar_DebeDevolverEstaActivo()
        {
            Assert.That(_vendedor.Autenticar(), Is.EqualTo(_vendedor.EstaActivo()));
        }

        [Test]
        public void AsignarCliente_DebeAgregarClienteSiNoExiste()
        {
            _vendedor.AsignarCliente(_cliente1);

            Assert.That(_vendedor.Clientes, Does.Contain(_cliente1));
            Assert.That(_cliente1.Vendedor, Is.EqualTo(_vendedor));

            // No duplicar
            _vendedor.AsignarCliente(_cliente1);
            Assert.That(_vendedor.Clientes.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoverCliente_DebeEliminarCliente()
        {
            _vendedor.AsignarCliente(_cliente1);
            _vendedor.RemoverCliente(_cliente1);

            Assert.That(_vendedor.Clientes, Does.Not.Contain(_cliente1));
            Assert.That(_cliente1.Vendedor, Is.Null);
        }

        [Test]
        public void ObtenerClientes_DebeDevolverListaCorrecta()
        {
            _vendedor.AsignarCliente(_cliente1);
            _vendedor.AsignarCliente(_cliente2);

            var clientes = _vendedor.ObtenerClientes();
            Assert.That(clientes.Count, Is.EqualTo(2));
            Assert.That(clientes, Does.Contain(_cliente1));
            Assert.That(clientes, Does.Contain(_cliente2));
        }

        [Test]
        public void CantidadClientes_DebeDevolverNumeroCorrecto()
        {
            _vendedor.AsignarCliente(_cliente1);
            _vendedor.AsignarCliente(_cliente2);

            Assert.That(_vendedor.CantidadClientes(), Is.EqualTo(2));
        }
    }
}