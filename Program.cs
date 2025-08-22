using InventoryApp.Repositories;
/*
 * Configuring services for the application
 */
var builder = WebApplication.CreateBuilder(args);

// Registering the in-memory repository as a singleton service
builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();
builder.Services.AddControllers();
    
builder.Services.AddEndpointsApiExplorer();
// Adding Swagger for testing API
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
