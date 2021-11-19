using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using System.Text.RegularExpressions;

namespace SOHome.Domain.Data
{
    public static class LinqSnakeCase
    {
        public static void ToSnakeNames(this ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                if (entity.GetTableName() == "__EFMigrationsHistory")
                    continue;

                var tableName = entity.GetTableName().ToSnakeCase();
                entity.SetTableName(tableName);
                var tableObject = StoreObjectIdentifier.Table(tableName);
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property
                        .GetColumnName(tableObject)
                        .ToSnakeCase());
                }

                foreach (var key in entity.GetKeys())
                {
                    key.SetName(key.GetName().ToSnakeCase());
                }

                foreach (var key in entity.GetForeignKeys())
                {
                    key.SetConstraintName(key.GetConstraintName().ToSnakeCase());
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
                }
            }
        }

        private static string ToSnakeCase(this string name)
        {
            return string.IsNullOrWhiteSpace(name)
                ? name
                : Regex.Replace(
                    name,
                    @"([a-z0-9])([A-Z])",
                    "$1_$2",
                    RegexOptions.Compiled,
                    TimeSpan.FromSeconds(1)).ToLower();
        }
    }
}
