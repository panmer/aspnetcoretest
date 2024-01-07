using gcsharpRPC.Data;
using gcsharpRPC.Helpers;
using gcsharpRPC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
    // .AddRazorPagesOptions(options =>
    // {
    //     options.Conventions.AuthorizeFolder("/");
    //     options.Conventions.AllowAnonymousToPage("/Index");
    //     options.Conventions.AllowAnonymousToPage("/Login");
    //     options.Conventions.AllowAnonymousToPage("/Error");
    //     options.Conventions.AllowAnonymousToPage("/Events/Join");
    //     options.Conventions.AllowAnonymousToPage("/Events/List");
    // });

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(18);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDbContext<TrungContext>();

/**
*   Authentication config
**/
// builder.Services.AddAuthentication(options =>
//     {
//         // default setting
//         options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//         options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
//         options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;  
//         options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//     })
//     .AddCookie(options =>
//     {
//         options.Cookie.HttpOnly = true;
//         options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
//         //options.Cookie.SameSite = SameSiteMode.Strict;

//         // Console.WriteLine(options.Cookie);

//         options.LoginPath = new PathString("/Login");  
//         options.ExpireTimeSpan = TimeSpan.FromMinutes(8.0);  

//         options.Cookie.Name = builder.Configuration["IdentityProvider:CookieName"];
//         options.Events.OnSigningOut = async e => await e.HttpContext.RevokeUserRefreshTokenAsync();
//     });

/**
* Add Service
**/
builder.Services.AddScoped<PollService>();

// builder.Services.AddDatabaseDeveloperPageExceptionFilter();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<TrungContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
// app.UseAuthentication();

app.MapRazorPages();

app.Run();
