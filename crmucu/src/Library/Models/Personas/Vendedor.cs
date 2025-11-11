using System;
using System.Collections.Generic;
using System.Linq;
using CrmUcu.Repositories;

namespace CrmUcu.Models.Personas
{
    public class Vendedor : Usuario
    {
        public decimal ComisionPorcentaje { get; set; }
        public List<Cliente> Clientes { get; set; } = new();

        private readonly RepositorioClientes repoClientes;

        public Vendedor() : base()
        {
            repoClientes = RepositorioClientes.ObtenerInstancia();
        }

        public Vendedor(int id, string nombre, string apellido, string mail,
                       string telefono, string nombreUsuario, string password, decimal comision)
            : base(id, nombre, apellido, mail, telefono, nombreUsuario, password)
        {
            ComisionPorcentaje = comision;
            repoClientes = RepositorioClientes.ObtenerInstancia();
        }

        public override bool Autenticar()
        {
            return EstaActivo();
        }

        // ======================================================
        //               Registrar Clientes
        public bool RegistrarCliente(string nombre, string apellido, string telefono, string mail)
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
            Clientes.Add(nuevo);
            nuevo.Vendedor = this;

            Console.WriteLine($"Cliente {nuevo.NombreCompleto} registrado y asignado a {this.NombreCompleto}.");
            return true;
        }

        // ======================================================
        //   Buscar Clientes
        public List<Cliente> BuscarClientes(string termino)
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

        // ======================================================
        //  Modificar Clientes
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

            Console.WriteLine($"Cliente {cliente.NombreCompleto} modificado correctamente.");
            return true;
        }

        // ======================================================
        // Asignar y Remover Clientes
        public void AsignarCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            if (!Clientes.Contains(cliente))
            {
                Clientes.Add(cliente);
                cliente.Vendedor = this;
                Console.WriteLine($"Cliente {cliente.NombreCompleto} asignado a vendedor {this.NombreCompleto}");
            }
        }

        public void RemoverCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            if (Clientes.Remove(cliente))
            {
                cliente.Vendedor = null;
                Console.WriteLine($"Cliente {cliente.NombreCompleto} removido del vendedor {this.NombreCompleto}");
            }
        }

        // ======================================================

        public List<Cliente> ObtenerClientes()
        {
            return Clientes.ToList();
        }

        public int CantidadClientes()
        {
            return Clientes.Count;
        }
    }
}