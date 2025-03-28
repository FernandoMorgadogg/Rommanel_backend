using Microsoft.EntityFrameworkCore;
using Rommanel.API.Models.Entity;

namespace Rommanel.API.Repositorys
{
    public class RommanelContext: DbContext
    {
        public RommanelContext(DbContextOptions<RommanelContext> options) : base(options)
        {
        }

        public DbSet<ClientEntity> Clients { get; set; }
    }
}
