using System;
using System.Collections.Generic;
using System.Linq;
using CrmUcu.Models.Personas;
using CrmUcu.Repositories;

namespace CrmUcu.Clientes
{
    public class BuscarClientes
    {
        private readonly RepositorioClientes repoClientes;

        public BuscarClientes()
        {
            repoClientes = RepositorioClientes.ObtenerInstancia();
        }

        /// <summary>
        /// Busca clientes por nombre, apellido, teléfono o correo electrónico.
        /// </summary>
        /// <param name="termino">Texto a buscar</param>
        /// <returns>Lista de clientes que coinciden con el término</returns>
        public List<Cliente> Buscar(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return new List<Cliente>();

            termino = termino.Trim().ToLower();

            return repoClientes.ObtenerTodos()
                .Where(c =>
                    (!string.IsNullOrEmpty(c.Nombre) && c.Nombre.ToLower().Contains(termino)) ||
                    (!string.IsNullOrEmpty(c.Apellido) && c.Apellido.ToLower().Contains(termino)) ||
                    (!string.IsNullOrEmpty(c.Telefono) && c.Telefono.Contains(termino)) ||
                    (!string.IsNullOrEmpty(c.Mail) && c.Mail.ToLower().Contains(termino))
                )
                .ToList();
        }
    }
}