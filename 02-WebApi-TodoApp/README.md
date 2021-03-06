## Todo App
app from => https://docs.microsoft.com/es-es/aspnet/core/tutorials/web-api-vsc
- The client is whatever consumes the web API (mobile app, browser, etc.). This tutorial doesn't create a client. Postman or curl is used as the client to test the app.
- A model is an object that represents the data in the app. In this case, the only model is a to-do item. Models are represented as C# classes, also know as Plain Old C# Object (POCOs).
- A controller is an object that handles HTTP requests and creates the HTTP response. This app has a single controller.
- To keep the tutorial simple, the app doesn’t use a persistent database. The sample app stores to-do items in an in-memory database.

### add support to entity framework
Microsoft.AspNetCore.All Has EFcore.InMemory

### add TodoItem model

### create DBContext
Create a db context. The db context is the main class that coordinates Entity Framework functionality for a given data model

### register db context
the database context is registered with the dependency injection container.
- USE: services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));

### Add TodoController

Defines an empty controller class. In the next sections, methods are added to implement the API.
The constructor uses Dependency Injection to inject the database context (TodoContext) into the controller. The database context is used in each of the CRUD methods in the controller.
The constructor adds an item to the in-memory database if one doesn't exist.
https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing#attribute-routing-with-httpverb-attributes

### Implement crud operations
Add Create, Update and Delete operations

### Add Swagger!
https://docs.microsoft.com/es-es/aspnet/core/tutorials/web-api-help-pages-using-swagger?tabs=visual-studio 
#### Swaggerbuckle
dotnet add TodoApi.csproj package Swashbuckle.AspNetCore
add swagger to the startup class (middleware).
Add xml summary and detect for Swagger 
Add DataAnnotations to the model. The presence of this attr change de behavior of the SwaggerUI and modified SwaggerJson
Add [Produces("application/json")] to the ApiController. The actions support a return content type of application/json
Add Description of response type: 
- [ProducesResponseType(typeof(TodoItem), 201)]
- [ProducesResponseType(typeof(TodoItem), 400)]
without the documentation in Swagger UI, the consumer lacks knowledge of these outcomes.
- <response code="201">Returns the newly-created item</response>
- <response code="400">If the item is null</response>            

*Customize the SwaggerUI*
For serve static files, add: <PackageReference Include="Microsoft.AspNetCore.StaticFiles" Version="2.0.0" />
and add in the startup the installed middleware.

Get from https://github.com/swagger-api/swagger-ui/tree/2.x/dist, 
And create a folder wwwroot/swagger/ui , copy the content.
Add /swagger/ui/css/custom.css 



