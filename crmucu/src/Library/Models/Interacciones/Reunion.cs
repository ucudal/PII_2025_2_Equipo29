using CrmUcu.Models.Enums;
using CrmUcu.Models.Personas;

namespace CrmUcu.Models.Interacciones
{
    public class Reunion : Interaccion
    {
        public string Ubicacion { get; set; } 
        public int DuracionMinutos { get; set; }
        public List<Persona> Participantes { get; set; }
        public EstadoReunion Estado { get; set; }

        public Reunion()
        {
            Tipo = TipoInteraccion.Reunion;
            Estado = EstadoReunion.Agendada;
        }

        public void AgregarParticipante(Persona persona)
        {
            if (!Participantes.Contains(persona))
            {
                Participantes.Add(persona);
            }
        }

        public void MarcarComoCompletada()
        {
            Estado = EstadoReunion.Realizada;
        }


        public void Cancelar()
        {
            Estado = EstadoReunion.Cancelada;
        }

    }
}
