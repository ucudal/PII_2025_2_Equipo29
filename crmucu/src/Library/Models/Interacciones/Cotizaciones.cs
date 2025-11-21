using CrmUcu.Models.Enums;
using CrmUcu.Models.Personas;

namespace CrmUcu.Models.Interacciones
{
    public class Cotizacion: Interaccion
    {
        public string Producto {get;set;} =string.Empty;
        public float Monto {get;set;}
        public EstadoCotizacion Estado {get;set;}= EstadoCotizacion.Pendiente;

        public Cotizacion()
        {
            Tipo = TipoInteraccion.Cotizacion;
        }

        public Cotizacion(string producto, float monto, string tema) : this() // this() reutiliza el constructor sin parametros para no tener que volver a repetir el tipo de interacción
        {
            Tema = tema;
            Monto = monto; 
            Producto = producto; 

        }

        public void Rechazar()
        {
            Estado = EstadoCotizacion.Rechazada;
        }

        public Venta ConvertirAVenta(){
            if(Estado == EstadoCotizacion.Rechazada)
            {
                Console.WriteLine("No se puede convertir a venta una cotización que fue rechazada...");

            }
            Estado = EstadoCotizacion.Aceptada;

            return Venta(this.Cliente, this.Vendedor, this.Producto, this.Monto, this.Tema);
        }

        private Venta Venta(Cliente cliente, Vendedor vendedor, string producto, float monto, string tema)
        {
            throw new NotImplementedException();
        }
    }

}
