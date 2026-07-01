using Microsoft.EntityFrameworkCore.Metadata;
using Pure.RelationalSchema.RichRelationalModel.EFCore.Models;

namespace Pure.RelationalSchema.RichRelationalModel.EFCore.Tests;

public sealed class RelationalSchemaDbContextTests(
    RelationalSchemaDbContextFixture fixture
) : IClassFixture<RelationalSchemaDbContextFixture>
{
    [Fact]
    public void SchemasDbSetIsNotNull()
    {
        Assert.NotNull(fixture.Context.Schemas);
    }

    [Fact]
    public void TablesDbSetIsNotNull()
    {
        Assert.NotNull(fixture.Context.Tables);
    }

    [Fact]
    public void ColumnsDbSetIsNotNull()
    {
        Assert.NotNull(fixture.Context.Columns);
    }

    [Fact]
    public void ColumnTypesDbSetIsNotNull()
    {
        Assert.NotNull(fixture.Context.ColumnTypes);
    }

    [Fact]
    public void ForeignKeysDbSetIsNotNull()
    {
        Assert.NotNull(fixture.Context.ForeignKeys);
    }

    [Fact]
    public void IndexesDbSetIsNotNull()
    {
        Assert.NotNull(fixture.Context.Indexes);
    }

    [Fact]
    public void OnModelCreatingRegistersSchemaEntity()
    {
        IEntityType? entityType = fixture.Context.Model.FindEntityType(
            typeof(SchemaEFCoreModel)
        );
        Assert.NotNull(entityType);
    }

    [Fact]
    public void OnModelCreatingRegistersTableEntity()
    {
        IEntityType? entityType = fixture.Context.Model.FindEntityType(
            typeof(TableEFCoreModel)
        );
        Assert.NotNull(entityType);
    }

    [Fact]
    public void OnModelCreatingRegistersColumnEntity()
    {
        IEntityType? entityType = fixture.Context.Model.FindEntityType(
            typeof(ColumnEFCoreModel)
        );
        Assert.NotNull(entityType);
    }

    [Fact]
    public void OnModelCreatingRegistersColumnTypeEntity()
    {
        IEntityType? entityType = fixture.Context.Model.FindEntityType(
            typeof(ColumnTypeEFCoreModel)
        );
        Assert.NotNull(entityType);
    }

    [Fact]
    public void OnModelCreatingRegistersForeignKeyEntity()
    {
        IEntityType? entityType = fixture.Context.Model.FindEntityType(
            typeof(ForeignKeyEFCoreModel)
        );
        Assert.NotNull(entityType);
    }

    [Fact]
    public void OnModelCreatingRegistersIndexEntity()
    {
        IEntityType? entityType = fixture.Context.Model.FindEntityType(
            typeof(IndexEFCoreModel)
        );
        Assert.NotNull(entityType);
    }

    [Fact]
    public void SchemaEntityHasPrimaryKey()
    {
        IEntityType? entityType = fixture.Context.Model.FindEntityType(
            typeof(SchemaEFCoreModel)
        );
        Assert.NotNull(entityType?.FindPrimaryKey());
    }

    [Fact]
    public void TableEntityHasPrimaryKey()
    {
        IEntityType? entityType = fixture.Context.Model.FindEntityType(
            typeof(TableEFCoreModel)
        );
        Assert.NotNull(entityType?.FindPrimaryKey());
    }

    [Fact]
    public void ColumnEntityHasPrimaryKey()
    {
        IEntityType? entityType = fixture.Context.Model.FindEntityType(
            typeof(ColumnEFCoreModel)
        );
        Assert.NotNull(entityType?.FindPrimaryKey());
    }

    [Fact]
    public void ColumnTypeEntityHasPrimaryKey()
    {
        IEntityType? entityType = fixture.Context.Model.FindEntityType(
            typeof(ColumnTypeEFCoreModel)
        );
        Assert.NotNull(entityType?.FindPrimaryKey());
    }

    [Fact]
    public void ForeignKeyEntityHasPrimaryKey()
    {
        IEntityType? entityType = fixture.Context.Model.FindEntityType(
            typeof(ForeignKeyEFCoreModel)
        );
        Assert.NotNull(entityType?.FindPrimaryKey());
    }

    [Fact]
    public void IndexEntityHasPrimaryKey()
    {
        IEntityType? entityType = fixture.Context.Model.FindEntityType(
            typeof(IndexEFCoreModel)
        );
        Assert.NotNull(entityType?.FindPrimaryKey());
    }

    [Fact]
    public void TableEntityHasForeignKeyToSchema()
    {
        IEntityType? entityType = fixture.Context.Model.FindEntityType(
            typeof(TableEFCoreModel)
        );
        Assert.Contains(
            entityType!.GetForeignKeys(),
            fk => fk.PrincipalEntityType.ClrType == typeof(SchemaEFCoreModel)
        );
    }

    [Fact]
    public void ColumnEntityHasForeignKeyToTable()
    {
        IEntityType? entityType = fixture.Context.Model.FindEntityType(
            typeof(ColumnEFCoreModel)
        );
        Assert.Contains(
            entityType!.GetForeignKeys(),
            fk => fk.PrincipalEntityType.ClrType == typeof(TableEFCoreModel)
        );
    }

    [Fact]
    public void ColumnEntityHasForeignKeyToColumnType()
    {
        IEntityType? entityType = fixture.Context.Model.FindEntityType(
            typeof(ColumnEFCoreModel)
        );
        Assert.Contains(
            entityType!.GetForeignKeys(),
            fk => fk.PrincipalEntityType.ClrType == typeof(ColumnTypeEFCoreModel)
        );
    }

    [Fact]
    public void IndexEntityHasForeignKeyToTable()
    {
        IEntityType? entityType = fixture.Context.Model.FindEntityType(
            typeof(IndexEFCoreModel)
        );
        Assert.Contains(
            entityType!.GetForeignKeys(),
            fk => fk.PrincipalEntityType.ClrType == typeof(TableEFCoreModel)
        );
    }

    [Fact]
    public void ForeignKeyEntityHasForeignKeyToTable()
    {
        IEntityType? entityType = fixture.Context.Model.FindEntityType(
            typeof(ForeignKeyEFCoreModel)
        );
        Assert.Contains(
            entityType!.GetForeignKeys(),
            fk => fk.PrincipalEntityType.ClrType == typeof(TableEFCoreModel)
        );
    }

    [Fact]
    public void ForeignKeyEntityHasForeignKeyToSchema()
    {
        IEntityType? entityType = fixture.Context.Model.FindEntityType(
            typeof(ForeignKeyEFCoreModel)
        );
        Assert.Contains(
            entityType!.GetForeignKeys(),
            fk => fk.PrincipalEntityType.ClrType == typeof(SchemaEFCoreModel)
        );
    }
}
