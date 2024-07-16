using Carpool.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Carpool.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
    }
}
