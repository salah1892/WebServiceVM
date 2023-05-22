using WebServiceVM.Core.Entity;

namespace WebServiceVM.WebAPI.Controllers.TariffAbonnementController
{
    public class AddTariffAbonnementRequest
    {
        public string TypeAbonnement { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public ICollection<Abonnement> ListAbonnements { get; set; }
        public ICollection<Parking> ListParkings { get; set; }
    }
}
