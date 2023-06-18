using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;
using WebApp.Model;

namespace WebVM.WebAPI.Controllers
{
    public class PayementHubController : Controller
    {
        private HubConnection _hubConnection;

        public PayementHubController()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7036/PayementOperation")
                .Build();
            _hubConnection.On<Payement>("ReceivePayementMsg", payement =>
            {
                // Traitez le message reçu du serveur
                Console.WriteLine("-- IdPayement :" + payement.IdPayement +
                                  "--DatePayement :" + payement.DatePayement +
                                  "-- Montant :" + payement.Montant + "\n");
            });
        }

        public async Task ConnectToServer()
        {
            await _hubConnection.StartAsync();
        }

        public async Task SendPayementToServer(Payement payement)
        {
            await _hubConnection.InvokeAsync("SendPayementOperation", payement);
            Console.WriteLine("Dans F°'SendPayementToServer':\n-- IdPayement :" + payement.IdPayement +
                              "DatePayement :" + payement.DatePayement +
                              " -- Montant :" + payement.Montant + "\n");
        }
    }
}
