using Restaurant.Api.Middlewares;
using Restaurant.Api.Models;
using Restaurant.Application;
using Restaurant.Infrastructure;
using Restaurant.Persistence;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File(Path.Combine(Directory.GetCurrentDirectory(),"logs","log-.log"),
     rollingInterval: RollingInterval.Day,
     outputTemplate: "[{Level:u3}] | {Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} | {UserName}:{UserId} | {Message:lj}{NewLine}{Exception}")
    .MinimumLevel.Override("Microsoft.AspNetCore",LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .CreateLogger();

try
{
    Log.Information("Starting web application");

    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog();
    string corsPolicyName = "AllowOrigin";

    #region Register Services

    // Add services to the container.
    builder.Services.AddControllers(configure =>
    {
        configure.Filters.Add(new ProducesResponseTypeAttribute(typeof(ApiResult),StatusCodes.Status200OK));
        configure.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
    });
    builder.Services.AddApplicationServices(builder.Configuration);
    builder.Services.AddPersistenceServices(builder.Configuration);
    builder.Services.AddInfrastructureServices(builder.Configuration,builder.Environment);

    // Swagger/OpenAPI
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.RegisterSwagger();

    builder.Services.AddCors(setupAction =>
    {
        string? ClientDomain = builder.Configuration.GetValue<string>("ClientDomain");
        if(!string.IsNullOrWhiteSpace(ClientDomain))
            setupAction.AddPolicy(corsPolicyName,policy => policy.WithOrigins(ClientDomain,"https://sandbox.zarinpal.com").AllowAnyHeader().AllowAnyMethod());
        else
            setupAction.AddPolicy(corsPolicyName,policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
    });

    #endregion Register Services

    var app = builder.Build();
    app.Services.InitializeDb(builder.Configuration);

    #region Pipeline

    app.UseCors(corsPolicyName);
    app.UseStaticFiles();
    app.UseSerilogRequestLogging();

    if(app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(setupAction => setupAction.UseSwaggerUIOptions());
    }

    app.UseHttpsRedirection();
    app.UseMiddleware<ExceptionHandlingMiddleware>();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseMiddleware<LogUserDataMiddleware>();
    app.MapControllers();

    app.Run();

    #endregion Pipeline
}
catch(Exception ex)
{
    Log.Fatal(ex,"Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}