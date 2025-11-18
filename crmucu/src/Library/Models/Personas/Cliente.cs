using CrmUcu.Models.Enums;
using System;
using System.Collections.Generic;
using CrmUcu.Models.Interaccion;

namespace CrmUcu.Models.Personas
{
    public class Cliente : Persona
    {
        public List<Etiqueta> Etiquetas { get; set; }  
        public int IdVendedor { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public Genero? Genero { get; set; }
        public List<object> Interacciones { get; set; } 
        public List<Venta> Ventas { get; set; }
        public List<Cotizacion> Cotizaciones { get; set; }
        
        public Cliente() : base() 
        {
            Etiquetas = new List<Etiqueta>();
            Interacciones = new List<object>();
            Ventas = new List<Venta>();
            Cotizaciones = new List<Cotizacion>();
        }
        
        public Cliente(int id, string mail, string nombre, string apellido, string telefono, int idVendedor) 
            : base(id, mail, nombre, apellido, telefono)
        {
            IdVendedor = idVendedor;   
            Etiquetas = new List<Etiqueta>();
            Interacciones = new List<object>();
            Ventas = new List<Venta>();
            Cotizaciones = new List<Cotizacion>();
 
        }
        
        public string MostrarInfo()
        {
            return $"1. Nombre: {Nombre}\n" +
                   $"2. Apellido: {Apellido}\n" +
                   $"3. Mail: {Mail}\n" +
                   $"4. Teléfono: {Telefono}\n" +
                   $"5. Fecha de Nacimiento: {FechaNacimiento?.ToString("dd/MM/yyyy") ?? "No especificada"}\n" +
                   $"6. Género: {Genero?.ToString() ?? "No especificado"}";
        }
    }
}
