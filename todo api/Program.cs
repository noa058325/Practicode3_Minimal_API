using TodoApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPlicy",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ToDos", Version = "v1" });
});

builder.Services.AddDbContext<ToDoDbContext>(
);

builder.Services.AddScoped<ToDoService>();

var app = builder.Build();
app.UseCors(options => options.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());

app.UseSwagger();
    app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    c.RoutePrefix =string.Empty;
});

app.MapGet("/", () => "Hello World!");

app.MapGet("/todos", (ToDoService s) =>s.Get() );
app.MapPost("/todo", (Item i,ToDoService s) => s.Post(i));
app.MapPut("/todo/{id}", (int id,Item i,ToDoService s) => s.Put(id,i));
app.MapDelete("/todo/{id}", (int id,ToDoService s) => s.Delete(id));

app.Run();

