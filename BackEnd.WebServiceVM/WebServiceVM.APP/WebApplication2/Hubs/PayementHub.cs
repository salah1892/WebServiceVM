using Microsoft.AspNetCore.SignalR;
using WebApp.Model;

namespace WebApplication2.Hubs
{
    public class PayementHub : Hub
    {
        public async Task SendPayementOperation(Payement payement)
        {
            var p = payement.IdPayement;
            await Clients.All.SendAsync("ReceivePayementMsg", payement);
            Console.Write("DatePayement :" + payement.DatePayement +
                          " -- IdPayement :" + payement.IdPayement +
                          " -- Montant :" + payement.Montant + "\n");
        }
    }
}