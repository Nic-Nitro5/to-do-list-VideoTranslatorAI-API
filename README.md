#Todo list API with .NET, C# and Postgres

#SETUP
* Install Nuget packages for the application
	1. EntityFramework -> dotnet add package Microsoft.EntityFrameworkCore --version 7.0.2
	2. EntityFramework Tools -> dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.2
	3. EntityFramework Postgres -> dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 7.0.1

* Database Setup (Postgres)
	1. After adding the Entities and DbContext run -> Add-Migration "Initial Migration"
	2. Run the migration script -> update-database

#Run LOCALLY
* Supply the database details in the appsettings.json in the "ConnectionStrings" property

#User Flow
1. CRUD on Users
2. Login User
3. CRUD on Todo items
