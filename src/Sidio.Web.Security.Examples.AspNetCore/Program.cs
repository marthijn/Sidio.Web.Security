using Sidio.Web.Security.AspNetCore;
using Sidio.Web.Security.AspNetCore.ContentSecurityPolicy;
using Sidio.Web.Security.Headers.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddContentSecurityPolicy()
    .AddSubresourceIntegrity()
    .ConfigureTagHelpers(
        x =>
        {
            x.AutoApplyNonce = true;
            x.AutoApplySubresourceIntegrity = true;
        })
    .AddControllersWithViews();

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
    DisableForLocalhostRequests = false, // disabled for testing purposes
});
app.UseContentSecurityPolicy(
    (services, b) =>
    {
        b.AddDefaultSrc(x => x.AllowSelf());
        b.AddScriptSrc(x => x.AddNonce(services));
        b.AddStyleSrc(x => x.AddNonce(services));

        b.AddReportTo("csp-report");

        // add a deprecated header for testing purposes
        b.AddReportUri("/Home/Report");

        // predefined policies
        if (app.Environment.IsDevelopment())
        {
            b.AppendBrowserLinkPolicy();
        }
    });

app.UsePermissionPolicy(
    b =>
    {
        b
            .AddAccelerometer(x => x.Disallow())
            .AddPayment(x => x.Disallow())
            .AddAutoplay(x => x.AddSelf());
    });

app.UseReportTo(
    new ReportToHeaderOptions
    {
        Groups =
        [
            new("csp-report", "/Home/Report")
        ],
    });

app.UseReferrerPolicy(new ReferrerPolicyHeaderOptions
{
    Policies = [ReferrerPolicy.NoReferrer],
});

if (app.Environment.IsDevelopment())
{
    app.UseHeaderValidation();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

await app.RunAsync();

public partial class Program;
