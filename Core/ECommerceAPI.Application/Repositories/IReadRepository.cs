using ECommerceAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Repositories
{
    public interface IReadRepository<T>: IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool track = true);
        //IQueryable<T> GetAllAsync();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool track = true);
        Task<T> GetByIdAsync(string id, bool track = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool track = true);
    }
}
