using CrmUcu.Models.Personas;
using CrmUcu.Models.Enums;
using CrmUcu.Repositories;
using CrmUcu.Models.Interaccion;
using System;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace CrmUcu
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class ProgramBotDiscord
    {
        private static async Task Main(string[] args)
        {
            var bot = new Bot();
            await bot.StartAsync();
            await Task.Delay(-1);
        }
    }
// iniciamos el codigo y la aplicación del bot
    class Bot
    {
        private readonly DiscordSocketClient _client;

        public Bot()
        {
            _client = new DiscordSocketClient();
            _client.Log += Log;
            _client.MessageReceived += MessageReceived;
        }
        //Token del Bot.
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
        // mensajes especificos que hacen reaccionar al bot para que utilizar las funciones del programa.
        private async Task MessageReceived(SocketMessage arg)
        {
            // TODO EN CAMMEL CASE 
            if (arg.Author.IsBot)
                return;
            if (arg.Content == "Kbr4 crearCliente")
            {
                await arg.Channel.SendMessageAsync("Pong!");
            }

            if (arg.Content == "Kbr4 help")
            {
                await arg.Channel.SendMessageAsync("");// proximamente mostrar todos los comandos
            }
            
            else if (arg.Content == "Kbr4")
            {
                await arg.Channel.SendMessageAsync("");
            }
            
            else if (arg.Content == "Kbr4 hola")
            {
                await arg.Channel.SendMessageAsync("¡Hola, soy tu bot!");
            }
        }
    }
}