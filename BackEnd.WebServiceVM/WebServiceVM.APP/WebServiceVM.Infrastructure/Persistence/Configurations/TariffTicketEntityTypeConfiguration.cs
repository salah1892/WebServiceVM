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
    public class TariffTicketEntityTypeConfiguration : IEntityTypeConfiguration<TariffTicket>
    {
        public void Configure(EntityTypeBuilder<TariffTicket> builder)
        {
            builder.HasKey(e => e.IdTariffTicket);
            //builder.HasMany<Ticket>().WithOne();
        }
    }
}
