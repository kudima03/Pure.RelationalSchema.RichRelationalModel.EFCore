# Pure.RelationalSchema.RichRelationalModel.EFCore

Entity Framework Core `DbContext` for the **Pure.RelationalSchema** RichRelationalModel — maps schema, table, column, column type, foreign key, and index entities to a relational database.

[![.NET build & test](https://github.com/kudima03/Pure.RelationalSchema.RichRelationalModel.EFCore/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.RelationalSchema.RichRelationalModel.EFCore/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.RelationalSchema.RichRelationalModel.EFCore/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.RelationalSchema.RichRelationalModel.EFCore/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.RelationalSchema.RichRelationalModel.EFCore)](https://www.nuget.org/packages/Pure.RelationalSchema.RichRelationalModel.EFCore)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.RelationalSchema.RichRelationalModel.EFCore` provides a ready-to-use EF Core `DbContext` for persisting relational schema metadata modelled with the Pure.RelationalSchema RichRelationalModel. It exposes typed `DbSet<T>` properties for every aggregate root and applies the full set of EF Core model configurations on startup.

## Public API

| Type | Kind | Description |
|------|------|-------------|
| `RelationalSchemaDbContext` | `sealed class` | EF Core `DbContext` for the relational schema domain. Primary constructor accepts `DbContextOptions<RelationalSchemaDbContext>`. |

### `RelationalSchemaDbContext` — DbSets

| Property | Entity type | Description |
|----------|-------------|-------------|
| `Schemas` | `SchemaEFCoreModel` | Root schema aggregates |
| `Tables` | `TableEFCoreModel` | Tables belonging to a schema |
| `Columns` | `ColumnEFCoreModel` | Columns belonging to a table |
| `ColumnTypes` | `ColumnTypeEFCoreModel` | Column type lookup entries |
| `ForeignKeys` | `ForeignKeyEFCoreModel` | Foreign key relationships |
| `Indexes` | `IndexEFCoreModel` | Table indexes |

`OnModelCreating` applies `SchemaConfiguration`, `TableConfiguration`, `ColumnConfiguration`, `ColumnTypeConfiguration`, `ForeignKeyConfiguration`, and `IndexConfiguration` from the companion configurations package.

## Dependencies

- [`Pure.RelationalSchema.RichRelationalModel.EFCore.Models`](https://github.com/kudima03/Pure.RelationalSchema.RichRelationalModel.EFCore.Models) — EF Core entity records
- [`Pure.RelationalSchema.RichRelationalModel.EFCore.Models.Configurations`](https://github.com/kudima03/Pure.RelationalSchema.RichRelationalModel.EFCore.Models.Configurations) — EF Core type configurations
