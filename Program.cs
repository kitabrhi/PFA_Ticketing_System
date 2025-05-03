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
using Ticketing_System.Services;

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
            builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
            builder.Services.AddScoped<IEscalationRuleRepository, EscalationRuleRepository>();
            builder.Services.AddScoped<IAssignmentRuleRepository, AssignmentRuleRepository>();

            // Service Layer
            builder.Services.AddScoped<ITicketService, TicketService>();
            builder.Services.AddScoped<ITicketCommentService, TicketCommentService>();
            builder.Services.AddScoped<ITicketHistoryService, TicketHistoryService>();
            builder.Services.AddScoped<IAttachmentService, AttachmentService>();
            builder.Services.AddScoped<ISupportTeamService, SupportTeamService>();
            builder.Services.AddScoped<INotificationService, NotificationService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITeamMemberService, TeamMemberService>();
            builder.Services.AddScoped<IEscalationRuleService, EscalationRuleService>();
            builder.Services.AddScoped<IAssignmentRuleService, AssignmentRuleService>();

            // Service d'arrière-plan pour les escalades automatiques
            builder.Services.AddHostedService<EscalationBackgroundService>();

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

            // Initialisation de la base de données et création des rôles et utilisateurs
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await dbContext.Database.MigrateAsync();

                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                // Création des rôles
                var roles = new[] { "Admin", "SupportAgent", "User" };
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new Role { Name = role });
                    }
                }

                // Création de l'utilisateur admin
                string adminEmail = "admin@admin.com";
                string adminPassword = "Admin@123";

                if (await userManager.FindByEmailAsync(adminEmail) == null)
                {
                    var adminUser = new User
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        FirstName = "Admin",
                        LastName = "User",
                        EmailConfirmed = true,
                        IsActive = true
                    };

                    var result = await userManager.CreateAsync(adminUser, adminPassword);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                }

                // Création d'un utilisateur système pour les opérations automatiques
                string systemEmail = "system@quantumdesk.com";
                string systemPassword = "SystemPassword123!";

                if (await userManager.FindByEmailAsync(systemEmail) == null)
                {
                    var systemUser = new User
                    {
                        UserName = "system",
                        Email = systemEmail,
                        FirstName = "System",
                        LastName = "Automated",
                        EmailConfirmed = true,
                        IsActive = true
                    };

                    var result = await userManager.CreateAsync(systemUser, systemPassword);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(systemUser, "Admin");
                    }
                }

                // Création d'un agent de support pour les tests
                string agentEmail = "agent@quantumdesk.com";
                string agentPassword = "Agent123!";

                if (await userManager.FindByEmailAsync(agentEmail) == null)
                {
                    var agentUser = new User
                    {
                        UserName = agentEmail,
                        Email = agentEmail,
                        FirstName = "Support",
                        LastName = "Agent",
                        EmailConfirmed = true,
                        IsActive = true
                    };

                    var result = await userManager.CreateAsync(agentUser, agentPassword);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(agentUser, "SupportAgent");
                    }
                }

                // Création d'une équipe de support par défaut si aucune n'existe
                if (!await dbContext.SupportTeams.AnyAsync())
                {
                    var adminId = (await userManager.FindByEmailAsync(adminEmail))?.Id;
                    if (!string.IsNullOrEmpty(adminId))
                    {
                        var defaultTeam = new SupportTeam
                        {
                            TeamName = "Default Support Team",
                            Description = "Default team handling all types of tickets",
                            ManagerId = adminId
                        };

                        dbContext.SupportTeams.Add(defaultTeam);
                        await dbContext.SaveChangesAsync();

                        // Ajouter l'agent à l'équipe
                        var agentId = (await userManager.FindByEmailAsync(agentEmail))?.Id;
                        if (!string.IsNullOrEmpty(agentId))
                        {
                            var teamMember = new TeamMember
                            {
                                TeamID = defaultTeam.TeamID,
                                UserId = agentId,
                                JoinDate = DateTime.Now
                            };

                            dbContext.TeamMembers.Add(teamMember);
                            await dbContext.SaveChangesAsync();
                        }
                    }
                }

                // Création d'une règle d'assignation par défaut si aucune n'existe
                if (!await dbContext.AssignmentRules.AnyAsync())
                {
                    var defaultTeam = await dbContext.SupportTeams.FirstOrDefaultAsync();
                    if (defaultTeam != null)
                    {
                        var defaultRule = new AssignmentRule
                        {
                            RuleName = "Default Assignment Rule",
                            Description = "Assigns all tickets to the default support team",
                            Category = null, // Tous types de catégorie
                            Priority = null, // Tous niveaux de priorité
                            AssignToTeamID = defaultTeam.TeamID,
                            IsActive = true,
                            RuleOrder = 1
                        };

                        dbContext.AssignmentRules.Add(defaultRule);
                        await dbContext.SaveChangesAsync();
                    }
                }
            }

            app.Run();
        }
    }
}