using LibraryCataloger.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace LibraryCataloger;

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<BookDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped<IBookRepository, BookRepository>();
        
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


//TODO list 

//Figure out how to allow isbn to be optional (user may not have isbn for book if they do not own the book yet)
// - NOTE: your validation on each of your properties, like `isbn`, comes from your entity. So the validation in
// your View is strongly linked to the validation in your entity. This will lead to how you make isbn optional :)


//figure out how to create a bootstrap theme
// - NOTE: It looks like you're already using Bootstrap, check out `_Layout.cshtml` and
// refer to https://getbootstrap.com/docs/4.0/getting-started/introduction/
// Theming is a little involved but this is how https://getbootstrap.com/docs/4.0/getting-started/theming/

//figure out how pagination in bootstrap
// - NOTE: Here's how to do pagination, although the trick will be how to do dynamic pagination.
// Looks like there's a way to do it with C#, There's a snippet of iterating over a collection
// https://learn.microsoft.com/en-us/aspnet/core/mvc/views/working-with-forms?view=aspnetcore-8.0#expression-names-and-collections
// https://getbootstrap.com/docs/4.0/components/pagination/


//figure out how to display true/false as yes no for inlibrary and tobereadlist
// - NOTE: This is tricky. I'm currently unsure how to do this but am interested so will continue experimenting with this
// Let me know if you get it

//implement at least 3 unit tests
// - NOTE: Let me know if this is tricky. Since you've transformed this project into a WebApp with views and handling routes
// it opens up the project to more types of testing, e.g. E2E testing, integration tests, etc. It's definitely a rabit hole.
// My advice is to get at least a foundation of a couple tests written so it's clear that you can easily just add new tests
// on a whim as needed.



