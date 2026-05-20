using Abc.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infra
{
    public class EfBaseRepo<TContext, TEntity>(TContext c) : IRepo<TEntity>
        where TContext : DbContext
        where TEntity : BaseEntity
    {
        protected readonly TContext db = c;

        public async Task<int> CountAsync() => await db.Set<TEntity>().CountAsync();
        
        public async Task<TEntity> CreateAsync(TEntity e) {
            await db.AddAsync(e);
            await db.SaveChangesAsync();
            return e;
        }

        public Task DeleteAsync(Guid id) => DeleteCoreAsync(id);

        public async Task<TEntity> GetAsync(Guid id) => await db.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        
        public async Task<IEnumerable<TEntity>> GetAsync() => await GetAllCoreAsync();
        
        public async Task<TEntity> UpdateAsync(TEntity e) {
            db.Update(e);
            await db.SaveChangesAsync();
            return e;
        }

        private async Task DeleteCoreAsync(Guid id) {
            var e = await GetAsync(id);
            if (e is null) return;
            db.Remove(e);
            await db.SaveChangesAsync();
        }

        private async Task<IEnumerable<TEntity>> GetAllCoreAsync() {
            var q = db.Set<TEntity>().Skip(0).Take(10).OrderBy(x => x.ValidFrom).AsNoTracking();
            return await q.ToListAsync();
        }
    }
}
