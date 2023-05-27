using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceVM.Core.Entity
{
    public class WebClient
    {
        public Guid IdWebClient { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string?  Password { get; set; }
        public string? Email { get; set; }
        public int Mobile { get; set; }
        public string? Genre { get; set; }
    }
}
