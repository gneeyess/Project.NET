<h1>Application – Booking a tour in Belarus</h1> 
<br>
<h1>Goal:</h1> 
<p>It is necessary to develop an application for searching excursions, which will allow you to book a place for an excursion. The application must be able to select tours by filters.</p>
<br>
<h1>Requirements:</h1>
<ul>
  <li>Application architecture: 3-level client-server (+ intermediate layer with repositories)
(Scheme: https://www.figma.com/file/9wgYj9NBONd43Y6QrbwOsq/Untitled?node-id=0%3A1)
 </li>
  <li>Implement the application using .NET Core 3.1 and REST API technology</li>
  <li>There should be support for 2 types of roles: user and administrator</li>
  <li>For authentication use IdentityServer4
(https://identityserver4.readthedocs.io/en/latest/)
</li>
  <li>Use DBMS to store data — Microsoft SQL Server</li>
  <li>To organize data access, use Entity Framework Core (mapping model classes to tables - Code First approach, Fluent API)
(EF Core: https://docs.microsoft.com/en-us/ef/core/
Fluent API: https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/types-and-properties)
</li>
  <li>Use Repository + Unit of Work patterns to work with data between business logic layer and database models
  (https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application)</li>
  <li>Data input must be checked for correctness. Validation is carried out using the FluentValidation library
  (https://docs.fluentvalidation.net/en/latest/)</li>
  <li>The interface must be built on the basis of a web application</li>
</ul>
<br>
<h1>Functional:</h1>
<ul>
  <li>The home page contains a list of upcoming tours (execute a ban on the display of finished tours)</li>
  <li>There is also a text field and a search button on the page. According to the substring entered by the user, excursions are searched for by name</li>
  <li>Filtration. Filtration categories: city, price, dates (start/end), type of tour and transport. There is a button to reset filters and show filter results. If none of the categories is changed, the resulting query displays tours for all categories</li>
  <li>If the user is not logged in, the pages display the registration/authorization buttons</li>
  <li>After authorization, instead of the registration/authorization buttons, the user's personal account button is shown</li>
  <li>Excursion data output is displayed as cards with minimal information: name, route, dates, duration, price</li>
  <li>By clicking on the tour card, the user goes to a separate page of the tour, which contains full information about it. There is also a button for booking a place for this tour</li>
  <li>The personal account displays the username, as well as a list of booked excursions</li>
  <li>Administrator functionality. Deleting/adding/changing expeditions. Removing users. Changing or removing a booking</li>
</ul>
<br>
<h1>App example:</h1>
<img/>
<br>
<h1>Additionally:</h1>
<ul>
  <li>Working with Application Documentation - Swagger Framework
(https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-6.0)
</li>
  <li>Code reduction, entity mapping definition - AutoMapper tool
(https://docs.automapper.org/en/stable/Getting-started.html)
</li>
  <li>Functionality extension: the ability to add an excursion to favorites</li>
  <li>Adding sorting tours by price, duration and date</li>
</ul>
