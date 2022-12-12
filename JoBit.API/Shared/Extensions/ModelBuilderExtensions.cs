using Microsoft.EntityFrameworkCore;

namespace JoBit.API.Shared.Extensions;


//JoBit -> jo_bit
//Users -> users
//UserId -> user_id
public static class ModelBuilderExtensions
{
    public static void UseSnakeCase(this ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            // It's time to change name convention for this properties
            // For properties
            entity.SetTableName(entity.GetTableName()?.ToSnakeCase());
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnBaseName().ToSnakeCase());
            }
            // For primary keys
            foreach (var primaryKey in entity.GetKeys())
            {
                primaryKey.SetName(primaryKey.GetName()?.ToSnakeCase());
            }
            // For foreign keys
            foreach (var foreignKey in entity.GetForeignKeys())
            {
                foreignKey.SetConstraintName(foreignKey.GetConstraintName()?.ToSnakeCase());
            }
            // For indexes?
            foreach (var index in entity.GetIndexes())
            {
                index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
            }
        }
    }
}