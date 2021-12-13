using WebUI.ApiServices;
using WebUI.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<CategoryApiService>(options =>
{
    options.BaseAddress = new Uri(builder.Configuration.GetSection("ApiUrl").Get<string>());
});

builder.Services.AddScoped<NotFoundFilter>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Categories}/{action=Index}/{id?}");

app.Run();
