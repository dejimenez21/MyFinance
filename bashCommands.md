## Migration Scripts

### FinancialTools Module

#### Add new migration
> dotnet ef migrations add "[MigrationName]" -p FinancialTools.Infrastructure/ -s Api/ --context FinancialToolsDbContext -o Persistence/Migrations/

#### Remove migration
> dotnet ef migrations remove -p FinancialTools.Infrastructure/ -s Api/ --context FinancialToolsDbContext