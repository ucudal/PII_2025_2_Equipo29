using CrmUcu.Models.Enums;
using CrmUcu.Repositorios;
namespace CrmUcu.Models.Personas
{
    public class Vendedor : Usuario
    {
        public List<int>? Clientes { get; set; } = new();


        public Vendedor() : base() { }

        public Vendedor(int id, string nombre, string apellido, string mail, string telefono, string nombreUsuario, string password ) : base(id, nombre, apellido, mail, telefono, nombreUsuario, password)
        {
        }

        //Vendedor usa la instancia singleton del repoClientes para que esta última se encargue de crear y agregar al repo al nuevo cliente. 
        public void CrearCliente(string nombre, string apellido, string mail, string telefono){
            
            var repo = RepositorioCliente.ObtenerInstancia();
            repo.CrearCliente(nombre, apellido, mail, telefono, this.Id);
        }

        public void ModificarCliente(int idCliente){

            var repo = RepositorioCliente.ObtenerInstancia();
            var cliente = repo.BuscarPorId(idCliente);
            
            //qué desea modificar el vendedor?
            
            cliente.MostrarInfo();
            Console.Write("Ingrese su opción: ");
    
            string opcion = Console.ReadLine();

            switch(opcion)
            {
                case "1":
                    Console.Write("Ingrese el nuevo nombre: ");
                    cliente.Nombre = Console.ReadLine();
                    break;
                    
                case "2":
                    Console.Write("Ingrese el nuevo apellido: ");
                    cliente.Apellido = Console.ReadLine();
                    break;
                    
                case "3":
                    Console.Write("Ingrese el nuevo mail: ");
                    cliente.Mail = Console.ReadLine();
                    break;
                    
                case "4":
                    Console.Write("Ingrese el nuevo teléfono: ");
                    cliente.Telefono = Console.ReadLine();
                    break;
                    
                case "5":
                    Console.Write("Ingrese la nueva fecha de nacimiento (dd/MM/yyyy): ");
                    string fechaInput = Console.ReadLine();
                    if (DateTime.TryParse(fechaInput, out DateTime fecha))
                    {
                        cliente.FechaNacimiento = fecha;
                    }
                    else
                    {
                        Console.WriteLine("Formato de fecha inválido");
                        return;
                    }
                    break;
            
                case "6":
                    Console.WriteLine("Seleccione el género:");
                    Console.WriteLine("1. Masculino");
                    Console.WriteLine("2. Femenino");
                    Console.WriteLine("3. Otro");
                    Console.Write("Opción: ");
                    string generoOpcion = Console.ReadLine();
                    
                    cliente.Genero = generoOpcion switch
                    {
                        "1" => Enums.Genero.Masculino,
                        "2" => Enums.Genero.Femenino,
                        "3" => Enums.Genero.Otro,
                        _ => cliente.Genero  // Mantiene el valor actual si es inválido
                    };
                    
                    if (generoOpcion != "1" && generoOpcion != "2" && generoOpcion != "3")
                    {
                        Console.WriteLine("Opción de género inválida");
                        return;
                    }
                    break;
                    
                default:
                    Console.WriteLine("Opción inválida");
                    return;
    }

                // Guardar cambios
                Console.WriteLine("Cliente modificado exitosamente");

        }


        //Eliminar un cliente 
        public string EliminarCliente(int id){
            var repoClientes = RepositorioCliente.ObtenerInstancia();
            var cliente = repoClientes.BuscarPorId(id);
            repoClientes.EliminarCliente(id);
            return "Cliente eliminado" + cliente.Nombre;
        }












    }
}
