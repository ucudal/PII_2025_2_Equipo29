namespace CrmUcu.Models.Utils
{
    public class Nota
    {
        public int Id {get;set; }
        private string Texto { get; set; } = string.Empty;
        private Datetime Fecha {get;set;} = DateTime.Now;
    }

    public Nota(){
        //Definimos un constructor vacío pq puede darse el caso de que al crear una interacción, necesitemos crear una nota vacía 
    }
    
    public Nota(int id, string texto){
        Id = id;
        Texto = texto;
        Fecha = DateTime.Now;
    }
    
}

