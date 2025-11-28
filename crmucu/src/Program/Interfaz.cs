using CrmUcu.Models.Personas;
using CrmUcu.Repositories;
using CrmUcu.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrmUcu.Core
{
    public class Interfaz
    {
        private readonly RepositorioAdmin _repoAdmins;
        private readonly RepositorioVendedor _repoVendedores;
        private readonly RepositorioCliente _repoClientes;
        private readonly RepositorioInteraccion _repoInteracciones;
        private readonly RepositorioEtiqueta _repoEtiquetas;

        private Stack<string> _historialAcciones;

        public Interfaz()
        {
            _repoAdmins = RepositorioAdmin.ObtenerInstancia();
            _repoVendedores = RepositorioVendedor.ObtenerInstancia();
            _repoClientes = RepositorioCliente.ObtenerInstancia();
            //_repoInteracciones = RepositorioInteraccion.ObtenerInstancia();
            _repoEtiquetas = RepositorioEtiqueta.ObtenerInstancia();
            _historialAcciones = new Stack<string>();
        }

        // Login
        public Usuario IniciarSesion(string username, string password)
        {
            _historialAcciones.Push("Login");

            var admin = _repoAdmins._admins.FirstOrDefault(a => a.Autenticar(username, password));
            if (admin != null) return admin;

            var vendedor = _repoVendedores._vendedores.FirstOrDefault(v => v.Autenticar(username, password));
            if (vendedor != null) return vendedor;

            return null;
        }

        // Clientes
        public Vendedor CrearCliente(string mail, string nombre, string apellido, string telefono, DateTime fechaNacimiento, Genero? genero, int idVendedor)
        {
            _historialAcciones.Push("CrearCliente");
            return _repoClientes.CrearCliente(mail, nombre, apellido, telefono, fechaNacimiento, genero, idVendedor);
        }

        public Cliente BuscarClientePorId(int id)
        {
            _historialAcciones.Push("BuscarCliente");
            return _repoClientes.BuscarPorId(id);
        }

        public void ModificarCliente(int id, string nombre, string apellido, string mail, string telefono, DateTime? fechaNacimiento, string? genero)
        {
            _historialAcciones.Push("ModificarCliente");
            _repoVendedores.ModificarCliente(id, nombre, apellido, mail, telefono, fechaNacimiento, genero);
        }

        public void EliminarCliente(int id)
        {
            _historialAcciones.Push("EliminarCliente");
            _repoClientes.EliminarCliente(id);
        }

        public List<Cliente> ObtenerTodosLosClientes()
        {
            _historialAcciones.Push("ObtenerClientes");
            return _repoClientes.ObtenerTodos();
        }

        public List<Cliente> ObtenerClientesPorVendedor(int idVendedor)
        {
            _historialAcciones.Push("MostrarMisClientes");
            return _repoClientes.ObtenerPorVendedor(idVendedor);
        }

        public void ReasignarCliente(int idCliente, int nuevoIdVendedor)
        {
            _historialAcciones.Push("ReasignarCliente");
            _repoClientes.ReasignarCliente(idCliente, nuevoIdVendedor);
        }

        public List<Cliente> ObtenerClientesInactivos(int idVendedor)
        {
            _historialAcciones.Push("VerInactivos");
            return _repoClientes.ObtenerInactivos(idVendedor);
        }

        public List<Cliente> ObtenerContactosViejos(int idVendedor, DateTime fechaLimite)
        {
            _historialAcciones.Push("VerContactosViejos");
            return _repoClientes.ObtenerSinInteraccionDesde(idVendedor, fechaLimite);
        }

        // Interacciones
        public void RegistrarInteraccion(int idCliente, TipoInteraccion tipo, string descripcion)
        {
            _historialAcciones.Push("RegistrarInteraccion");
            _repoInteracciones.Registrar(idCliente, tipo, descripcion);
        }

        public List<Interaccion> VerInteracciones(int idCliente)
        {
            _historialAcciones.Push("VerInteracciones");
            return _repoInteracciones.ObtenerPorCliente(idCliente);
        }

        public decimal CalcularVentasPeriodo(int idVendedor, DateTime inicio, DateTime fin)
        {
            _historialAcciones.Push("CalcularVentasPeriodo");
            return _repoInteracciones.CalcularVentas(idVendedor, inicio, fin);
        }

        // Etiquetas
        public Etiqueta CrearEtiqueta(string nombre)
        {
            _historialAcciones.Push("CrearEtiqueta");
            return _repoEtiquetas.CrearEtiqueta(nombre);
        }

        public void AsignarEtiqueta(int idCliente, int idEtiqueta)
        {
            _historialAcciones.Push("AsignarEtiqueta");
            _repoEtiquetas.AsignarEtiqueta(idCliente, idEtiqueta);
        }

        // Usuarios
        public Admin CrearAdmin(string nombre, string apellido, string mail, string telefono, string nombreUsuario, string password)
        {
            _historialAcciones.Push("CrearAdmin");
            return _repoAdmins.CrearAdmin(nombre, apellido, mail, telefono, nombreUsuario, password);
        }

        public Vendedor CrearVendedor(string nombre, string apellido, string mail, string telefono, string nombreUsuario, string password)
        {
            _historialAcciones.Push("CrearVendedor");
            return _repoVendedores.CrearVendedor(nombre, apellido, mail, telefono, nombreUsuario, password);
        }

        public Usuario BuscarUsuarioPorId(int id, TipoUsuario tipo)
        {
            _historialAcciones.Push("BuscarUsuario");

            return tipo switch
            {
                TipoUsuario.Admin => _repoAdmins._admins.FirstOrDefault(a => a.Id == id),
                TipoUsuario.Vendedor => _repoVendedores._vendedores.FirstOrDefault(v => v.Id == id),
                _ => null
            };
        }

        public bool SuspenderUsuario(int id)
        {
            _historialAcciones.Push("SuspenderUsuario");

            Usuario usuario = _repoVendedores._vendedores.FirstOrDefault(v => v.Id == id)
                           ?? _repoAdmins._admins.FirstOrDefault(a => a.Id == id);

            if (usuario != null)
            {
                usuario.Estado = EstadoUsuario.Suspendido;
                return true;
            }

            return false;
        }

        public bool EliminarUsuario(int id)
        {
            _historialAcciones.Push("EliminarUsuario");

            var vendedor = _repoVendedores._vendedores.FirstOrDefault(v => v.Id == id);
            if (vendedor != null)
            {
                _repoVendedores._vendedores.Remove(vendedor);
                return true;
            }

            var admin = _repoAdmins._admins.FirstOrDefault(a => a.Id == id);
            if (admin != null)
            {
                _repoAdmins._admins.Remove(admin);
                return true;
            }

            return false;
        }

        public List<Vendedor> ObtenerTodosLosVendedores()
        {
            _historialAcciones.Push("ObtenerVendedores");
            return _repoVendedores._vendedores;
        }

        public List<Admin> ObtenerTodosLosAdmins()
        {
            _historialAcciones.Push("ObtenerAdmins");
            return _repoAdmins._admins;
        }

        // Navegación
        public string VolverPasoAnterior()
        {
            if (_historialAcciones.Count > 1)
            {
                _historialAcciones.Pop();
                return _historialAcciones.Peek();
            }
            return null;
        }
    }
}
