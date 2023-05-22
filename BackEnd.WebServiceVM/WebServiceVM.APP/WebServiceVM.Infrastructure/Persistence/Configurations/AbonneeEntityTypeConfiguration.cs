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
    public class AbonneeEntityTypeConfiguration : IEntityTypeConfiguration<Abonnee>
    {
        public void Configure(EntityTypeBuilder<Abonnee> builder)
        {
            builder.HasKey(e => e.IdAbonnee);
            // builder.HasMany<Abonnement>().WithOne();

        }
    }
}
