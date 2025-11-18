using CrmUcu.Models.Enums;

namespace CrmUcu.Models.Interaccion
{
    public class Llamada : Interaccion
    {
        public bool EsEntrante { get; set; }
        public int DuracionSegundos { get; set; }
        public bool Contestada { get; set; }

        public Llamada(int id, int idCliente, DateTime fecha, string descripcion ): base(id, idCliente, fecha, descripcion)
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
