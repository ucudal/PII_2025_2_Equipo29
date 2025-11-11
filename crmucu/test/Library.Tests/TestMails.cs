using System;
using System.Collections.Generic;
using CrmUcu.Models.Interacciones;
using CrmUcu.Models.Enums;
using NUnit.Framework;

namespace CrmUcu.Tests
{
    [TestFixture]
    public class MailTests
    {
        private Mail _mail;

        [SetUp]
        public void Setup()
        {
            _mail = new Mail
            {
                EsEntrante = true,
                Asunto = "Asunto de prueba",
                Destinatarios = new List<string> { "dest1@example.com", "dest2@example.com" }
            };
        }

        [Test]
        public void Constructor()
        {
            Assert.That(_mail.Tipo, Is.EqualTo(TipoInteraccion.CorreoElectronico));
            Assert.That(_mail.Leido, Is.False);
        }

        [Test]
        public void MarcarComoLeido()
        {
            _mail.MarcarComoLeido();
            Assert.That(_mail.Leido, Is.True);
        }

        [Test]
        public void Propiedadess()
        {
            Assert.That(_mail.EsEntrante, Is.True);
            Assert.That(_mail.Asunto, Is.EqualTo("Asunto de prueba"));
            Assert.That(_mail.Destinatarios.Count, Is.EqualTo(2));
            Assert.That(_mail.Destinatarios, Does.Contain("dest1@example.com"));
            Assert.That(_mail.Destinatarios, Does.Contain("dest2@example.com"));
        }
    }
}