CRUD Todo API with .NET Core

Introduction

This project is a comprehensive implementation of CRUD (Create, Read, Update, Delete) operations using .NET Core with a Todo API. The guide walks through setting up the project, structuring the API, handling database operations with Entity Framework Core, and testing with Postman.

Features

Built with .NET Core 9.0

Implements a RESTful API for managing Todo items

Uses Entity Framework Core for database interaction

Includes global exception handling middleware

Supports DTOs and object mapping

API testing with Postman

Follows a clean architecture with a service layer

Prerequisites

Before starting, ensure you have the following installed:

.NET SDK

Visual Studio Code

Visual Studio 2019

Postman

SQL Server

Check the installed .NET SDK version:

dotnet --version

Ensure you have .NET 9.0 installed.

Project Structure

The project follows a well-organized folder structure:

TodoAPI/
│-- AppDataContext/        # Database context
│-- Contracts/             # Data Transfer Objects (DTOs)
│-- Models/                # Todo model
│-- Controllers/           # API controllers
│-- Interfaces/            # Interface for service layer
│-- Services/              # Business logic services
│-- Mapping/               # Object mapping profiles
│-- Middleware/            # Global exception handling
│-- Program.cs             # Entry point

Setup Instructions

1. Clone the Repository

git clone <repository-url>
cd TodoAPI

2. Create and Setup a New .NET Core Web API

dotnet new webapi -n TodoAPI

3. Install Required Dependencies

dotnet add package Microsoft.EntityFrameworkCore.SqlServer

4. Modify Program.cs

Replace existing content with:

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

5. Define the Todo Model (Models/Todo.cs)

public class Todo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }
}

6. Set Up Database Context (AppDataContext/TodoDbContext.cs)

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }
    public DbSet<Todo> Todos { get; set; }
}

7. Implement CRUD Operations

CreateTodoAsync - Add a new Todo item

GetAllAsync - Retrieve all Todo items

GetByIdAsync - Retrieve a Todo item by ID

UpdateTodoAsync - Update a Todo item

DeleteTodoAsync - Remove a Todo item

8. Run the API

dotnet run

API Testing

Verify API Endpoints with Postman

POST /api/todo - Create a Todo item

GET /api/todo - Get all Todo items

GET /api/todo/{id} - Get a specific Todo item

PUT /api/todo/{id} - Update a Todo item

DELETE /api/todo/{id} - Delete a Todo item

Conclusion

This project provides a hands-on experience in implementing CRUD operations with .NET Core. It covers everything from setting up the project, structuring the API, database interactions, and testing endpoints. Happy coding! 🚀
