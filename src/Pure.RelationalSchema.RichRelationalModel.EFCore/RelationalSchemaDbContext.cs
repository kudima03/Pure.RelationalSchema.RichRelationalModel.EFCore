using Microsoft.EntityFrameworkCore;
using Pure.RelationalSchema.RichRelationalModel.EFCore.Models;
using Pure.RelationalSchema.RichRelationalModel.EFCore.Models.Configurations;

namespace Pure.RelationalSchema.RichRelationalModel.EFCore;

public sealed class RelationalSchemaDbContext(
    DbContextOptions<RelationalSchemaDbContext> options
) : DbContext(options)
{
    public DbSet<SchemaEFCoreModel> Schemas => Set<SchemaEFCoreModel>();

    public DbSet<TableEFCoreModel> Tables => Set<TableEFCoreModel>();

    public DbSet<ColumnEFCoreModel> Columns => Set<ColumnEFCoreModel>();

    public DbSet<ColumnTypeEFCoreModel> ColumnTypes => Set<ColumnTypeEFCoreModel>();

    public DbSet<ForeignKeyEFCoreModel> ForeignKeys => Set<ForeignKeyEFCoreModel>();

    public DbSet<IndexEFCoreModel> Indexes => Set<IndexEFCoreModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.ApplyConfiguration(new ColumnTypeConfiguration());
        _ = modelBuilder.ApplyConfiguration(new ColumnConfiguration());
        _ = modelBuilder.ApplyConfiguration(new IndexConfiguration());
        _ = modelBuilder.ApplyConfiguration(new ForeignKeyConfiguration());
        _ = modelBuilder.ApplyConfiguration(new TableConfiguration());
        _ = modelBuilder.ApplyConfiguration(new SchemaConfiguration());
    }
}
