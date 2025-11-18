using System;
using CrmUcu.Models.Enums;
using CrmUcu.Models.Personas;

namespace CrmUcu.Models.Interacciones
{
    public class Venta : Interaccion
    {
        public string Producto { get; set; } = string.Empty;
        public float Monto { get; set; }
        public string? MetodoPago { get; set; } 
        public bool Confirmada { get; private set; }

        public Venta() : base()
        {
            Tipo = TipoInteraccion.Venta;
        }

        public Venta(Cliente cliente, Vendedor Vendedor, string producto, float monto, string tema = "Venta generada")
            : this()
        {
            Cliente = cliente;
            Vendedor = Vendedor;
            Producto = producto;
            Monto = monto;
            Tema = tema;
        }

        public void ConfirmarVenta()
        {
            Confirmada = true;
            AgregarNota($"Venta confirmada por el Cliente llamado {Cliente.NombreCompleto}, el dia {DateTime.Now:dd/MM/yyyy}.", Vendedor);
        }

        public void CancelarVenta()
        {
            Confirmada = false;
            AgregarNota($"Esta venta fue cancelada.", Vendedor);
        }

        public override string ToString()
        {
            string estado = Confirmada ?  "Confirmado" : "Cancelado";
            return ($"{Fecha:dd/MM/yyyy} | {Producto} | {Monto} | {estado} | Cliente {Cliente.NombreCompleto}");
        }
    }
}