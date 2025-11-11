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

        public Venta(Cliente cliente, Usuario usuario, string producto, float monto, string tema = "Venta generada")
            : this()
        {
            Cliente = cliente;
            Usuario = usuario;
            Producto = producto;
            Monto = monto;
            Tema = tema;
        }

        public void ConfirmarVenta()
        {
            Confirmada = true;
            AgregarNota($"Venta confirmada por el Cliente llamado {Usuario.NombreCompleto}, el dia {DateTime.Now:dd/MM/yyyy}.", Usuario);
        }

        public void CancelarVenta()
        {
            Confirmada = false;
            AgregarNota($"Esta venta fue cancelada.", Usuario);
        }

        public override string ToString()
        {
            string estado = Confirmada ?  "Confirmado" : "Cancelado";
            return ($"{Fecha:dd/MM/yyyy} | {Producto} | {Monto:F2} | {estado} | Cliente {Cliente.NombreCompleto}");
        }
    }
}