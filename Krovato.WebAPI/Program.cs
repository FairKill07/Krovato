using Krovato.Persistence;
using Krovato.Persistence.DbContexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        DbInitializer.Initialize(services.GetRequiredService<KrovatoDbContext>());
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred during database initialization: {ex.Message}");
        throw;
    }
}


app.UseHttpsRedirection();

app.Run();
