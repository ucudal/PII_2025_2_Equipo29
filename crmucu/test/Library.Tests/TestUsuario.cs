using CrmUcu.Models.Personas;
using CrmUcu.Models.Enums;
using NUnit.Framework;

namespace CrmUcu.Tests
{
    // Clase derivada concreta para probar Usuario
    public class UsuarioTestParaTest : Usuario
    {
        public UsuarioTestParaTest() : base() { }

        public UsuarioTestParaTest(int id, string nombre, string apellido, string mail,
                                   string telefono, string nombreUsuario, string password)
            : base(id, nombre, apellido, mail, telefono, nombreUsuario, password) { }

        public override bool Autenticar()
        {
            return true; // implementamos para poder instanciar
        }
    }

    [TestFixture]
    public class UsuarioTests
    {
        private UsuarioTestParaTest _usuario;

        [SetUp]
        public void Setup()
        {
            _usuario = new UsuarioTestParaTest(1, "Ana", "Silva", "ana@mail.com", "123456", "anasilva", "pass123");
        }

        [Test]
        public void ConstructorParametrizado()
        {
            Assert.That(_usuario.Id, Is.EqualTo(1));
            Assert.That(_usuario.Nombre, Is.EqualTo("Ana"));
            Assert.That(_usuario.Apellido, Is.EqualTo("Silva"));
            Assert.That(_usuario.Mail, Is.EqualTo("ana@mail.com"));
            Assert.That(_usuario.Telefono, Is.EqualTo("123456"));
            Assert.That(_usuario.NombreDeUsuario, Is.EqualTo("anasilva"));
            Assert.That(_usuario.Password, Is.EqualTo("pass123"));
            Assert.That(_usuario.Estado, Is.EqualTo(EstadoUsuario.Activo));
        }

        [Test]
        public void EstaActivo()
        {
            Assert.That(_usuario.EstaActivo(), Is.True);
        }

        [Test]
        public void Suspender()
        {
            _usuario.Suspender();
            Assert.That(_usuario.Estado, Is.EqualTo(EstadoUsuario.Suspendido));
        }

        [Test]
        public void Activar()
        {
            _usuario.Suspender();
            _usuario.Activar();
            Assert.That(_usuario.Estado, Is.EqualTo(EstadoUsuario.Activo));
        }

        [Test]
        public void Eliminar()
        {
            _usuario.Eliminar();
            Assert.That(_usuario.Estado, Is.EqualTo(EstadoUsuario.Eliminado));
        }

        [Test]
        public void Autenticar()
        {
            Assert.That(_usuario.Autenticar(), Is.True);
        }
    }
}