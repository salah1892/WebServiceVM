using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceVM.Core.Entity
{
    public class Abonnement
    {
        public Guid IdAbonnement { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateActivation { get; set; }
        public DateTime DateDesActivation { get; set; }

        //public Guid IdAbonnee { get; set; }//ForeignKey
        public virtual Abonnee Abonnee { get; set; } //Reference Navigation Proprety
        public virtual TariffAbonnement TariffAbonnement { get; set; }
        public virtual ICollection<Payement> Payement { get; }
    }
}
