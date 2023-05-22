using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceVM.Core.Entity;

namespace WebServiceVM.Core.ServicePersistance
{
    public interface IWebClientCrudServices
    {
        Task<WebClient> AddWebClient(string FirstName, string LastName, string Password, string Email, int Mobile);
        Task<bool> DeleteTicket(Guid id);
        Task<ICollection<WebClient>> ListWebClient();
        Task<WebClient> SearchWebClientByID(Guid id);
        Task<ICollection<WebClient>> SearchListWebClientByID(Guid id);
        Task<WebClient> UpdateWebClient(Guid id, string FirstName,string LastName, string Password, string Email, int Mobile);
    }
}
