# Netcore Tutorials 
## MvcMovie
([https://docs.microsoft.com/es-es/aspnet/core/tutorials/first-mvc-app-xplat/start-mvc]) 

## Commands

- Create app

---------------
mkdir MvcMovie
cd MvcMovie
dotnet new mvc
---------------
  

- Add HelloWorldController

- Add Welcome Method with parameters

- Add View to Welcome/Index

- Modify Layout, add Movies/Index link

- Add Movie List to ViewBag from HelloWorld view

- Add welcome view

#### Create a Movie Model
- Add Movie model
- Prepare the project for scaffolding, add codetools in csproj
- add MvcMoviesContext
- add to ConfigureService, de DBContext injection, AddDbContext<
- apply the next command: ** dotnet aspnet-codegenerator controller -name MoviesController -m Movie -dc MvcMovieContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries **. this create CRUD views, 
- Perform Initial Migration: 
dotnet ef migrations add InitialCreate => create DB with the model specified in DbContext
dotnet ef database update => execute the method *up* from InitialCreation migration

- Add SeedData, SeedDataClass and Seed initialize in Program.main
- Add DisplayDataAnnotation, See https://docs.microsoft.com/es-es/aspnet/core/mvc/views/tag-helpers/intro for tagHelpers custom's :)

#### Add new field
- Add Rating in Movie Model
- Update Bind attribute for both, the create and update methods to include rating property
- Update Movie/Index view, for display the Rating prop.
- Disconnect db with command: dotnet ef database drop => not for production! https://docs.microsoft.com/es-es/aspnet/core/tutorials/first-mvc-app-xplat/new-field
- update SeedData so that it provides a value for Rating
- Update others view for display Rating prop
- Add a new Migration: dotnet ef migrations add Add_Movie_rating
- Execute: dotnet ef database update

#### Add validations
- add validations to the model

