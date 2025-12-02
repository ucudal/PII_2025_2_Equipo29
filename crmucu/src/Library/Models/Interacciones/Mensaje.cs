using CrmUcu.Models.Enums;


namespace CrmUcu.Models.Interaccion
{
    public class Mensaje: Interaccion
    {
        public bool EsEntrante { get; set; }
        public string Asunto { get; set; } 
        public List<string> Destinatarios { get; set; } = new();
        public bool Leido { get; set; }

        public Mensaje(int id, int idCliente, DateTime fecha, string descripcion) : base (id, idCliente, fecha, descripcion)
        {
            Tipo = TipoInteraccion.Mensaje;
            Leido = false;
        }

        public void MarcRepositorioVendedor{
            Leido = true;
        }
    }
}
