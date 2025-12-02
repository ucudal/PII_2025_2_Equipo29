using CrmUcu.Models.Personas;
using CrmUcu.Models.Enums;
using CrmUcu.Repositories;
using CrmUcu.Models.Interaccion;
using System;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;
using CrmUcu.Core;

namespace CrmUcu
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var bot = new Bot();
            await bot.StartAsync();
            await Task.Delay(-1);
        }
    }

    class Bot
    {
        private readonly DiscordSocketClient _client;
        private readonly Interfaz _interfaz;

        // Usuario logueado actualmente
        private Usuario? _usuarioLogueado = null;

        public Bot()
        {
            _client = new DiscordSocketClient();
            _client.Log += Log;
            _client.MessageReceived += MessageReceived;

            _interfaz = new Interfaz();
        }

        public async Task StartAsync()
        {
            string token = "";
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
        }

        private Task Log(LogMessage log)
        {
            Console.WriteLine(log);
            return Task.CompletedTask;
        }

        private async Task MessageReceived(SocketMessage arg)
        {
            if (arg.Author.IsBot)
                return;

            var partes = arg.Content.Split(' ');

            // Acá se entra
            if (partes[0] == "Kbr4" && partes[1] == "login")
            {
                if (partes.Length < 4)
                {
                    await arg.Channel.SendMessageAsync("Faltan datos. Usa: Kbr4 login <usuario> <contraseña>");
                    return;
                }

                string username = partes[2];
                string password = partes[3];
                var usuario = _interfaz.IniciarSesion(username, password);

                if (usuario != null)
                {
                    _usuarioLogueado = usuario;
                    string tipo = usuario is Admin ? "Admin" : "Vendedor";
                    await arg.Channel.SendMessageAsync($"Login exitoso como {tipo}: {usuario.Nombre} {usuario.Apellido}");
                }
                else
                {
                    await arg.Channel.SendMessageAsync("Credenciales inválidas.");
                }
            }

            // Acá se sale
            else if (partes[0] == "Kbr4" && partes[1] == "logout")
            {
                if (_usuarioLogueado != null)
                {
                    string nombre = _usuarioLogueado.Nombre;
                    _usuarioLogueado = null;
                    await arg.Channel.SendMessageAsync($"Sesión cerrada para {nombre}.");
                }
                else
                {
                    await arg.Channel.SendMessageAsync("No hay ninguna sesión activa.");
                }
            }

            // Acá es la clinica donde hacen bebés
            else if (partes[0] == "Kbr4" && partes[1] == "crearCliente" && partes.Length == 7)
            {
                if (!CheckLogin(arg)) return;

                string nombre = partes[2];
                string apellido = partes[3];
                string mail = partes[4];
                string telefono = partes[5];
                int idVendedor = int.Parse(partes[6]);

                bool creado = _interfaz.CrearClienteComoVendedor(idVendedor, nombre, apellido, mail, telefono);
                await arg.Channel.SendMessageAsync(creado
                    ? $"Cliente {nombre} {apellido} creado por {_usuarioLogueado.Nombre}."
                    : "Error al crear cliente.");
            }

            // Acá es cuando se les mezclan los bebés en las incubadoras y hay que buscarlos
            else if (partes[0] == "Kbr4" && partes[1] == "buscarCliente" && partes.Length == 3)
            {
                if (!CheckLogin(arg)) return;

                int idCliente = int.Parse(partes[2]);
                var cliente = _interfaz.BuscarClientePorId(idCliente);
                await arg.Channel.SendMessageAsync(cliente != null ? cliente.MostrarInfo() : "Cliente no encontrado.");
            }

            // Acá es donde hacen los experimentos geneticos para los supersoldados de la 3era Guerra mundial
            else if (partes[0] == "Kbr4" && partes[1] == "modificarCliente" && partes.Length == 4)
            {
                if (!CheckLogin(arg)) return;

                int idVendedor = int.Parse(partes[2]);
                int idCliente = int.Parse(partes[3]);
                bool modificado = _interfaz.ModificarClienteComoVendedor(idVendedor, idCliente);
                await arg.Channel.SendMessageAsync(modificado ? "Cliente modificado." : "Error al modificar cliente.");
            }

            // Acá lo lleva la Cigüeña otra vez
            else if (partes[0] == "Kbr4" && partes[1] == "eliminarCliente" && partes.Length == 3)
            {
                if (!CheckLogin(arg)) return;

                int idCliente = int.Parse(partes[2]);
                _interfaz.EliminarCliente(idCliente);
                await arg.Channel.SendMessageAsync("Cliente eliminado.");
            }

            // Acá es cuando tenés demasiados hijos
            else if (partes[0] == "Kbr4" && partes[1] == "listarClientes")
            {
                if (!CheckLogin(arg)) return;

                var clientes = _interfaz.ObtenerTodosLosClientes();
                string respuesta = clientes.Count > 0
                    ? string.Join("\n", clientes.Select(c => c.MostrarInfo()))
                    : "No hay clientes registrados.";
                await arg.Channel.SendMessageAsync(respuesta);
            }

            // Acá es cuando el abuelo castiga a Papá
            else if (partes[0] == "Kbr4" && partes[1] == "suspenderUsuario" && partes.Length == 3)
            {
                if (!CheckLogin(arg)) return;

                int idUsuario = int.Parse(partes[2]);
                bool suspendido = _interfaz.SuspenderUsuario(idUsuario);
                await arg.Channel.SendMessageAsync(suspendido ? "Usuario suspendido." : "Usuario no encontrado.");
            }

            // Acá es cuando el abuelo le pega un tiro a Papá
            else if (partes[0] == "Kbr4" && partes[1] == "eliminarUsuario" && partes.Length == 3)
            {
                if (!CheckLogin(arg)) return;

                int idUsuario = int.Parse(partes[2]);
                bool eliminado = _interfaz.EliminarUsuario(idUsuario);
                await arg.Channel.SendMessageAsync(eliminado ? "Usuario eliminado." : "Usuario no encontrado.");
            }

            // Acá es cuando el abuelo tenia muchos hijos y los quiere contar porque no se acuerda
            else if (partes[0] == "Kbr4" && partes[1] == "listarVendedores")
            {
                if (!CheckLogin(arg)) return;

                var vendedores = _interfaz.ObtenerTodosLosVendedores();
                string respuesta = vendedores.Count > 0
                    ? string.Join("\n", vendedores.Select(v => $"{v.Id} - {v.Nombre} {v.Apellido}"))
                    : "No hay vendedores registrados.";
                await arg.Channel.SendMessageAsync(respuesta);
            }

            // Acá es caundo el abuelo quiere ver a sus hermanos
            else if (partes[0] == "Kbr4" && partes[1] == "listarAdmins")
            {
                if (!CheckLogin(arg)) return;

                var admins = _interfaz.ObtenerTodosLosAdmins();
                string respuesta = admins.Count > 0
                    ? string.Join("\n", admins.Select(a => $"{a.Id} - {a.Nombre} {a.Apellido}"))
                    : "No hay admins registrados.";
                await arg.Channel.SendMessageAsync(respuesta);
            }
            // Acá se crean los apodos con los que el abuelo y la familia te van a decir toda la vida
            else if (partes[0] == "Kbr4" && partes[1] == "crearEtiqueta" && partes.Length == 3)
            {
                if (!CheckLogin(arg)) return;

                string nombreEtiqueta = partes[2];
                bool creada = _interfaz.CrearEtiqueta(nombreEtiqueta);

                await arg.Channel.SendMessageAsync(creada
                    ? $"Etiqueta '{nombreEtiqueta}' creada por {_usuarioLogueado.Nombre}."
                    : "Error al crear etiqueta.");
            }
            
            // Acá se muestran los apodos con los que el abuelo y la familia te van a decir toda la vida
            else if (partes[0] == "Kbr4" && partes[1] == "listarEtiquetas")
            {
                if (!CheckLogin(arg)) return;

                var etiquetas = _interfaz.ObtenerTodasLasEtiquetas();
                string respuesta = etiquetas.Count > 0
                    ? string.Join("\n", etiquetas.Select(e => $"{e.Id} - {e.Nombre}"))
                    : "No hay etiquetas registradas.";
                await arg.Channel.SendMessageAsync(respuesta);
            }
        }
        // Acá es para saber si sos de la familia
        private bool CheckLogin(SocketMessage arg)
        {
            if (_usuarioLogueado == null)
            {
                arg.Channel.SendMessageAsync("Debes iniciar sesión para usar este comando. Usa: Kbr4 login <usuario> <contraseña>");
                return false;
            }
            return true;
        }
    }
}
