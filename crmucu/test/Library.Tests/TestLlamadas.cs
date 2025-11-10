using System;
using System.Collections.Generic;
using CrmUcu.Models.Interacciones;
using CrmUcu.Models.Personas;
using CrmUcu.Models.Enums;
using NUnit.Framework;

namespace CrmUcu.Tests
{
    // Clases derivadas para pruebas
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
            return true;
        }
    }

    [TestFixture]
    public class LlamadaTests
    {
        private Llamada _llamada;
        private ClienteTest _cliente;
        private UsuarioTest _usuario;

        [SetUp]
        public void Setup()
        {
            _cliente = new ClienteTest("Juan", "Diaz");
            _usuario = new UsuarioTest("Ana", "Silva");

            _llamada = new Llamada
            {
                Tema = "Prueba de llamada",
                Cliente = _cliente,
                Usuario = _usuario,
                EsEntrante = true,
                DuracionSegundos = 120,
                Contestada = true,
                Notas = new List<Nota>()
            };
        }

        [Test]
        public void Inicializacion_DebeTenerTipoLlamada()
        {
            Assert.That(_llamada.Tipo, Is.EqualTo(TipoInteraccion.Llamada));
        }

        [Test]
        public void FueContestada_DebeDevolverValorCorrecto()
        {
            Assert.That(_llamada.FueContestada(), Is.True);

            _llamada.Contestada = false;
            Assert.That(_llamada.FueContestada(), Is.False);
        }

        [Test]
        public void Propiedades_DebenSerAsignables()
        {
            Assert.That(_llamada.EsEntrante, Is.True);
            Assert.That(_llamada.DuracionSegundos, Is.EqualTo(120));
            Assert.That(_llamada.Contestada, Is.True);
        }

        [Test]
        public void ProgramarDevolucion_PuedeInvocarse()
        {
            // Solo comprobamos que se pueda llamar sin errores
            Assert.DoesNotThrow(() => _llamada.ProgramarDevolucion(DateTime.Now.AddDays(1)));
        }
    }
}