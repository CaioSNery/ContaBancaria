using ContaBancaria.Extensions;
using ContaBancaria.Mappings;



var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.DataContextConfigurations();
builder.Services.RepositoriesConfigurations();
builder.Services.ServicesConfigurations();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
var app = builder.Build();

app.MapControllers();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "ContaBancaria API funcionando");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();