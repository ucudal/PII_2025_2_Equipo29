using CrmUcu.Models.Enums;

namespace CrmUcu.Models.Personas
{
    public abstract class Usuario : Persona
    {
        public string NombreDeUsuario { get; set; } 
        public string Password { get; set; }
        public EstadoUsuario Estado { get; set; }

        protected Usuario() : base()
        {
            Estado = EstadoUsuario.Activo;
        }

        protected Usuario(int id, string nombre, string apellido, string mail, 
                         string telefono, string nombreUsuario, string password)
            : base(id, nombre, apellido, mail, telefono)
        {
            NombreDeUsuario = nombreUsuario;
            Password = password;
            Estado = EstadoUsuario.Activo;
        }

        
        public abstract bool Autenticar();

        public bool EstaActivo() => Estado == EstadoUsuario.Activo;

        public void Suspender() => Estado = EstadoUsuario.Suspendido;

        public void Activar() => Estado = EstadoUsuario.Activo;

        public void Eliminar() => Estado = EstadoUsuario.Eliminado;
    }
}
