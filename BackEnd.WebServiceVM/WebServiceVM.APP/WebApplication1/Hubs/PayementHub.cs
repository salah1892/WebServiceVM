using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using VM.WS.Model;

namespace VM.WS.Hubs
{
    public class PayementHub:Hub
    {
        public async Task SendPayementOperation(Payement payement)
        {

        }
    }
}
