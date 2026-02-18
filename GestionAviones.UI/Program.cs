using GestionAviones.UI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("AvionesApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7170/");
    client.DefaultRequestHeaders.Add("X-API-KEY", "123456");
});

builder.Services.AddScoped<ServicioApi>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=GestionAviones}/{action=Index}/{id?}");

app.Run();
