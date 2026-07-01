using Microsoft.EntityFrameworkCore;

namespace Pure.RelationalSchema.RichRelationalModel.EFCore.Tests;

public sealed class RelationalSchemaDbContextFixture : IDisposable
{
    public RelationalSchemaDbContext Context { get; }

    public RelationalSchemaDbContextFixture()
    {
        DbContextOptions<RelationalSchemaDbContext> options =
            new DbContextOptionsBuilder<RelationalSchemaDbContext>()
                .UseInMemoryDatabase(databaseName: nameof(RelationalSchemaDbContextTests))
                .Options;

        Context = new RelationalSchemaDbContext(options);
    }

    public void Dispose()
    {
        Context.Dispose();
    }
}
