using WebServiceVM.Core.Entity;

namespace WebServiceVM.WebAPI.Controllers.TariffTicketController
{
    public class AddTariffTicketRequest
    {
        public DateTime DateEntree { get; set; }
        public DateTime DateSortie { get; set; }
        public  ICollection<Ticket>? ListTicket { get; set; }
    }
}
