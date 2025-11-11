using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CRM_Exportacion
{
    class Interaccion
    {
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
    }

    class Cliente
    {
        public string Nombre { get; set; }
        public List<Interaccion> Historial { get; set; } = new List<Interaccion>();
    }

    class Exportador
    {
        public static void ExportarAExcel(Cliente cliente)
        {
            string ruta = $"{cliente.Nombre}_historial.csv";

            using (StreamWriter writer = new StreamWriter(ruta))
            {
                writer.WriteLine("Fecha,Descripción");
                foreach (var i in cliente.Historial)
                {
                    writer.WriteLine($"{i.Fecha},{i.Descripcion}");
                }
            }

            Console.WriteLine($"Historial exportado a Excel (CSV): {ruta}");
        }

        public static void ExportarAPDF(Cliente cliente)
        {
            string ruta = $"{cliente.Nombre}_historial.pdf";

            // En este ejemplo, solo genera un archivo de texto .pdf (sin librerías externas)
            using (StreamWriter writer = new StreamWriter(ruta))
            {
                writer.WriteLine($"Historial de interacciones - {cliente.Nombre}");
                writer.WriteLine("------------------------------------");
                foreach (var i in cliente.Historial)
                {
                    writer.WriteLine($"{i.Fecha}: {i.Descripcion}");
                }
            }

            Console.WriteLine($"Historial exportado a PDF (texto): {ruta}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = new Cliente
            {
                Nombre = "Juan Pérez",
                Historial = new List<Interaccion>
                {
                    new Interaccion { Fecha = DateTime.Now.AddDays(-2), Descripcion = "Llamada inicial" },
                    new Interaccion { Fecha = DateTime.Now.AddDays(-1), Descripcion = "Envió propuesta comercial" },
                    new Interaccion { Fecha = DateTime.Now, Descripcion = "Confirmó reunión" }
                }
            };

            // Exportar
            Exportador.ExportarAExcel(cliente);
            Exportador.ExportarAPDF(cliente);
        }
    }
}