
using CrmUcu.Models.Enums;
using CrmUcu.Repositories;

namespace CrmUcu.Models.Personas
{
    public class Admin : Usuario
    {
        public List<int>? usuariosCreados { get; set; } = new();

        public Admin() : base()
        {
        }

        public Admin(int id, string nombre, string apellido, string mail, string telefono, string nombreUsuario,
            string password) : base(id, nombre, apellido, mail, telefono, nombreUsuario, password)
        {

        }

    }
}
