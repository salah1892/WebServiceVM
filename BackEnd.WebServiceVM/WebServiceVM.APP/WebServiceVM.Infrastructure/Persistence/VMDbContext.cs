using Microsoft.EntityFrameworkCore;
using WebServiceVM.Core.Entity;
using WebServiceVM.Infrastructure.Persistence.Configurations;

namespace WebServiceVM.Infrastructure.Persistence
{
    public class VMDbContext : DbContext
    {
        public DbSet<Abonnee> Abonnee { get; set; }
        public DbSet<Abonnement> Abonnement { get; set; }
        public DbSet<Parking> Parking { get; set; }
        public DbSet<Payement> Payement { get; set; }
        public DbSet<TariffAbonnement> TariffAbonnement { get; set; }
        public DbSet<TariffTicket> TariffTicket { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<WebClient> WebClient { get; set; }
        public DbSet<Parametre> Parametre { get; set; }
        public VMDbContext()
        {
        }

        public VMDbContext(DbContextOptions options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { optionsBuilder.UseLazyLoadingProxies(); }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AbonneeEntityTypeConfiguration().Configure(modelBuilder.Entity<Abonnee>());
            new AbonnementEntityTypeConfiguration().Configure(modelBuilder.Entity<Abonnement>());
            new ParkingEntityTypeConfiguration().Configure(modelBuilder.Entity<Parking>());
            new PayementEntityTypeConfiguration().Configure(modelBuilder.Entity<Payement>());
            new TariffAbonnementEntityTypeConfiguration().Configure(modelBuilder.Entity<TariffAbonnement>());
            new TariffTicketEntityTypeConfiguration().Configure(modelBuilder.Entity<TariffTicket>());
            new TicketEntityTypeConfiguration().Configure(modelBuilder.Entity<Ticket>());
            new WebClientEntityTypeConfiguration().Configure(modelBuilder.Entity<WebClient>());
            new ParametreEntityTypeConfiguration().Configure(modelBuilder.Entity<Parametre>());

        }
    }
}
