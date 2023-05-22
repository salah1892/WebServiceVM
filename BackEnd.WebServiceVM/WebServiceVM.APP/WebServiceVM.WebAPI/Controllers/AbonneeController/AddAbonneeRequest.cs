using WebServiceVM.Core.Entity;

namespace WebServiceVM.WebAPI.Controllers.AbonneeController
{
    public class AddAbonneeRequest
    {
        public int NumCarte { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public  ICollection<Abonnement> Abonnement { get; set; }
    }
}
