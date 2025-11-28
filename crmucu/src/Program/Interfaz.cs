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

        private Stack<string> _historialAcciones;

        public Interfaz()
        {
            _repoAdmins = RepositorioAdmin.ObtenerInstancia();
            _repoVendedores = RepositorioVendedor.ObtenerInstancia();
            _repoClientes = RepositorioCliente.ObtenerInstancia();
            _historialAcciones = new Stack<string>();
        }

        // Iniciar Sesion como Usuario o como Admin
        public Usuario? IniciarSesion(string username, string password)
        {
            _historialAcciones.Push("Login");

            var admin = _repoAdmins._admins.FirstOrDefault(a => a.Autenticar(username, password));
            if (admin != null) return admin;

            var vendedor = _repoVendedores._vendedores.FirstOrDefault(v => v.Autenticar(username, password));
            if (vendedor != null) return vendedor;

            return null;
        }

        // Todos los metodos que tengan que ver con los Clientes
        public Cliente CrearCliente(string mail, string nombre, string apellido, string telefono, int idVendedor)
        {
            _historialAcciones.Push("CrearCliente");
            return _repoClientes.CrearCliente(mail, nombre, apellido, telefono, idVendedor);
        }

        public Cliente BuscarClientePorId(int id)
        {
            _historialAcciones.Push("BuscarCliente");
            return _repoClientes.BuscarPorId(id);
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
        
        public Vendedor BuscarVendedorPorId(int id)
        {
            _historialAcciones.Push("BuscarVendedor");
            return _repoVendedores._vendedores.FirstOrDefault(v => v.Id == id);
        }

        public List<Vendedor> ObtenerTodosLosVendedores()
        {
            _historialAcciones.Push("ObtenerVendedores");
            return _repoVendedores._vendedores;
        }
        
        public Admin BuscarAdminPorId(int id)
        {
            _historialAcciones.Push("BuscarAdmin");
            return _repoAdmins._admins.FirstOrDefault(a => a.Id == id);
        }

        public List<Admin> ObtenerTodosLosAdmins()
        {
            _historialAcciones.Push("ObtenerAdmins");
            return _repoAdmins._admins;
        }
        
        public bool SuspenderUsuario(int id)
        {
            _historialAcciones.Push("SuspenderUsuario");

            Usuario usuario = null;

            var vendedor = _repoVendedores._vendedores.FirstOrDefault(v => v.Id == id);
            if (vendedor != null)
            {
                usuario = vendedor;
            }
            else
            {
                var admin = _repoAdmins._admins.FirstOrDefault(a => a.Id == id);
                if (admin != null)
                {
                    usuario = admin;
                }
            }

            if (usuario != null)
            {
                usuario.Estado = EstadoUsuario.Activo;
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

        // metodo para volver a un paso anterior si es necesario
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
