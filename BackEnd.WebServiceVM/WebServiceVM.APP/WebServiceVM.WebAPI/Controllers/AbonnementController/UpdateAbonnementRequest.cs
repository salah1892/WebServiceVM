using WebServiceVM.Core.Entity;

namespace WebServiceVM.WebAPI.Controllers.AbonnementController
{
    public class UpdateAbonnementRequest
    {
        public DateTime DateCreation { get; set; }
        public DateTime DateActivation { get; set; }
        public DateTime DateDesActivation { get; set; }
        public  Abonnee Abonnee { get; set; } 
        public  TariffAbonnement TariffAbonnement { get; set; }
        public  ICollection<Payement> Payement { get; }
    }
}
