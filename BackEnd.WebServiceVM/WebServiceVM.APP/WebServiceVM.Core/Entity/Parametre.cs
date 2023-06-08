using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceVM.Core.Entity
{
    public class Parametre
    {
        public Guid IdParametre { get; set; }
        public int TypePayement { get; set; }
        public string? DescriptionPayement { get; set; }
    }
}
