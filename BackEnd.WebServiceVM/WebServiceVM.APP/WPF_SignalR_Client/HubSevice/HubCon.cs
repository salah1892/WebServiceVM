using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WPFSignalRClient.HubSevice
{
    public class HubCon :  IHubCon
    {
        public HubCon(HubConnection hubConnection)
        {
            
        }
        //public HubCon(IConnectionFactory connectionFactory, IHubProtocol protocol, EndPoint endPoint, IServiceProvider serviceProvider, ILoggerFactory loggerFactory) : base(connectionFactory, protocol, endPoint, serviceProvider, loggerFactory)
        //{
        //}
    }
}
