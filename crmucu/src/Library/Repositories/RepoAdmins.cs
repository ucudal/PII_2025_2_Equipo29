using System;
using System.Collections.Generic;
using System.Linq;
using CrmUcu.Models.Personas;

namespace CrmUcu.Repositories
{
    public class RepositorioAdministradores : Repositorio<Administrador>
    {
        private List<Administrador> administradores = new();
        private int siguienteId = 1;

        private static RepositorioAdministradores? instancia;
        
        private RepositorioAdministradores() { }

        public static RepositorioAdministradores ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new RepositorioAdministradores();
            }
            return instancia;
        }

        // Acá agragamos 
        public override void Agregar(Administrador administrador)
        {
            if (administrador.Id == 0)
            {
                administrador.Id = siguienteId++;
            }

            if (administradores.Any(a => a.Id == administrador.Id))
            {
                throw new InvalidOperationException($"Ya existe un administrador con ID {administrador.Id}");
            }

            administradores.Add(administrador);
        }

        // acá buscamos al que se tiró un pedo
        public Administrador? BuscarPorId(int id)
        {
            return administradores.FirstOrDefault(a => a.Id == id);
        }

        public Administrador? BuscarPorNombreUsuario(string nombreUsuario)
        {
            return administradores.FirstOrDefault(a =>
                a.NombreDeUsuario.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase));
        }

        public Administrador? BuscarPorEmail(string email)
        {
            return administradores.FirstOrDefault(a =>
                a.Mail.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        // desde aquí sobreescribimos los métodos abstractos
        public override List<Administrador> ObtenerTodos()
        {
            return administradores.ToList();
        }

        public override void Eliminar(int id)
        {
            var administrador = administradores.FirstOrDefault(a => a.Id == id);
            if (administrador != null)
            {
                administradores.Remove(administrador);
            }
        }

        public override void Editar(Administrador administrador)
        {
            var existente = administradores.FirstOrDefault(a => a.Id == administrador.Id);
            if (existente != null)
            {
                int index = administradores.IndexOf(existente);
                administradores[index] = administrador;
            }
        }

        public override List<Administrador> Buscar(Criterio filtro)
        {
            return administradores.ToList();
        }
        
        public List<Administrador> ObtenerActivos()
        {
            return administradores.Where(a => a.EstaActivo()).ToList();
        }

        public int ObtenerTotal()
        {
            return administradores.Count;
        }

        public bool Existe(int id)
        {
            return administradores.Any(a => a.Id == id);
        }
    }
}