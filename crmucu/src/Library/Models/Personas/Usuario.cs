using CrmUcu.Models.Enums;

namespace CrmUcu.Models.Personas
{
    public abstract class Usuario : Persona
    {
        public string NombreUsuario {get; set;} 
        public string Password {get; set;}
        public EstadoUsuario Estado {get; set;}

        protected Usuario() : base()
        {
            Estado = EstadoUsuario.Activo;
        }

        protected Usuario(int id, string nombre, string apellido, string mail, string telefono, string nombreUsuario, string password) : base(id, nombre, apellido, mail, telefono)
        {
            NombreUsuario = nombreUsuario;
            Password = password;
            Estado = EstadoUsuario.Activo;
        }

        public bool Autenticar(string nombreUsuario, string password)
        {
            return true;
        }
    }
}
