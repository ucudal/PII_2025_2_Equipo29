
using CrmUcu.Models.Enums;
using CrmUcu.Models.Personas;

namespace CrmUcu.Models.Interacciones
{
    public abstract class Interaccion
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Tema { get; set; }
        public List<Nota> Notas { get; set;}
        public TipoInteraccion Tipo { get;set; }
        public Cliente Cliente { get; set; } = null!;
        public Vendedor Vendedor { get; set; } = null!;

        public Interaccion()
        {
            Fecha = DateTime.Now;
        }

        public void AgregarNota(string contenido, Usuario autor)
        {
            var nota = new Nota
            {
                Contenido = contenido,
                Autor = autor,
                FechaCreacion = DateTime.Now
            };
            Notas.Add(nota);
        }

        public void EliminarNota(Nota nota)
        {
            Notas.Remove(nota);
        }

        public string ObtenerResumen()
        {
            return $"{Tipo} - {Fecha:dd/MM/yyyy} - {Tema} - Cliente: {Cliente.NombreCompleto}";
        }
    }



