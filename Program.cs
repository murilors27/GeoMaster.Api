using GeoMaster.Api.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// DI
builder.Services.AddSingleton<IShapeFactory, ShapeFactory>();
builder.Services.AddScoped<ICalculadoraService, CalculadoraService>();

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(o =>
    {
        // Deixar mensagens de validação mais “limpas”
        o.SuppressInferBindingSourcesForParameters = true;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GeoMaster API",
        Version = "v1",
        Description = "API de cálculos geométricos (2D/3D) com extensibilidade por descoberta de formas."
    });

    // Habilita XML comments (ative em Properties -> Build -> XML documentation file)
    var xml = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xml);
    if (File.Exists(xmlPath)) c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GeoMaster API v1");
});

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
