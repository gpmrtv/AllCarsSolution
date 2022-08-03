using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AllCar.DataAccess.Context
{
    public class ReferencesContext : DbContext
    {
        public ReferencesContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), asm => asm.Namespace.ToLower() != "identity");
        }
    }
}
