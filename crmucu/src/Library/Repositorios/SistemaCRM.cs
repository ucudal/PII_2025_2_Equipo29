using System;
using System.Collections.Generic;
using System.Linq;
using CrmUcu.Models.Personas;
using CrmUcu.Repositories;

namespace CrmUcu
{
    public class SistemaCRM
    {
        private readonly RepositorioClientes repoClientes;

        public SistemaCRM()
        {
            repoClientes = RepositorioClientes.ObtenerInstancia();
        }

        // 🟢 Registrar cliente
        public bool RegistrarNuevoCliente(string nombre, string apellido, string telefono, string mail)
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

        // 🟡 Modificar cliente existente
        public bool ModificarCliente(int id, string nuevoNombre, string nuevoApellido, string nuevoTelefono, string nuevoMail)
        {
            var cliente = repoClientes.ObtenerTodos().FirstOrDefault(c => c.Id == id);

            if (cliente == null)
                throw new InvalidOperationException("No existe un cliente con ese ID.");

            bool mailDuplicado = repoClientes.ObtenerTodos()
                .Any(c => c.Mail.Equals(nuevoMail, StringComparison.OrdinalIgnoreCase) && c.Id != id);

            if (mailDuplicado)
                throw new InvalidOperationException("Ya existe un cliente con ese correo electrónico.");

            cliente.Nombre = nuevoNombre;
            cliente.Apellido = nuevoApellido;
            cliente.Telefono = nuevoTelefono;
            cliente.Mail = nuevoMail;

            return true;
        }

        // 🧾 Mostrar clientes
        public void MostrarClientes()
        {
            var clientes = repoClientes.ObtenerTodos();
            Console.WriteLine("\n=== Clientes registrados ===");

            if (clientes.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados.");
                return;
            }

            foreach (var c in clientes)
            {
                Console.WriteLine($"{c.Id}. {c.Nombre} {c.Apellido} - {c.Mail} - {c.Telefono}");
            }
        }

        // 🔴 Eliminar cliente
        public bool EliminarCliente(int id)
        {
            var cliente = repoClientes.ObtenerTodos().FirstOrDefault(c => c.Id == id);

            if (cliente == null)
                throw new InvalidOperationException($"No existe un cliente con ID {id}.");

            repoClientes.Eliminar(cliente);
            return true;
        }
    }
}