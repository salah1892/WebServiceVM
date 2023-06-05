using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using WebApp.Model;
using WPFSignalRClient.HubSevice;

namespace WPFSignalRClient.SignalRService
{
    public class SignalRPayementService : ISignalRPayementService
    {
        private readonly HubConnection _connection;
        //public readonly HubCon hubCon;
        public event Action<Payement> PayementMsgReceived;
        public SignalRPayementService(HubConnection connection)
        {
            _connection = connection;
            //this.Connect();
            _connection.On<Payement>("ReceivePayementMsg", (payement) => PayementMsgReceived?.Invoke(payement));
        }
        public async Task Connect()
        {
            await _connection.StartAsync();
        }
        public async Task SendPayementMsg(Payement payement)
        {
            //"SendPayementOperation" is the F° in the Hub server  need to be the same signature
            //and the parametre passed need to match the same parametre in the fonction from server side
            await _connection.SendAsync("SendPayementOperation", payement);
        }
    }
}
