# CINEMA TICKETS SALE APP

A .Net Blazor project.
An event venue (in this case, a movie theater) needs to manage access control for its auditoriums. The system should allow for registering movies and their available showtimes, as well as processing ticket sales.
It should also be capable of generating reports on daily, weekly, and monthly activity.

## Set-UP
How to start a new Porject

    dotnet new blazor -n ProjectName

How to add a new component

    dotnet new razorcomponent -n CompName -o Components/Pages 

Run these commands to add the Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.Sqlite, and System.Net.Http.Json packages:

    dotnet add package Microsoft.EntityFrameworkCore 
    dotnet add package Microsoft.EntityFrameworkCore.Sqlite 
    dotnet add package System.Net.Http.Json

Creatae first migration

    dotnet ef migrations add InitialCreate

Create database

    dotnet ef database update

### CLI  commands to Run 
Watch allow look the changes alive

    dotnet build
    dotnet run 
    dotnet watch

## Tree
Try from CLI the following command to display the project tree

    tree /F
