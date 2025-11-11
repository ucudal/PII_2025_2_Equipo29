using System.Collections.Generic;
using CrmUcu.Models.Interacciones;
using CrmUcu.Models.Personas;
using CrmUcu.Models.Enums;
using NUnit.Framework;

namespace CrmUcu.Tests
{
    // Clase derivada concreta para poder instanciar Persona
    public class PersonaTest : Persona { }

    [TestFixture]
    public class ReunionTests
    {
        private Reunion _reunion;
        private PersonaTest _persona1;
        private PersonaTest _persona2;

        [SetUp]
        public void Setup()
        {
            _persona1 = new PersonaTest();
            _persona2 = new PersonaTest();

            _reunion = new Reunion
            {
                Ubicacion = "Sala 1",
                DuracionMinutos = 60,
                Participantes = new List<Persona>()
            };
        }

        [Test]
        public void Constructoro()
        {
            Assert.That(_reunion.Tipo, Is.EqualTo(TipoInteraccion.Reunion));
            Assert.That(_reunion.Estado, Is.EqualTo(EstadoReunion.Agendada));
        }

        [Test]
        public void AgregarParticipante()
        {
            _reunion.AgregarParticipante(_persona1);
            Assert.That(_reunion.Participantes, Does.Contain(_persona1));

            // No agregar duplicados
            _reunion.AgregarParticipante(_persona1);
            Assert.That(_reunion.Participantes.Count, Is.EqualTo(1));
        }

        [Test]
        public void MarcarComoCompletada()
        {
            _reunion.MarcarComoCompletada();
            Assert.That(_reunion.Estado, Is.EqualTo(EstadoReunion.Realizada));
        }

        [Test]
        public void Cancelar()
        {
            _reunion.Cancelar();
            Assert.That(_reunion.Estado, Is.EqualTo(EstadoReunion.Cancelada));
        }

        [Test]
        public void Propiedades()
        {
            Assert.That(_reunion.Ubicacion, Is.EqualTo("Sala 1"));
            Assert.That(_reunion.DuracionMinutos, Is.EqualTo(60));
            Assert.That(_reunion.Participantes.Count, Is.EqualTo(0));
        }
    }
}