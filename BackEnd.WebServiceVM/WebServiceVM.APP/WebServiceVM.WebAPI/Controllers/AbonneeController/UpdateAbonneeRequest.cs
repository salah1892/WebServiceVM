using WebServiceVM.Core.Entity;

namespace WebServiceVM.WebAPI.Controllers.AbonneeController
{
    public class UpdateAbonneeRequest
    {
        public int NumCarte { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public ICollection<Abonnement> Abonnement { get; set; }
    }
}
