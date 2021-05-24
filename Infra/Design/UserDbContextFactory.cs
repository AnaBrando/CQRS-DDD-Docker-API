using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.Design
{
    public class UserDbContextFactory: IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            
            optionsBuilder.UseSqlServer(@"Server=tcp:sql,1433;Database=waproject;UID=SA;PWD=myPass123");

            return new ApplicationDbContext(optionsBuilder.Options);
        }

    }
}