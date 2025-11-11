using CrmUcu.Models.Personas;
using NUnit.Framework;

namespace CrmUcu.Tests
{
    // Clase derivada concreta para probar Persona
    public class PersonaTestParaTest : Persona
    {
        public PersonaTestParaTest() : base() { }

        public PersonaTestParaTest(int id, string nombre, string apellido, string mail, string telefono)
            : base(id, nombre, apellido, mail, telefono) { }
    }

    [TestFixture]
    public class PersonaTests
    {
        private PersonaTestParaTest _persona;

        [SetUp]
        public void Setup()
        {
            _persona = new PersonaTestParaTest(1, "Juan", "Perez", "juan@mail.com", "123456");
        }

        [Test]
        public void ConstructorParametrizado()
        {
            Assert.That(_persona.Id, Is.EqualTo(1));
            Assert.That(_persona.Nombre, Is.EqualTo("Juan"));
            Assert.That(_persona.Apellido, Is.EqualTo("Perez"));
            Assert.That(_persona.Mail, Is.EqualTo("juan@mail.com"));
            Assert.That(_persona.Telefono, Is.EqualTo("123456"));
        }

        [Test]
        public void NombreCompleto()
        {
            Assert.That(_persona.NombreCompleto, Is.EqualTo("Juan Perez"));
        }

        [Test]
        public void ConstructorVacioa()
        {
            var personaVacia = new PersonaTestParaTest();
            Assert.That(personaVacia, Is.Not.Null);
        }
    }
}