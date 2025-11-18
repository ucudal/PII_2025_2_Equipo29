using CrmUcu.Models.Enums;

namespace CrmUcu.Models.Interacciones
{
    public class Llamada : Interaccion
    {
        public int DuracionSegundos { get; set; }
        public bool EsEntrante { get; set; }
        public bool Contestada { get; set; }    // en el UML figura como el fueAtendida(
                                                    // estaria faltando el duracion
        public string? Notas { get; set; } //Notas agregadas el "? " significa que para el usuario no es obligatoria la nota

        public Llamada()
        {
            Tipo = TipoInteraccion.Llamada;
        }

        public void MarcarComoAtendida()
        {
            Contestada = true;
        }
    }
}

