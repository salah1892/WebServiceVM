using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceVM.Core.Entity
{
    public class Payement
    {
        public Guid IdPayement { get; set; }
        public DateTime DatePayement { get; set; }
        public virtual Abonnement Abonnement { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
