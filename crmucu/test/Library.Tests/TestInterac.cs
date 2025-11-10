using System;
using System.Collections.Generic;
using CrmUcu.Models.Interacciones;
using CrmUcu.Models.Personas;
using CrmUcu.Models.Enums;
using NUnit.Framework;

namespace TestsIteac
{
    public class InteraccionTest : Interaccion { }

    public class ClienteTest : Cliente
    {
        public ClienteTest(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }
    }

    public class UsuarioTest : Usuario
    {
        public UsuarioTest(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }

        public override bool Autenticar()
        {
            return true; // Implementación mínima para tests
        }
    }

    [TestFixture]
    public class InteraccionTests
    {
        private InteraccionTest _interaccion;
        private ClienteTest _cliente;
        private UsuarioTest _usuario;

        [SetUp]
        public void Setup()
        {
            _cliente = new ClienteTest("Juan", "Diaz");
            _usuario = new UsuarioTest("Ana", "Silva");

            _interaccion = new InteraccionTest
            {
                Tema = "Tema de prueba",
                Tipo = TipoInteraccion.Llamada,
                Cliente = _cliente,
                Usuario = _usuario,
                Notas = new List<Nota>()
            };
        }

        [Test]
        public void AgregarNota_DebeAgregarNotaALaLista()
        {
            _interaccion.AgregarNota("Contenido de prueba", _usuario);

            Assert.That(_interaccion.Notas.Count, Is.EqualTo(1));
            Assert.That(_interaccion.Notas[0].Contenido, Is.EqualTo("Contenido de prueba"));
            Assert.That(_interaccion.Notas[0].Autor, Is.EqualTo(_usuario));
        }

        [Test]
        public void EliminarNota_DebeEliminarNotaDeLaLista()
        {
            var nota = new Nota { Contenido = "Nota a eliminar", Autor = _usuario, FechaCreacion = DateTime.Now };
            _interaccion.Notas.Add(nota);

            _interaccion.EliminarNota(nota);

            Assert.That(_interaccion.Notas, Is.Empty);
        }

        [Test]
        public void ObtenerResumen_DebeDevolverResumenCorrecto()
        {
            string resumen = _interaccion.ObtenerResumen();

            Assert.That(resumen, Does.Contain("Llamada"));
            Assert.That(resumen, Does.Contain("Tema de prueba"));
            Assert.That(resumen, Does.Contain("Juan Diaz"));
        }
    }
}