using blogMarraz.Models.Repos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

public class Program {
    public static void Main(string[] args) {
        string postgresIP           = Environment.GetEnvironmentVariable("POSTGRES_IP") ?? throw new ArgumentNullException("POSTGRES_IP variable not set");
        string postgresPort         = Environment.GetEnvironmentVariable("POSTGRES_PORT") ?? throw new ArgumentNullException("POSTGRES_PORT variable not set");
        string postgresDatabaseName = Environment.GetEnvironmentVariable("POSTGRES_DATABASENAME") ?? throw new ArgumentNullException("POSTGRES_DATABASENAME variable not set");
        string postgresUserName     = Environment.GetEnvironmentVariable("POSTGRES_USERNAME") ?? throw new ArgumentNullException("POSTGRES_USERNAME variable not set");
        string postgresPassword     = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? throw new ArgumentNullException("POSTGRES_PASSWORD variable not set");

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<BlogDbContext>(options => options.UseNpgsql($"Host={postgresIP};Port={postgresPort};Database={postgresDatabaseName};Username={postgresUserName};Password={postgresPassword}"));
        //var env = builder.Environment;
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
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}

//public class BloggingContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
//{
//    public BlogDbContext CreateDbContext(string[] args)
//    {
//        var optionsBuilder = new DbContextOptionsBuilder<BlogDbContext>();
//        optionsBuilder.UseNpgsql("");
//        return new BlogDbContext(optionsBuilder.Options);
//    }
//}