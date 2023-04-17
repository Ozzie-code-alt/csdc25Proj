using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using csdc25Proj.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<csdc25ProjContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("csdc25ProjContext") ?? throw new InvalidOperationException("Connection string 'csdc25ProjContext' not found.")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<csdc25ProjContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
