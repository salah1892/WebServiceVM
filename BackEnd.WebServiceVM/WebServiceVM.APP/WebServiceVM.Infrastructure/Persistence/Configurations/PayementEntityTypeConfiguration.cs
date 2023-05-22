using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceVM.Core.Entity;

namespace WebServiceVM.Infrastructure.Persistence.Configurations
{
    public class PayementEntityTypeConfiguration : IEntityTypeConfiguration<Payement>
    {
        public void Configure(EntityTypeBuilder<Payement> builder)
        {
            builder.HasKey(e => e.IdPayement);
            //builder.HasOne(a=>a.Abonnement).WithMany();
            //builder.HasOne(a=>a.Ticket).WithMany();
        }
    }
}
