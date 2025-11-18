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

        private RepositorioClientes()
        {
            
        }
        
        
        
        public static RepositorioClientes ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new RepositorioClientes();
            }
            return instancia;
        }
        // editar clientes
        
        public void Modificar(int id, string? nombre, string? apellido, string? telefono, string? mail)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id)
                          ?? throw new KeyNotFoundException("El cliente no existe.");

            if (!string.IsNullOrWhiteSpace(nombre))
                cliente.Nombre = nombre;

            if (!string.IsNullOrWhiteSpace(apellido))
                cliente.Apellido = apellido;

            if (!string.IsNullOrWhiteSpace(telefono))
                cliente.Telefono = telefono;

            if (!string.IsNullOrWhiteSpace(mail))
                cliente.Mail = mail;
        }
        
        // agregar y eliminar
        public override void Agregar(Cliente cliente)
        {
            if (cliente.Id == 0)
            {
                cliente.Id = siguienteId++;
            }

            if (clientes.Any(c => c.Id == cliente.Id))
            {
                throw new InvalidOperationException($"Ya existe un cliente con la ID {cliente.Id}");
            }

            clientes.Add(cliente);
        }
        
        public override void Eliminar(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                clientes.Remove(cliente);
            }
        }
        // presentar lista de clientes
        
        public override List<Cliente> ObtenerTodos()
        {
            return clientes.ToList();
        }  
        public int ObtenerTotal()
        {
            return clientes.Count;
        }
    }
}