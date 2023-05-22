using WebServiceVM.Core.Entity;

namespace WebServiceVM.WebAPI.Controllers.TicketController
{
    public class UpdateTicketRequest
    {
        public bool Statut { get; set; }
        public DateTime DateEntree { get; set; }
        public DateTime DateSortie { get; set; }
        public float PrixTicket { get; set; }
        public  TariffTicket TariffTicket { get; set; }
        public  ICollection<Payement>? Payement { get; set; }
    }
}
