using AirplaneCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirplaneCore.Infrastructure.Repositories
{
    interface IAirplaneRepository:IRepository<Airplane>
    {
        Task<Airplane> GetAsync(int id);
        Task<IEnumerable<Airplane>> ListAsync();
        Task<IEnumerable<Airplane>> ListAsync(Expression<Func<Airplane, bool>> predicate);
        Airplane Add(Airplane entity);
        Airplane Update(Airplane entity);
        void Delete(Airplane entity);
    }
}
