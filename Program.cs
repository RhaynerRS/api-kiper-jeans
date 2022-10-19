using ApiMongoDb;
using ApiMongoDb.models;
using ApiMongoDb.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<produtoDatabaseSetting>
    (builder.Configuration.GetSection("DadosMongo"));


var root=Directory.GetCurrentDirectory();
var path = Path.Combine(root,".env");
DotEnv.Load(path);

builder.Services.AddSingleton<ProdutoService>();
builder.Services.AddSingleton<ClienteService>();
builder.Services.AddSingleton<VendaService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config =
    new ConfigurationBuilder()
        .AddEnvironmentVariables()
        .Build();

Console.WriteLine();

builder.Services.AddCors(options => options.AddPolicy(name: "AppOrigins", policy =>
{
    policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseCors("AppOrigins");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
