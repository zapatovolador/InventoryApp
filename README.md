A RESTful API built in C# using ASP.NET Core to manage a product inventory. This project applies solid design principles such as Single Responsibility, Dependency Inversion, the Repository Pattern and Singleton Pattern, with in-memory data persistence.

## Features

- Full CRUD operations for products
- Data validation using `DataAnnotations`
- Decoupled architecture via interfaces
- Logging for operation tracking

## Project Structure

InventoryApp/ 
-Controllers/ 
----ProductController.cs 
-Models/ 
----Product.cs 
-Repositories/ 
----IProductRepository.cs 
----InMemoryProductRepository.cs 
-Program.cs 
-README.md

## Core Components

### Model

Defines the `Product` class with properties such as `Id`, `Name`, `Price`, and `Quantity`. Uses `System.ComponentModel.DataAnnotations` to validate input before processing.

### Repository

- **Interface (`IProductRepository`)**: Declares CRUD methods without implementation, enabling loose coupling.
- **Implementation (`InMemoryProductRepository`)**: Manages products in memory, auto-generates IDs, and prevents duplicate names.

### Controller

`ProductController` handles HTTP requests using ASP.NET Core MVC. It exposes RESTful endpoints and logs operations via `ILogger`.

### Program.cs

Configures application services:
- Registers the repository as a `Singleton`
- Enables Swagger for API testing
- Sets up the basic request pipeline

## Available Endpoints

| Method | Endpoint             | Description                  |
|--------|----------------------|------------------------------|
| GET    | /api/products        | Retrieves all products       |
| GET    | /api/products/{id}   | Retrieves a product by ID    |
| POST   | /api/products        | Creates a new product        |
| PUT    | /api/products/{id}   | Updates an existing product  |
| DELETE | /api/products/{id}   | Deletes a product            |

## Testing

You can test the API using:
- SwaggerUI
- Postman

## Future Improvements

- **Persistence with Entity Framework Core**  
  Integration with ASP.NET Core, support for LINQ queries and it simplifies database operations and improves maintainability. Great for SQL services or CosmosDB but not for other nonSQL services. 

- **Authentication via OAuth with ASP.NET Core Identity**  
  Enables secure user authentication using external providers like Google or Microsoft. ASP.NET Core Identity offers flexibility and scalability for managing user roles and claims.


