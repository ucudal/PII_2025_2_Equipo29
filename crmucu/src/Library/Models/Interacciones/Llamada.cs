using CrmUcu.Models.Enums;

namespace CrmUcu.Models.Interacciones
{
    public class Llamada : Interaccion
    {
        public bool EsEntrante { get; set; }
        public int DuracionSegundos { get; set; }
        public bool Contestada { get; set; }

        public Llamada()
        {
            Tipo = TipoInteraccion.Llamada;
        }

        public bool FueContestada()
        {
            return Contestada;
        }

        public void ProgramarDevolucion(DateTime fecha)
        {
            //inserte códiigoooou
        }
    }
}
