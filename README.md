Application – Booking a tour in Belarus
Goal:
It is necessary to develop an application for searching excursions, which will allow you to book a place for an excursion. The application must be able to select tours by filters. 

Requirements:
1.	Application architecture: 3-level client-server (+ intermediate layer with repositories)
(Scheme:https://www.figma.com/file/9wgYj9NBONd43Y6QrbwOsq/Untitled?node-id=0%3A1)
 
1.	Implement the application using .NET Core 3.1 and REST API technology
2.	There should be support for 2 types of roles: user and administrator
3.	For authentication use IdentityServer4
(https://identityserver4.readthedocs.io/en/latest/ )
4.	Use DBMS to store data — Microsoft SQL Server
5.	To organize data access, use Entity Framework Core (mapping model classes to tables - Code First approach, Fluent API)
(EF Core: https://docs.microsoft.com/en-us/ef/core/
Fluent API: https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/types-and-properties)
6.	Use Repository + Unit of Work patterns to work with data between business logic layer and database models
(https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application)
7.	Data input must be checked for correctness. Validation is carried out using the FluentValidation library
(https://docs.fluentvalidation.net/en/latest/  )
8.	The interface must be built on the basis of a web application
