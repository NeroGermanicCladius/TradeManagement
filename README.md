# Introduction
POC trade management web-application.
 
# Technical Requirements
* .NET Core 3.1
* EF Core
* Blazor
* SQLLite

# Installation
* Clone this project to your local machine.

Then: 
* Open `https://localhost:5001` in your browser and have fun.

# Users

You can use 'bob' or 'alice' as username. Password is 'Pass123$'. By using 'alice' you can choose role. 

# Database Update
Migration

* add-migration InitialIdentityServerMigration -c PersistedGrantDbContext
* add-migration InitialIdentityServerMigration -c ConfigurationDbContext
* add-migration InitialIdentityServerMigration -c ApplicationDbContext

Update

* Update-Database -c PersistedGrantDbContext
* Update-Database -c ConfigurationDbContext
* Update-Database -c ApplicationDbContext
  

# About the Project
We have two component UI and Server.

This project directory contains all backend-related files and directories.
It's written .NET Core 3.1 and uses IdentityServer4, EF Core and Blazor.
