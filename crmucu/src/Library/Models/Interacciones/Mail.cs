using CrmUcu.Models.Enums;

namespace CrmUcu.Models.Interacciones
{
    public class Mail : Interaccion
    {
        public bool EsEntrante { get; set; }
        public string Asunto { get; set; } 
        public List<string> Destinatarios { get; set; } = new();
        public bool Leido { get; set; }

        public Mail()
        {
            Tipo = TipoInteraccion.CorreoElectronico;
            Leido = false;
        }

        public void MarcarComoLeido()
        {
            Leido = true;
        }


    }
}
