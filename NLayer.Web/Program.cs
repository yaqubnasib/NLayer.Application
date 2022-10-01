using NLayer.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

Action<HttpClient> x = (option) => {
    option.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
};

builder.Services.AddHttpClient<ProductApiService>(x);
builder.Services.AddHttpClient<CategoryApiService>(x);



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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
