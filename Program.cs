using Budgetoo.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Budgetoo.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Budgetoo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("BudgetooAuthConnection");
builder.Services.AddDbContext<BudgetooAuth>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<BudgetooUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<BudgetooAuth>();
builder.Services.AddRazorPages(); //add eventual admin only pages here
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddAuthorization(options => options.AddPolicy("Admin", policy => policy.RequireAuthenticatedUser().RequireClaim("IsAdmin", bool.TrueString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
