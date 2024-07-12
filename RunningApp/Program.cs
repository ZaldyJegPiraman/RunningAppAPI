using Microsoft.EntityFrameworkCore;
using NLog;
using RunningApp.Data;
using RunningApp.Interfaces;
using RunningApp.Repository;
using RunningApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<RunningAppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddScoped<IRunningActivityRepository, RunningActivityRepository>();

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Running Application API",
        Description = "This project involves a .NET Core Web API application that manages user profiles and tracks running activity. I utilize Entity Framework as the Object-Relational Mapping (ORM) tool.\r\nThe application comprises two tables: one for storing user profile data and another for running activity records, linked via a userId. Both user profiles and running activities support Create, Read, Update, and Delete (CRUD) operations.\r\n"
    });
});

builder.Services.AddSwaggerGenNewtonsoftSupport();


builder.Services.AddControllers().AddJsonOptions(jsonOptions =>
{
    jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddControllers()
        .AddNewtonsoftJson(options =>
        {
            options.UseMemberCasing();
        });


var app = builder.Build();




if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    //await Seed.SeedUsersAndRolesAsync(app);
    Seed.SeedData(app);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        //c.SwaggerEndpoint("swagger/ui/index.html", "Running Application API");
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Running Application API");
        c.RoutePrefix = string.Empty;
    });
}

app.UseCors(options =>
    options.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);


app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

