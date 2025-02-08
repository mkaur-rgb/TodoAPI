using TodoAPI.AppDataContext;
//using TodoAPI.Interface;
using TodoAPI.Middleware;
using TodoAPI.Models;
//using TodoAPI.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// ....



builder.Services.AddExceptionHandler<GlobalExceptionHandler>(); // Add this line

builder.Services.AddProblemDetails();  // Add this line

// Adding of login 
builder.Services.AddLogging();  //  Add this line



var app = builder.Build();


// ......


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Add this line

app.UseExceptionHandler();
app.UseAuthorization();

app.MapControllers();

app.Run();

