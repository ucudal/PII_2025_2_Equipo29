using System;
using System.Linq;
using CrmUcu.Models.Personas;
using CrmUcu.Repositories;

namespace CrmUcu.Clientes
{
    public class EliminarClientes
    {
        private readonly RepositorioClientes repoClientes;

        public EliminarClientes()
        {
            repoClientes = RepositorioClientes.ObtenerInstancia();
        }

        public bool Eliminar(int id)
        {
            var cliente = repoClientes.ObtenerTodos().FirstOrDefault(c => c.Id == id);

            if (cliente == null)
                throw new InvalidOperationException($"No existe un cliente con ID {id}.");

            repoClientes.Eliminar(cliente);
            return true;
        }
    }
}