using Restaurant.Application;
using Restaurant.Infrastructure;
using Restaurant.Persistence;

var builder = WebApplication.CreateBuilder(args);

#region Register Services

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterSwagger();

#endregion Register Services

var app = builder.Build();
app.Services.InitializeDb(builder.Configuration);

#region Pipeline

app.UseStaticFiles();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setupAction => setupAction.UseSwaggerUIOptions());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion Pipeline