using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using MySql.EntityFrameworkCore.Extensions;

namespace WebServiceVM.Infrastructure.Persistence
{
    public class VMContextFactory : IDesignTimeDbContextFactory<VMDbContext>, IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddEntityFrameworkMySql();
            new EntityFrameworkRelationalDesignServicesBuilder(serviceCollection)
                .TryAddCoreServices();
        }

        public VMDbContext CreateDbContext(string[] args = null)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
            return new VMDbContext(new DbContextOptionsBuilder()
               // .UseLazyLoadingProxies()
                //.UseSqlServer("Server=.;Database=WebServiceVM_Db;Trusted_Connection=True;")
                .UseMySql("server=localhost;port=3306;user=root;password=root;database=WebServiceVM_Db;", serverVersion)
                .Options);

        }
    }
}
