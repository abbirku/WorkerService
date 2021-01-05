using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public interface IWorkerContext
    {
        DbSet<Logging> Loggings { get; set; }
    }

    public class WorkerContext : DbContext, IWorkerContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public WorkerContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            _connectionString = !string.IsNullOrEmpty(_connectionString) ? _connectionString : "Data Source=DODPC\\DOD20;Initial Catalog=LoggingDb;Integrated Security=True;";
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Logging>()
                .HasKey(e=>e.Id);
        }

        public DbSet<Logging> Loggings { get; set; }
    }
}
