using Microsoft.AspNetCore.SignalR;
using WebApp.Model;
using System.Diagnostics;
using WebVM.WebAPI.Controllers;

namespace WebVM.WebAPI.Hubs
{
    public class PayementHub : Hub
    {
        //readonly PayementHubController payementHubController=new PayementHubController();
        readonly PayementHubController _payementHubController;
        public PayementHub(PayementHubController payementHubController)
        {
            _payementHubController = payementHubController;
        }
        public async Task SendPayementOperation(Payement payement)
        {
           
            var p = payement.IdPayement;
            await Clients.All.SendAsync("ReceivePayementMsg", payement);
            Console.Write("DatePayement :" + payement.DatePayement +
                          " -- IdPayement :" + payement.IdPayement +
                          " -- Montant :" + payement.Montant + "\n");
            await _payementHubController.ConnectToServer();
            await _payementHubController.SendPayementToServer(payement);
        }
        public async Task SendPayement(Payement payement)
        {
            var p = payement.IdPayement;
            await Clients.All.SendAsync("ReceivePayementMsg", payement);
            Console.Write("DatePayement :" + payement.DatePayement +
                          " -- IdPayement :" + payement.IdPayement +
                          " -- Montant :" + payement.Montant + "\n");
        }
    }
}