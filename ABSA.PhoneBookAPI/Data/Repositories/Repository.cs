using Microsoft.EntityFrameworkCore;
using ABSA.PhoneBookAPI.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABSA.PhoneBookAPI.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly PhoneBookContext PhoneBookContext;
        public Repository(PhoneBookContext phoneBookContext)
        {
            PhoneBookContext = phoneBookContext; 
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            PhoneBookContext.Set<TEntity>().Add(entity);
            await PhoneBookContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await PhoneBookContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            PhoneBookContext.Set<TEntity>().Remove(entity);
            await PhoneBookContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(int id)
        {
            return await PhoneBookContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await PhoneBookContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            PhoneBookContext.Entry(entity).State = EntityState.Modified;
            await PhoneBookContext.SaveChangesAsync();
            return entity;
        }
    }
}