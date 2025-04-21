using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ticketing_System;
using Ticketing_System.Models;
using Ticketing_System.Repository;
using Ticketing_System.Repository.Interfaces;
using Ticketing_System.Repository_Pattern.Interfaces;
using Ticketing_System.Service_Layer;
using Ticketing_System.Service_Layer.Interfaces;
using Ticketing_System.Service_Layer.Service;
using Ticketing_System.Service_Layer.Services;

namespace Ticketing_System
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configuration de la chaîne de connexion SQL Server
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Repository Pattern
            builder.Services.AddScoped<ITicketRepository, TicketRepository>();
            builder.Services.AddScoped<ITicketCommentRepository, TicketCommentRepository>();
            builder.Services.AddScoped<ITicketHistoryRepository, TicketHistoryRepository>();
            builder.Services.AddScoped<IAttachmentRepository, AttachmentRepository>();
            builder.Services.AddScoped<ISupportTeamRepository, SupportTeamRepository>();
            builder.Services.AddScoped<INotificationRepository,NotificationRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            //Service Layer
            builder.Services.AddScoped<ITicketService, TicketService>();
            builder.Services.AddScoped<ITicketCommentService, TicketCommentService>();
            builder.Services.AddScoped<ITicketHistoryService, TicketHistoryService>();
            builder.Services.AddScoped<IAttachmentService, AttachmentService>();
            builder.Services.AddScoped<ISupportTeamService, SupportTeamService>();
            builder.Services.AddScoped<INotificationService,NotificationService>();
            builder.Services.AddScoped<IUserService, UserService>();





            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            // Ajout des services Razor Pages et MVC
            builder.Services.AddRazorPages(options =>
            {
                options.Conventions.AddPageRoute("/Identity/Account/Register", "/Register");
            });
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configuration du pipeline HTTP
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
          

            app.MapRazorPages();

            // Définir les routes
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
                var roles = new[] { "Admin", "SupportAgent", "User" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new Role { Name = role });
                    }
                }

                using (var innerScope = app.Services.CreateScope())
                {
                    var userManager = innerScope.ServiceProvider.GetRequiredService<UserManager<User>>();

                    string email = "admin@admin.com";
                    string password = "Admin@123";

                    if (await userManager.FindByEmailAsync(email) == null)
                    {
                        var user = new User
                        {
                            UserName = email,
                            Email = email,
                            FirstName = "Admin",
                            LastName = "User"
                        };
                        var result = await userManager.CreateAsync(user, password);
                        if (result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user, "Admin");
                        }
                    }
                }

                app.Run();
            }
        }
    }
}
