using CrmUcu.Models.Enums;


namespace CrmUcu.Models.Interaccion
{
    public class Mail : Interaccion
    {
        public bool EsEntrante { get; set; }
        public string Asunto { get; set; } 
        public List<string> Destinatarios { get; set; } = new();
        public bool Leido { get; set; }

        public Mail(int id, int idCliente, DateTime fecha, string descripcion) : base (id, idCliente, fecha, descripcion)
        {
            Tipo = TipoInteraccion.Mail;
            Leido = false;
        }

        public void MarcarComoLeido()
        {
            Leido = true;
        }


    }
}
