using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceVM.Core.Entity;

namespace WebServiceVM.Infrastructure.Persistence.Configurations
{
    public class WebClientEntityTypeConfiguration
    {
        public void Configure(EntityTypeBuilder<WebClient> builder)
        {
            builder.HasKey(e => e.IdWebClient);
            //builder.HasMany<Payement>().WithOne();

        }
    }
}
