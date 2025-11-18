using CrmUcu.Models.Personas;
using CrmUcu.Models.Enums;
using CrmUcu.Repositorios;
using CrmUcu.Models.Interaccion;
using System;

namespace CrmUcu
{
    class Program
    {
        static void Main(string[] args)
        {
            var repoCliente = RepositorioCliente.ObtenerInstancia();
            var vendedor = new Vendedor(1, "flor", "ferrerira", "aa@gmail.com", "098i434", "Florchi", "nacho123");

            vendedor.CrearCliente("mufi", "silva", "mufi@gmail.com", "098431583");
            vendedor.CrearCliente("mufi", "silvaaaaaaa", "mufi@gmail.com", "098431583");
            Console.WriteLine("-------------------------------");

            
            Console.WriteLine(repoCliente.ObtenerTodos()[0].MostrarInfo());
            vendedor.ModificarCliente(0);
            
            Console.WriteLine(repoCliente.ObtenerTodos()[0].MostrarInfo());

            Console.WriteLine(vendedor.EliminarCliente(0));


        }
    }
}
