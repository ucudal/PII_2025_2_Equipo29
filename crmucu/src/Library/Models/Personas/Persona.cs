namespace CrmUcu.Models.Personas
{
public abstract class Persona
{
    public int Id { get; set; }
    public string Mail { get; set; } 
    public string Nombre { get; set; } 
    public string Apellido { get; set; } 
    public string Telefono { get; set; } 


    protected Persona() { }

    protected Persona(int id, string nombre, string apellido, string mail, string telefono)
    {
        Id = id;
        Nombre = nombre;
        Apellido = apellido;
        Mail = mail;
        Telefono = telefono;
        }
    }
}
