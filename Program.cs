using ContaBancaria.Extensions;
using Microsoft.OpenApi.Models; 

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.DataContextConfigurations();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
var app = builder.Build();

app.MapControllers();

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