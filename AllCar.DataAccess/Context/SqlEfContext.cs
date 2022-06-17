using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AllCar.DataAccess.Context
{
    public class SqlEfContext : DbContext
    {
        public SqlEfContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
