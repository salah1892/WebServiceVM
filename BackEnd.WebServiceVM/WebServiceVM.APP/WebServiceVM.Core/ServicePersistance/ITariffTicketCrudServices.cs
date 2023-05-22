using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceVM.Core.Entity;

namespace WebServiceVM.Core.ServicePersistance
{
    public interface ITariffTicketCrudServices
    {
        Task<TariffTicket> AddTariffTicket(DateTime dateEntree, DateTime dateSortie);
        Task<bool> DeleteTariffTicket(Guid id);
        Task<TariffTicket> SearchTariffTicketById(Guid id);
        Task<ICollection<TariffTicket>> ListTariffTicket();
        Task<ICollection<TariffTicket>> SearchListListTariffTicketById(Guid id);
        Task<TariffTicket> UpdateTariffTicket(Guid id, DateTime dateEntree, DateTime dateSortie);
    }
}
