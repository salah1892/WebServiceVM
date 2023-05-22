using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceVM.Core.Entity;

namespace WebServiceVM.Core.ServicePersistance
{
    public interface ITicketCrudServices
    {
        Task<Ticket> AddTicket(bool status, DateTime dateEntree, DateTime dateSortie, float prixTicket);
        Task<bool> DeleteTicket(Guid id);
        Task<ICollection<Ticket>> ListTicket();
        Task<Ticket> SearchTicketByID(Guid id);
        Task<ICollection<Ticket>> SearchListTicketByID(Guid id);
        Task<Ticket> UpdateTicket(Guid id, bool status, DateTime dateEntree, DateTime dateSortie, float prixTicket);
    }
}
