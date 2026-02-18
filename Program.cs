var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyección de dependencias
builder.Services.AddScoped<GestionAviones.BL.IAvionRepository, GestionAviones.DA.AvionRepository>();
builder.Services.AddScoped<GestionAviones.BL.IAdministradorDeAviones, GestionAviones.BL.AdministradorDeAviones>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
