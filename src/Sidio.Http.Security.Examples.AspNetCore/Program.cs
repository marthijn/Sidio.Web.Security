using Sidio.Http.Security.AspNetCore;
using Sidio.Http.Security.Headers.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseXFrameOptions();
app.UseXContentTypeOptions();
app.UseStrictTransportSecurity(new StrictTransportSecurityHeaderOptions
{
    MaxAge = 0,
});

if (app.Environment.IsDevelopment())
{
    app.UseHeaderValidation();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

public partial class Program();
