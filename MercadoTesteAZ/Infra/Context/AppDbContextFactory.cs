using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MercadoTesteAZ.Infra.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            //  substitua pela sua connection string real do MySQL
            optionsBuilder.UseMySql(
                "Server=localhost;Database=MercadoAZ.DBTest;Uid=root;Pwd=a7S!ia31Pm4#V8Sc;",
                new MySqlServerVersion(new Version(8, 0, 36))
            );

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
