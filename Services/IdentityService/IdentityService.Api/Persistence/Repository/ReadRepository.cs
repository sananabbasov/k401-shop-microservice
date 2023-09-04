using System;
using System.Linq.Expressions;
using IdentityService.Api.Application.Repository;
using IdentityService.Api.Data;
using IdentityService.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Api.Persistence.Repository
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public ReadRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            return Table.AsQueryable();
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var res = Table.AsQueryable();
            if (!tracking)
            {
                res = Table.AsNoTracking();
            }
            return await res.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));

        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            return await Table.SingleOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            return Table.Where(method);
        }
    }
}

