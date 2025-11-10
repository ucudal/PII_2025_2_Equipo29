using System;
using System.Linq;
using CrmUcu.Models.Personas;
using CrmUcu.Repositories;

namespace CrmUcu
{
    public class SistemaCRM
    {
        public readonly RepositorioClientes repoClientes;

        public SistemaCRM()
        {
            repoClientes = RepositorioClientes.ObtenerInstancia();
        }

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

            Cliente nuevo = new Cliente(0, nombre, apellido, mail, telefono);
            repoClientes.Agregar(nuevo);
            return true;
        }

        public bool EliminarCliente(int id)
        {
            var cliente = repoClientes.ObtenerTodos().FirstOrDefault(c => c.Id == id);

            if (cliente == null)
                throw new InvalidOperationException($"No existe un cliente con ID {id}");

            repoClientes.Eliminar(cliente);
            return true;
        }
    }
}