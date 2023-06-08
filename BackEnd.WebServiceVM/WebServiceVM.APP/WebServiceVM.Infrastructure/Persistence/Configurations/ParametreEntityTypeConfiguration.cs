using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceVM.Core.Entity;

namespace WebServiceVM.Infrastructure.Persistence.Configurations
{
    public class ParametreEntityTypeConfiguration
    {
        public void Configure(EntityTypeBuilder<Parametre> builder)
        {
            builder.HasKey(e => e.IdParametre);
            // builder.HasMany<Abonnement>().WithOne();

        }
    }
}
