using System.Reflection;
using Krovato.Application;
using Krovato.Application.Common.Mappings;
using Krovato.Application.Interfaces;
using Krovato.Persistence;
using Krovato.Persistence.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Swegger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();

// DB DIPersistence
builder.Services.AddPersistence(builder.Configuration);

// DIApplication
builder.Services.AddApplication();

// AutoMapper
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IKrovatoDbContext).Assembly));
});

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<KrovatoDbContext>();
        DbInitializer.Initialize(dbContext);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred during database initialization: {ex.Message}");
        throw;
    }
}


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); 
    app.UseSwagger();                
    app.UseSwaggerUI();              
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
