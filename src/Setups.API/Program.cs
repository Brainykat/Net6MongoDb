using CommonBase.Data;
using CommonBase.Data.Configuration;

var builder = WebApplication.CreateBuilder(args);

//DI mongo connection and services
builder.Services.Configure<MongoDbDatabaseSettings>(
    builder.Configuration.GetSection(nameof(MongoDbDatabaseSettings)));
builder.Services.RegisterNestServices();
// Add services to the container.

builder.Services.AddControllers()
  .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
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
