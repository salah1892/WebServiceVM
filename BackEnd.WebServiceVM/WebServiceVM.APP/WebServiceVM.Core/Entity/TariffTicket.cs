using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceVM.Core.Entity
{
    public class TariffTicket
    {
        public Guid IdTariffTicket { get; set; }
        public DateTime DateEntree { get; set; }
        public DateTime DateSortie { get; set; }
        public virtual ICollection<Ticket> ListTicket { get; set; }
    }
}
