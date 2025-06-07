using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using ODataEjemplo.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar modelo OData
var odataBuilder = new ODataConventionModelBuilder();
odataBuilder.EntitySet<Producto>("Productos");

builder.Services.AddControllers()
    .AddOData(opt => opt
        .AddRouteComponents("odata", odataBuilder.GetEdmModel())
        .Filter()
        .Select()
        .OrderBy()
    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
