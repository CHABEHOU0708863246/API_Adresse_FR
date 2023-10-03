using API_Adresse_FR.Domain.Interfaces.InterfacesRepository;
using API_Adresse_FR.Domain.Interfaces.InterfacesService;
using API_Adresse_FR.Domain.Services;
using API_Adresse_FR.Infrastructure.Repository;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Récupération de la chaine de connexion MongoDB et du nom de la base de données depuis la configuration
var connectionString = builder.Configuration.GetValue<string>("ConnectionStrings:MongoDb");
var databaseName = builder.Configuration.GetValue<string>("MongoDbSettings:DatabaseName");

// Création d'une instance de MongoClient en utilisant la chaine de connexion
var client = new MongoClient(connectionString);

// Récupération de la base de données MongoDB
var database = client.GetDatabase(databaseName);

// Ajout de la base de données en tant que service singleton
builder.Services.AddSingleton(database);


// Ajout des services nécessaires à l'injection de dépendances de Etablissement
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IAddressService, AddressService>();

// Ajout du service HttpClient
builder.Services.AddHttpClient<IAddressService, AddressService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
