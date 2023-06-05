using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Model;

namespace WPFSignalRClient.SignalRService
{
    public interface ISignalRPayementService
    {
        public event Action<Payement> PayementMsgReceived;
        public  Task SendPayementMsg(Payement payement);
    }
}
