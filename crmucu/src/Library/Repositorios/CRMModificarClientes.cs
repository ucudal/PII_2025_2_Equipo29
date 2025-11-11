using System;
using System.Linq;
using CrmUcu.Models.Personas;
using CrmUcu.Repositories;

namespace CrmUcu.Clientes
{
    public class ModificarClientes
    {
        private readonly RepositorioClientes repoClientes;

        public ModificarClientes()
        {
            repoClientes = RepositorioClientes.ObtenerInstancia();
        }

        public bool Modificar(int id, string nuevoNombre, string nuevoApellido, string nuevoTelefono, string nuevoMail)
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
    }
}