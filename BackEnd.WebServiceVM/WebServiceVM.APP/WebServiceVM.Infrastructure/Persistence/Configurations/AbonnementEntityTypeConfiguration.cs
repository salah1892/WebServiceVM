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
    public class AbonnementEntityTypeConfiguration : IEntityTypeConfiguration<Abonnement>
    {
        public void Configure(EntityTypeBuilder<Abonnement> builder)
        {
            builder.HasKey(e => e.IdAbonnement);
            //builder.HasMany<Payement>().WithOne();
            //builder.HasOne<Abonnee>().WithMany();
            //builder.HasOne<TariffAbonnement>().WithMany();
        }
    }
}
