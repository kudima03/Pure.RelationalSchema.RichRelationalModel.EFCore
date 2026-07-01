# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

All `dotnet` commands must be run from the `./src` directory.

```bash
dotnet restore
dotnet build --no-restore -warnaserror
dotnet format --verify-no-changes             # check code style (CI enforces this)
dotnet format && csharpier format .           # auto-fix code style
dotnet test --no-build --verbosity normal     # run xunit tests
dotnet pack --configuration Release -p:PackageVersion=<version> --output .
```

## Architecture

This is a **single-class NuGet library** that provides an EF Core `DbContext` for the Pure.RelationalSchema RichRelationalModel.

**Public surface:**
- `RelationalSchemaDbContext` (sealed) — primary constructor takes `DbContextOptions<RelationalSchemaDbContext>`. Exposes six `DbSet<T>` properties: `Schemas`, `Tables`, `Columns`, `ColumnTypes`, `ForeignKeys`, `Indexes`. `OnModelCreating` applies all entity configurations from `Pure.RelationalSchema.RichRelationalModel.EFCore.Models.Configurations`.

**Dependency chain:**
- `Pure.RelationalSchema.RichRelationalModel.EFCore.Models.Configurations` supplies the `IEntityTypeConfiguration<T>` implementations (`SchemaConfiguration`, `TableConfiguration`, `ColumnConfiguration`, `ColumnTypeConfiguration`, `ForeignKeyConfiguration`, `IndexConfiguration`) and transitively brings in the EFCore model types and Pure primitive converters/comparers.

**Multi-targeting:** net7.0, net8.0, net9.0, net10.0. `IsAotCompatible` is explicitly `false`.

**Package validation:** `EnablePackageValidation = true`. Once the first version is published, set `PackageValidationBaselineVersion` so breaking changes fail the build.

**Publishing:** triggered by pushing a semver tag matching `*.*.*`. The tag name becomes the `PackageVersion`.

**Tests:** the test project (`Pure.RelationalSchema.RichRelationalModel.EFCore.Tests`) uses xunit. CI also runs mutation testing via `dotnet-stryker` with `--mutation-level Complete`.

## Code Style

Enforced via `.editorconfig`, `dotnet format --verify-no-changes`, and `csharpier check .` in CI:

- No `var` — always use explicit types
- File-scoped namespaces required (`csharp_style_namespace_declarations = file_scoped`)
- No expression-bodied methods or constructors; expression-bodied properties and accessors are required
- Private fields: `_camelCase` prefix
- Unused expression results must be assigned to `_` (discard variable)
- Max line length: 90 characters
- `using` directives outside the namespace

## Commit Messages

Do not mention Claude or AI assistance in commit messages.
