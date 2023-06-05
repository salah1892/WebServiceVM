using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceVM.Core.Entity
{
    public class TariffAbonnement
    {
        public Guid IdTariffAbonnement { get; set; }
        public string? TypeAbonnement { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public virtual ICollection<Abonnement> ListAbonnements { get; set; }
        public virtual ICollection<Parking> ListParkings { get; set; }
    }
}
