using Microsoft.AspNetCore.SignalR;
using WebApp.Model;
using WebServiceVM.Core.Entity;

namespace WebVM.WebAPI.Hubs{

public class ParametreHub : Hub
{
    public async Task SendPayementOperation(Parametre parametre)
    {
        var p = parametre.IdParametre;
        await Clients.All.SendAsync("ReceiveParametreMsg", parametre);
        Console.Write(" -- IdPayement :" + parametre.IdParametre +
                      "--TypePayement :" + parametre.TypePayement +
                      " -- DescriptionPayement :" + parametre.DescriptionPayement + "\n");
    }
}}