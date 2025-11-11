using System;
using System.Collections.Generic;
using System.Linq;
using CrmUcu.Models.Personas;

namespace CrmUcu.Repositories
{
    public class RepositorioVendedores : Repositorio<Vendedor>
    {
        private List<Vendedor> vendedores = new();
        private int siguienteId = 1;

        private static RepositorioVendedores? instancia;

        private RepositorioVendedores() { }

        public static RepositorioVendedores ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new RepositorioVendedores();
            }
            return instancia;
        }

        // desde aquí sobreescribimos los métodos abstractos

        public override void Agregar(Vendedor vendedor)
        {
            if (vendedor.Id == 0)
            {
                vendedor.Id = siguienteId++;
            }

            if (vendedores.Any(v => v.Id == vendedor.Id))
            {
                throw new InvalidOperationException($"Ya existe un vendedor con ID {vendedor.Id}");
            }

            vendedores.Add(vendedor);
        }

        public override List<Vendedor> ObtenerTodos()
        {
            return vendedores.ToList();
        }

        public override void Eliminar(int id)
        {
            var vendedor = vendedores.FirstOrDefault(v => v.Id == id);
            if (vendedor != null)
            {
                vendedores.Remove(vendedor);
            }
        }

        public override void Editar(Vendedor vendedor)
        {
            var existente = vendedores.FirstOrDefault(v => v.Id == vendedor.Id);
            if (existente != null)
            {
                int index = vendedores.IndexOf(existente);
                vendedores[index] = vendedor;
            }
        }

        public override List<Vendedor> Buscar(Criterio filtro)
        {
            return vendedores.ToList();
        }
        
        public int ObtenerTotal()
        {
            return vendedores.Count;
        }
    }
}