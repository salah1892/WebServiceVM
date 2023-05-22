using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceVM.Core.Entity
{
    public class Ticket
    {
        public Guid IdTicket { get; set; }
        public bool Statut { get; set; }
        public DateTime DateEntree { get; set; }
        public DateTime DateSortie { get; set; }
        public float PrixTicket { get; set; }
        public virtual TariffTicket TariffTicket { get; set; }
        public virtual ICollection<Payement> Payement { get; }
    }
}
