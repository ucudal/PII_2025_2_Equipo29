using System;
using System.Collections.Generic;
using System.Linq;
using CrmUcu.Models.Personas;

namespace CrmUcu.Repositories
{
    public class RepositorioClientes : Repositorio<Cliente>
    {
        private List<Cliente> clientes = new();
        private int siguienteId = 1;

        private static RepositorioClientes? instancia;
        
        private RepositorioClientes() { }

        public static RepositorioClientes ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new RepositorioClientes();
            }
            return instancia;
        }
        public override void Agregar(Cliente cliente)
        {
            if (cliente.Id == 0)
            {
                cliente.Id = siguienteId++;
            }

            if (clientes.Any(c => c.Id == cliente.Id))
            {
                throw new InvalidOperationException($"Ya existe un cliente con ID {cliente.Id}");
            }

            clientes.Add(cliente);
        }

        public override List<Cliente> ObtenerTodos()
        {
            return clientes.ToList();
        }
        public override void Eliminar(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                clientes.Remove(cliente);
            }
        }

        public override void Editar(Cliente cliente)
        {
            var existente = clientes.FirstOrDefault(c => c.Id == cliente.Id);
            if (existente != null)
            {
                int index = clientes.IndexOf(existente);
                clientes[index] = cliente;
            }
        }

        public override List<Cliente> Buscar(Criterio filtro)
        {
            return clientes.ToList();
        }

        public int ObtenerTotal()
        {
            return clientes.Count;
        }
    }
}