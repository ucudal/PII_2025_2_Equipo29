using CrmUcu.Models.Enums;
using CrmUcu.Models.Personas;

namespace CrmUcu.Models.Interacciones
{
    public class Reunion : Interaccion
    {
        public string Ubicacion{ get; set;}
        public int DuracionMinutos{ get; set;}
        public EstadoReunion Estado{ get; set;}
        public List<Persona> Participantes {get;set;}

        public Reunion()
        {
            Tipo = TipoInteraccion.Reunion;
            Estado = EstadoReunion.Agendada;
            Participantes = new List<Persona>();
        }

        public void AgregarParticipante(Persona persona)
        {
            if (persona != null && !Participantes.Contains(persona))
            {
                Participantes.Add(persona);
            }
        }

        public void MarcarComoCompletada()
        {
            if (Estado != EstadoReunion.Cancelada)
            {
                Estado = EstadoReunion.Realizada;
            }
        }

        public void Cancelar()
        {
            if (Estado != EstadoReunion.Realizada)
            {
                Estado = EstadoReunion.Cancelada;
            }
        }
    }
}