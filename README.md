# Meetup API 
## Used technologies
Using ASP.NET Core Web API With JWT, AutoMapper, Swagger, EF Core, MS SQL <br>
This project has everything you need to get started with ASP.NET Core Web API
+ ASP.NET Core Web API
+ Entity Framework Core (SQL Server)
+ JWT

+ Swagger
+ AutoMapper
## Getting Started
Settings are located in Services\UserService. Write down your settings in constants (if the application does not start).
Also change the ConnectionString field in appsetting.json (the given ConnectionString is configured for SQL Server).
## Code-first database migration
+ Visual Studio: in the menu go to Tools -> NuGet Package Manager -> Package Manager Console. 
Next, at the command line, enter the following commands:
1. ` Add-Migration InitialMigration` 
2. ` Update-Database `
## Functionality Overview
+ CRUD operations with User and Event
+ JWT Authentication
+ Data schemas (view only)
## Page navigation
+ CRUD for `EventInformations` (get all, create, get by id, update, delete) 
  + `GET /api/EventInformations` Get all the events that the given user has 
  + `POST /api/EventInformations` Adding an event
  + `GET /api/EventInformations/{id} ` Get an event by id
  + `PUT /api/EventInformations/{id}` Updates event data by id (id can be found via `GET /api/EventInformations`)
  + `DELETE /api/EventInformations/{id}` Deletes an event by id
+ Get all, register, update, login for `User` 
  + `GET /api/User/allUsers` Get all users
  + `POST /api/User/register` New User registration
  + `PUT /api/User/{id}` Updates user data by id (id can be found via `GET /api/User/allUsers`)
  + `POST /api/User/login` Login by **login** and **password** 
+ Button `Authorize`
> Note <br> 1. Until you are authenticated, you cannot use the following features:
> + `POST`
> + `PUT`
> + `DELETE`
> + `GET` (only when working with `User`)
## Using the WEP API
If you have read the previous article, consider working in this WEB API
To use the selected function, click on it and then click on the `Try it out` button
+ `EventInformations` 
  + `GET`(all) 
  + `POST` In `Request body` you need to fill in the fields with **data** (there is data by default)
  + `GET`(by id) In the parameters enter **Id**
  + `PUT`(by id) In the parameters enter **Id** and In `Request body` you need to fill in the fields with **new data**
  + `DELETE`(by id) In the parameters enter Id
+ `User` 
  + `GET`(all) 
  + `POST`(registration) In `Request body` you need to fill in the fields with new **login** and **password**
  + `PUT`(by id) In the parameters enter Id and In `Request body` you need to fill in the fields with new **login** and **password**
  + `POST` (login) In `Request body` you need to fill in the fields with **login** and **password**<br>
To execute the query/operation, click the **`Execute`** button
## Authors
+ Hleb Punko 
## For feedback
hleb.punko01@gmail.com



