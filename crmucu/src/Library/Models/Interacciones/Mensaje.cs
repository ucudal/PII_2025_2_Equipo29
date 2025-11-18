using CrmUcu.Models.Enums;

namespace CrmUcu.Models.Interacciones
{
    public class Mensaje : Interaccion 
    {
        public string Plataforma { get; set; }
        public bool EsEntrante { get; set; }
        public bool Leido { get; set; }

        public Mensaje()
        {
            Tipo = TipoInteraccion.Mensaje;
            Leido = false;
        }

        public void MarcarLeido()
        {
            Leido = true;
        }
    }
}