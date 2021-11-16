using Microsoft.EntityFrameworkCore;

namespace SOHome.Domain.Data
{
    public interface IMigrationService
    {
        void Migrate();
        Task MigrateAsync();
    }
    public class MigrationService : IMigrationService
    {
        private readonly SOHomeDbContext dbContext;

        public MigrationService(SOHomeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Migrate()
        {
           dbContext.Database.Migrate();
        }

        public async Task MigrateAsync()
        {
            await dbContext.Database
                .MigrateAsync();
        }
    }
}
