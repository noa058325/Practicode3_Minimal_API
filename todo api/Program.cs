using Microsoft.EntityFrameworkCore;
using TodoApi;

var builder = WebApplication.CreateBuilder(args);

// הוספת DbContext
builder.Services.AddDbContext<ToDoDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("tododb"),
        new MySqlServerVersion(new Version(8, 0, 40))
    ));

// הוספת שירות ה-ToDoService
builder.Services.AddScoped<ToDoService>();

// הוספת CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// הוספת Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// השתמש ב-CORS
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// מיפוי לשורש
app.MapGet("/", () => Results.Redirect("/swagger"));

// Map לשליפת כל המשימות
app.MapGet("/items", async (ToDoService service) =>
{
    return await service.Get();
});

// Map להוספת משימה חדשה
app.MapPost("/items", async (ToDoService service, Item newItem) =>
{
    return await service.Post(newItem);
});

// Map לעדכון משימה קיימת
app.MapPut("/items/{id}", async (ToDoService service, int id, Item updatedItem) =>
{
    return await service.Put(id, updatedItem);
});

// Map למחיקת משימה
app.MapDelete("/items/{id}", async (ToDoService service, int id) =>
{
    return await service.Delete(id);
});

app.Run();
