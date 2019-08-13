using System.Threading;
using System.Threading.Tasks;
using AirplaneCore.Infrastructure.EntityConfigurations;
using AirplaneCore.Infrastructure.Repositories;
using AirplaneCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AirplaneCore.Infrastructure
{
    public class Context:DbContext, IUnitOfWork
    {
        public Context(DbContextOptions<Context> options):base(options){
        }

        public DbSet<Airplane> Airplane { get; set; }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await base.SaveChangesAsync();
            return true;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AirplaneEntityTypeConfiguration());
        }

    }
}
