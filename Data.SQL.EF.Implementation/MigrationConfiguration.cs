using System.Data.Entity.Migrations;

namespace Data.SQL.EF.Implementation
{
    public class MigrationConfiguration : DbMigrationsConfiguration<DataContext>
    {
        public MigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }
    }
}