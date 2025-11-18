using CrmUcu.Models.Enums;

namespace CrmUcu.Models.Interacciones
{
    public class Llamada : Interaccion // los dos puntos quieren decir que hereda
    {
        public bool EsEntrante { get; set; } //true si el cliente llamó al vendedor, false si el vendedor llamó al cliente
        public int DuracionSegundos { get; set; }
        public bool Contestada { get; set; } //true si fue atendida  false si quedó no atendida

        public Llamada() //Metodo
        {
            Tipo = TipoInteraccion.Llamada;
        }

        public bool FueContestada() //Metodo
        {
            return Contestada;
        }

        public void ProgramarDevolucion(DateTime fecha)
        {
            if (fecha <= DateTime.Now) // esto se fija que la fecha sea a futuro 
            {
                throw new ArgumentException("La fecha de devolución debe ser futura");
            }
    
            // Validar que solo se pueda programar si la llamada NO fue contestada
            if (Contestada)
            {
                throw new InvalidOperationException("No se puede programar devolución para llamadas contestadas");
            }
    
            // Crear una nueva llamada programada (devolución)
            // Opción 1: Si tienes una propiedad para almacenar la fecha de seguimiento
            // FechaSeguimiento = fecha;
    
            // Opción 2: Crear una nueva interacción de seguimiento
            // Esto dependería de cómo tu sistema maneje las tareas/recordatorios
    
            // Opción 3: Registrar en una descripción o nota
            Descripcion = $"Devolución de llamada programada para {fecha:dd/MM/yyyy HH:mm}";
    
            // Opcional: Cambiar el estado de la interacción
            // Estado = EstadoInteraccion.PendienteSeguimiento;
        }
    }
}
