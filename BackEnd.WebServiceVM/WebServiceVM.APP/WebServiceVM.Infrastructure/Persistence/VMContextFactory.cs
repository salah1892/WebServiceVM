using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySql.EntityFrameworkCore.Extensions;

namespace WebServiceVM.Infrastructure.Persistence
{
    public class VMContextFactory : IDesignTimeDbContextFactory<VMDbContext>, IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddEntityFrameworkMySQL();
            new EntityFrameworkRelationalDesignServicesBuilder(serviceCollection)
                .TryAddCoreServices();
        }

        public VMDbContext CreateDbContext(string[] args = null)
        {
            return new VMDbContext(new DbContextOptionsBuilder()
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=.;Database=WebServiceVM_Db;Trusted_Connection=True;")
                //.UseMySQL("server=localhost;port=3306;user=root;password=root;database=WebServiceVM_Db;")
                .Options);

        }
    }
}
