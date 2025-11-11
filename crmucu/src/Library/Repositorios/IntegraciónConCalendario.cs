using System;
using System.Collections.Generic;

namespace CRM_Calendario
{
    class Reunion
    {
        public DateTime Fecha { get; set; }
        public string Asunto { get; set; }
        public string Lugar { get; set; }
    }

    class Cliente
    {
        public string Nombre { get; set; }
        public List<Reunion> Reuniones { get; set; } = new List<Reunion>();
    }

    class GoogleCalendarService
    {
        // En una implementación real, este método se conectaría a la API de Google Calendar.
        public static void SincronizarReunion(Reunion reunion, string clienteNombre)
        {
            Console.WriteLine($"[Simulado] Sincronizando reunión con Google Calendar...");
            Console.WriteLine($"Cliente: {clienteNombre}");
            Console.WriteLine($"Asunto: {reunion.Asunto}");
            Console.WriteLine($"Fecha: {reunion.Fecha}");
            Console.WriteLine($"Lugar: {reunion.Lugar}");
            Console.WriteLine("✅ Reunión sincronizada correctamente.\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = new Cliente
            {
                Nombre = "María López",
                Reuniones = new List<Reunion>
                {
                    new Reunion
                    {
                        Asunto = "Presentación de producto",
                        Fecha = DateTime.Now.AddDays(1).AddHours(15),
                        Lugar = "Oficina central"
                    },
                    new Reunion
                    {
                        Asunto = "Revisión de contrato",
                        Fecha = DateTime.Now.AddDays(3).AddHours(10),
                        Lugar = "Videollamada Zoom"
                    }
                }
            };

            Console.WriteLine($"Sincronizando reuniones del cliente {cliente.Nombre}...\n");

            foreach (var reunion in cliente.Reuniones)
            {
                GoogleCalendarService.SincronizarReunion(reunion, cliente.Nombre);
            }
        }
    }
}



// Ejemplo de cómo sería en una versión real:

// var service = new CalendarService(new BaseClientService.Initializer()
// {
//     HttpClientInitializer = credential,
//     ApplicationName = "Mi CRM",
// });

// var evento = new Event()
// {
//     Summary = reunion.Asunto,
//     Location = reunion.Lugar,
//     Start = new EventDateTime() { DateTime = reunion.Fecha },
//     End = new EventDateTime() { DateTime = reunion.Fecha.AddHours(1) }
// };

// service.Events.Insert(evento, "primary").Execute();