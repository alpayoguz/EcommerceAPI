using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ECommerceAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        ECommerceAPIDBContext _context;
        public ReadRepository( ECommerceAPIDBContext context ) {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();


        public IQueryable<T> GetAll(bool track = true)
        {
            if (track)
            {
                var query = Table.AsQueryable();
                return query;
            }
            else
            {
               var query = Table.AsNoTracking();
                return query;
            }
        }

        public async Task<T> GetByIdAsync(string id, bool track = true)
        {
            var query = Table.AsQueryable();

            if(!track) query = Table.AsNoTracking();

            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));   
        }

        public async Task<T>   GetSingleAsync(Expression<Func<T, bool>> method, bool track = true)
        {
            var query = Table.AsQueryable();
            if (!track) query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);

        }

        public  IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool track = true)
        {
            var query = Table.AsQueryable();
            if (!track) query = Table.AsNoTracking();
            return query.Where(method);

        }
    }
}
