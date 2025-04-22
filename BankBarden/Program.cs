using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using Service.CountryService;
using Service.CustomerService;
using Service.TransactionsService;
using Service.AccountService;
using Service.CustomerService.CRUDCustomer;
using System.Reflection;

namespace BankBarden;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<BankAppDataContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<BankAppDataContext>();
        builder.Services.AddRazorPages();

        builder.Services.AddTransient<DataInitializer>();

        builder.Services.AddTransient<ICountryS, CountryS>();
        builder.Services.AddTransient<IAllCustomerS, AllCustomerS>();
        builder.Services.AddTransient<IDepositS, DepositS>();
        builder.Services.AddTransient<IWithdrawalS, WithdrawalS>();
        builder.Services.AddTransient<IAccountS, AccountS>();
        builder.Services.AddTransient<ISingelCustomerS, SingelCustomerS>();
        builder.Services.AddTransient<ICreateCustomerS , CreateCustomerS>();
        builder.Services.AddTransient<IEditCustomerS, EditCustomerS>();
        builder.Services.AddTransient<ITransacrionHistoryS, TransacrionHistoryS>();

        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

        builder.Services.AddResponseCaching();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            scope.ServiceProvider.GetService<DataInitializer>().SeedData();
        }


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

        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapRazorPages()
           .WithStaticAssets();

        app.UseResponseCaching();

        app.Run();
    }
}
