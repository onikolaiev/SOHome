using Microsoft.EntityFrameworkCore;

using SOHome.Domain.Models;

namespace SOHome.Domain.Data
{
    public class SOHomeDbContext : DbContext
    {
        public SOHomeDbContext()
        {

        }

        public SOHomeDbContext(DbContextOptions<SOHomeDbContext> optionsBuilder)
            : base(optionsBuilder)
        {

        }

        public DbSet<Person> People => Set<Person>();
        public DbSet<User> Users => Set<User>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
#if DEBUG
            optionsBuilder.EnableSensitiveDataLogging();
#endif
            optionsBuilder.UseSnakeCaseNamingConvention();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Declarando as sequencias
            modelBuilder.HasSequence("grid_seq");
            modelBuilder.HasSequence("person_code_seq");
            modelBuilder.HasSequence("user_code_seq");

            // Configuração da tabela de pessoas
            var personEntity = modelBuilder.Entity<Person>();
            personEntity.Property(x => x.Id)                
                .HasDefaultValueSql("NEXTVAL('grid_seq')");
            personEntity.Property(x => x.Code)
                .HasDefaultValueSql("NEXTVAL('person_code_seq')");

            // Configuração da tabela de usuarios
            var userEntity = modelBuilder.Entity<User>();
            userEntity.Property(x => x.Id)
            .HasDefaultValueSql("NEXTVAL('grid_seq')");
            userEntity.Property(x => x.Code)
                .HasDefaultValueSql("NEXTVAL('user_code_seq')");
        }
    }
}
