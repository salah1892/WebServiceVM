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
    public class TariffAbonnementEntityTypeConfiguration : IEntityTypeConfiguration<TariffAbonnement>
    {
        public void Configure(EntityTypeBuilder<TariffAbonnement> builder)
        {
            builder.HasKey(e => e.IdTariffAbonnement);
            //builder.HasMany<Abonnement>().WithOne();
        }
    }
}
