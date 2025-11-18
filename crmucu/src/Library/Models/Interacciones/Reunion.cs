using CrmUcu.Models.Enums;
using CrmUcu.Models.Personas;

namespace CrmUcu.Models.Interaccion
{
    public class Reunion : Interaccion
    {
        public string Ubicacion{ get; set;}
        public int DuracionMinutos{ get; set;}
        public EstadoReunion Estado{ get; set;}
        public List<Persona> Participantes {get;set;}



         public Reunion(int id, int idCliente, DateTime fecha, string descripcion) : base (id, idCliente, fecha, descripcion)
        {
            Tipo = TipoInteraccion.Reunion;
            Estado = EstadoReunion.Agendada;
            Participantes = new List<Persona>();
        }


        public Reunion(int id, int idCliente, DateTime fecha, string descripcion, string ubicacion, int duracion) : base (id, idCliente, fecha, descripcion)

        {
            Tipo = TipoInteraccion.Reunion;
            Estado = EstadoReunion.Agendada;
            Participantes = new List<Persona>();
            Ubicacion = ubicacion; 
            DuracionMinutos = duracion; 
        }

        public void AgregarParticipante(Persona persona) // Aca solo agrega si la persona existe y no esta agregada ya. pd: pueden sacarlo si quieren
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
