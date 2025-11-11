// la idea es inicializar todo desde esta clase
//

namespace CrmUcu.Models.Personas
{
    public class Etiqueta
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Color { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public Etiqueta() { }

        public Etiqueta(string nombre, string? color = null, string? descripcion = null)
        {
            Nombre = nombre;
            Color = color;
            Descripcion = descripcion;
        }

        public override bool Equals(object? obj)
        {
            return obj is Etiqueta etiqueta && Id == etiqueta.Id;
        }


        public override string ToString()
        {
            return $"[{Nombre}] {Descripcion}";
        }
    }
}
