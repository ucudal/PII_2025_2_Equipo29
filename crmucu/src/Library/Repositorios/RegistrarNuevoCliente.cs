using System;
using System.Collections.Generic;
using System.Linq;
using CrmUcu.Models.Personas;
using CrmUcu.Repositories;

namespace CrmUcu.Clientes
{
    public class RegistrarClientes
    {
        private readonly RepositorioClientes repoClientes;

        public RegistrarClientes()
        {
            repoClientes = RepositorioClientes.ObtenerInstancia();
        }

        public bool Registrar(string nombre, string apellido, string telefono, string mail)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El nombre y apellido son obligatorios.");

            if (string.IsNullOrWhiteSpace(mail) || !mail.Contains("@"))
                throw new ArgumentException("Correo electrónico no válido.");

            bool yaExiste = repoClientes.ObtenerTodos()
                .Any(c => c.Mail.Equals(mail, StringComparison.OrdinalIgnoreCase));

            if (yaExiste)
                throw new InvalidOperationException("Ya existe un cliente con ese correo electrónico.");

            Cliente nuevo = new Cliente(0, nombre, apellido, mail, telefono)
            {
                Etiquetas = new List<Etiqueta>(),
                Interacciones = new List<object>(),
                Ventas = new List<object>(),
                Cotizaciones = new List<object>()
            };

            repoClientes.Agregar(nuevo);
            return true;
        }
    }
}