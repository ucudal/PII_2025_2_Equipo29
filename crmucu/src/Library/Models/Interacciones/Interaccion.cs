using System;
using CrmUcu.Models.Enums;
namespace CrmUcu.Models.Interaccion
{
    public abstract class Interaccion
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public TipoInteraccion Tipo {get; set;}
        
        protected Interaccion() { }
        
        protected Interaccion(int id, int idCliente, DateTime fecha, string descripcion)
        {
            Id = id;
            IdCliente = idCliente;
            Fecha = fecha;
            Descripcion = descripcion;
        }
        
    }
}
