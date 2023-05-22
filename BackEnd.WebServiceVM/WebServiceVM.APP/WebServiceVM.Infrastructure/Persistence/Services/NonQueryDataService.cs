using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceVM.Infrastructure.Persistence.Services
{
    public class NonQueryDataService<T> where T : class
    {
        private readonly VMContextFactory _contextFactory;
        private readonly NonQueryDataService<T> _nonQueryDataService;

        public NonQueryDataService(VMContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using VMDbContext context = _contextFactory.CreateDbContext();
            EntityEntry<T> createResult = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return createResult.Entity;
        }

        public async Task<bool> Delete(T entity)
        {
            using VMDbContext context = _contextFactory.CreateDbContext();
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<T> Update(T entity)
        {
            using VMDbContext context = _contextFactory.CreateDbContext();
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
