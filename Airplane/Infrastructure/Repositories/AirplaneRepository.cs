using AirplaneCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirplaneCore.Infrastructure.Repositories
{
    public class AirplaneRepository:IRepository<Airplane>
    {
        private readonly Context _context;

        public IUnitOfWork UnitOfWork => _context;
       
        public AirplaneRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Airplane> GetAsync(int id)
        {
            return await _context.Airplane.FindAsync(id);
        }

        public async Task<IEnumerable<Airplane>> ListAsync()
        {
            return await _context.Airplane.ToListAsync();
        }

        public async Task<IEnumerable<Airplane>> ListAsync(Expression<Func<Airplane, bool>> predicate)
        {
            return await _context.Airplane.Where(predicate).ToListAsync();
        }

        public Airplane Add(Airplane entity)
        {
             return _context.Airplane.Add(entity).Entity;
        }

        public Airplane Update(Airplane entity)
        {
            return _context.Update(entity).Entity;
        }

        public void Delete(Airplane entity)
        {
            _context.Remove(entity);
        }

        
    }
}
