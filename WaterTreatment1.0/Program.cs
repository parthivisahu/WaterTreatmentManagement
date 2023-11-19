using MongoDB.Driver;
using Microsoft.Extensions.Options;
using WaterTreatment1._0.Models;
using WaterTreatment1._0.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<UserSettings>(
    builder.Configuration.GetSection(nameof(UserSettings)));

builder.Services.AddSingleton<IUserSettings>(sp =>
sp.GetRequiredService<IOptions<UserSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
new MongoClient(builder.Configuration.GetValue<string>("UsersSettings:ConnectionString")));

builder.Services.AddScoped<IUserServices, UserService>();

//WaterTreatmentPlant
builder.Services.Configure<WaterTreatmentPlantSettings>(
    builder.Configuration.GetSection(nameof(WaterTreatmentPlantSettings)));

builder.Services.AddSingleton<IWaterTreatmentPlantSettings>(sp =>
sp.GetRequiredService<IOptions<WaterTreatmentPlantSettings>>().Value);


builder.Services.AddSingleton<IMongoClient>(s =>
new MongoClient(builder.Configuration.GetValue<string>("WaterTreatmentPlantSettings:ConnectionString")));

builder.Services.AddScoped<IWaterTreatmentPlantServices, WaterTreatmentPlantServices>();

//PendingFlows
builder.Services.Configure<PendingFlowSettings>(
    builder.Configuration.GetSection(nameof(PendingFlowSettings)));

builder.Services.AddSingleton<IPendingFlowSettings>(sp =>
sp.GetRequiredService<IOptions<PendingFlowSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
new MongoClient(builder.Configuration.GetValue<string>("PendingFlowSettings:ConnectionString")));

builder.Services.AddScoped<IPendingFlowServices, PendingFlowServices>();

//Auth
builder.Services.Configure<UserAuthSettings>(
    builder.Configuration.GetSection(nameof(UserAuthSettings)));

builder.Services.AddSingleton<IUserAuthSettings>(sp =>
sp.GetRequiredService<IOptions<UserAuthSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
new MongoClient(builder.Configuration.GetValue<string>("UserAuthSettings:ConnectionString")));

builder.Services.AddScoped<IUserAuthServices, UserAuthServices>();

//TreatmentStats
builder.Services.Configure<TreatmentStatsSettings>(
    builder.Configuration.GetSection(nameof(TreatmentStatsSettings)));

builder.Services.AddSingleton<ITreatmentStatsSettings>(sp =>
sp.GetRequiredService<IOptions<TreatmentStatsSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
new MongoClient(builder.Configuration.GetValue<string>("TreatmentStatsSettings:ConnectionString")));

builder.Services.AddScoped<ITreatmentStatsServices, TreatmentStatsServices>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});


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

app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();