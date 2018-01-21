## Todo App
app from => https://docs.microsoft.com/es-es/aspnet/core/tutorials/web-api-vsc
- The client is whatever consumes the web API (mobile app, browser, etc.). This tutorial doesn't create a client. Postman or curl is used as the client to test the app.
- A model is an object that represents the data in the app. In this case, the only model is a to-do item. Models are represented as C# classes, also know as Plain Old C# Object (POCOs).
- A controller is an object that handles HTTP requests and creates the HTTP response. This app has a single controller.
- To keep the tutorial simple, the app doesn’t use a persistent database. The sample app stores to-do items in an in-memory database.