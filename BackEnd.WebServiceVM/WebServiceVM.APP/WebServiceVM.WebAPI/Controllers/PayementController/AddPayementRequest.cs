using WebServiceVM.Core.Entity;

namespace WebServiceVM.WebAPI.Controllers.PayementController
{
    public class AddPayementRequest
    {
        public DateTime DatePayement { get; set; }
        public  Abonnement Abonnement { get; set; }
        public  Ticket Ticket { get; set; }
    }
}
