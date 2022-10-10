using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Cosmos;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using TruckDriverInfo.Repository;
using TruckDriverInfo.Services;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));


//logging
builder.Logging.ClearProviders();
var path = config.GetValue<string>("Logging:FilePath");
var logger = new LoggerConfiguration()
    .WriteTo.File(path)
    .CreateLogger();
builder.Logging.AddSerilog(logger);

// Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Truck Drivers API",
        Description = "Truck Drivers Information Located in Germany",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Contact the Developer",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Find more about swagger",
            Url = new Uri("https://swagger.io/")
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});


//DependencyInjection
builder.Services.AddScoped<IDriversInfoService, DriversInfoService>();
builder.Services.AddScoped<ITruckDriverRepository, TruckDriverRepository>();

////CosmosDB
//using CosmosClient client = new(
//    accountEndpoint: Environment.GetEnvironmentVariable("COSMOS_ENDPOINT")!,
//    authKeyOrResourceToken: Environment.GetEnvironmentVariable("COSMOS_KEY")!
//    );

//Database database = await client.CreateDatabaseIfNotExistsAsync(
//    id: "truck"
//);
//Container container = await database.CreateContainerIfNotExistsAsync(
//    id: "drivers",
//    partitionKeyPath: "/location",
//    throughput: 400
//);

var app = builder.Build();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
