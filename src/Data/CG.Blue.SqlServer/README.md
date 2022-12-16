
### CG.Blue.SqlServer - README

This project contains a SQL-Server data access layer for the **CG.Blue** microservice.

#### Notes

To add/remove/change EFCORE migrations follow these steps:
    
1. Set the CG.Blue.SqlServer project as the startup project, in Visual Studio.
2. Open the Package Manager Console window, in Visual Studio.
3. Set the 'Default project' to CG.Blue.SqlServer, in the Package Manager Console window.
4. Use the normal add-migration commands, in the Package Manager Console window. Remember to use the -outputDir Migrations argument, so the migrations end up in the right sub folder.
5. Remember to set the start project back to the CG.Blue.Host project (or whatever project you normally start with), when you're done.
