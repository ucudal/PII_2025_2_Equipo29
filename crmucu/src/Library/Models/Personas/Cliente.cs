using CrmUcu.Models.Enums;

namespace CrmUcu.Models.Personas
{
    public class Cliente : Persona
    {
        public List<Etiqueta> Etiquetas { get; set; }  
        public Vendedor? Vendedor { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public Genero? Genero { get; set; }
        //como tuvimos varios dramas con dependencias circulares, pusimos object para que no saltara error.       
        public List<object> Interacciones { get; set; } 
        public List<object> Ventas { get; set; }
        public List<object> Cotizaciones { get; set; }

        public Cliente() : base() { }

        public Cliente(int id, string nombre, string apellido, string mail, string telefono)
            : base(id, nombre, apellido, mail, telefono)
        {
        }

        public int Edad
        {
            get
            {
                if (!FechaNacimiento.HasValue) return 0;
                var hoy = DateTime.Today;
                var edad = hoy.Year - FechaNacimiento.Value.Year;
                if (FechaNacimiento.Value.Date > hoy.AddYears(-edad)) edad--;
                return edad;
            }
        }

        public bool EsCumpleAnios() 
        {
            if (!FechaNacimiento.HasValue) return false;
            var hoy = DateTime.Today;
            return FechaNacimiento.Value.Month == hoy.Month &&
                   FechaNacimiento.Value.Day == hoy.Day;
        }

        public void AgregarEtiqueta(Etiqueta etiqueta)
        {
            if (!Etiquetas.Contains(etiqueta))
            {
                Etiquetas.Add(etiqueta);
            }
        }

        public void RemoverEtiqueta(Etiqueta etiqueta)
        {
            Etiquetas.Remove(etiqueta);
        }

        public bool TieneEtiqueta(string nombreEtiqueta)
        {
            return Etiquetas.Any(e => e.Nombre.Equals(nombreEtiqueta, StringComparison.OrdinalIgnoreCase));
        }

    }
}
