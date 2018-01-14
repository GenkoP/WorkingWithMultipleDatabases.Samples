using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Data.Models;

namespace Data.SQL.EF.Implementation
{
    public class DataContext : DbContext
    {
        public DataContext(string connectionStringName)
           : base(connectionStringName)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, MigrationConfiguration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Promotion>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
