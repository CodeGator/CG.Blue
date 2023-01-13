
## CG.Blue.Data.Sqlite - README

This project contains an EFCORE SQLite provider for the **CG.Blue** microservice.

### Notes

To add/remove/change EFCORE migrations follow these steps:
    
1. Set the CG.Blue.Data.Sqlite project as the startup project, in Visual Studio.
2. Open the Package Manager Console window, in Visual Studio.
3. Use the normal add-migration commands, in the Package Manager Console window. Remember to use the -p CG.Blue.Data.Sqlite argument, so the migrations will end up in the right project.

So here's an example command line for adding a migration in Visual Studio: 
```
add-migration MyMigration -p CG.Blue.Data.Sqlite
```

Remember to set the start project back to the CG.Blue.Host project (or whatever project you normally start with), when you're done.

To deploy SQL for migrations in a production environment, use the following from the command line:

```
dotnet ef migrations script --idempotent
```

Or using the following command, in Visual Studio:

```
Script-Migration -Idempotent
```

[Here](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?tabs=vs) is a link with more suggestions for generating migrations.


