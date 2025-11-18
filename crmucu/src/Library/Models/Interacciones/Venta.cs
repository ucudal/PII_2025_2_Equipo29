using System;
using CrmUcu.Models.Interaccion;

namespace CrmUcu.Models.Interaccion
{
    public class Venta : Interaccion
    {
        public string Producto { get; set; }
        public decimal Monto { get; set; }
        
        public Venta() : base() { }
        
        public Venta(int id, int idCliente, DateTime fecha, string descripcion, string producto, decimal monto) 
            : base(id, idCliente, fecha, descripcion)
        {
            Producto = producto;
            Monto = monto;
        }
        
    }
}
