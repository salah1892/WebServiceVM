using Microsoft.AspNetCore.SignalR;
using WebServiceVM.Core.Entity;

namespace WebServiceVM.WebAPI.Hubs
{
    public class ParametreHub:Hub
    {
        public async Task SendParametreOperation(Parametre parametre)
        {
            var p = parametre.IdParametre;
            await Clients.All.SendAsync("ReceiveParametreMsg", parametre);
            Console.Write(" -- IdPayement :" + parametre.IdParametre +
                          "--TypePayement :" + parametre.TypePayement +
                          " -- DescriptionPayement :" + parametre.DescriptionPayement + "\n");
        }
    }
}
