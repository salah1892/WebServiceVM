using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceVM.Core.Entity
{
    public class Parking
    {
        public Guid IdParking { get; set; }
        public string NomParking { get; set; }
        public string TypeParking { get; set; }
        public string AdressParking { get; set; }
        public virtual ICollection<TariffAbonnement> ListTariffAbonnement { get; set; }
    }
}
