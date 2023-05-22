using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceVM.Core.Entity
{
    public class Abonnee
    {
        public Guid IdAbonnee { get; set; }
        public int NumCarte { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        // [ForeignKey("Abonnement")]
        // public Guid IdAbonnement { get; set; }

        public virtual ICollection<Abonnement> Abonnement { get; set; }
    }
}
