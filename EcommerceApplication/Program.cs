using CommonUtilies;
using EcommerceApplication.Components;
using EcommerceApplication.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddTransient<AuthorizationMessageHandler>();
builder.Services.AddHttpClient("AuthenticatedClient", sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetSection("AppSetting")["ServiceUrl"]) })
    .AddHttpMessageHandler<AuthorizationMessageHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
