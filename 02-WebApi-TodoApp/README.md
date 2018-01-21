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