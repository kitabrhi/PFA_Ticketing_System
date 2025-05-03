using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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

            // 1. Configuration de la chaîne de connexion SQL Server
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // 2. Configuration des services
            ConfigureServices(builder.Services, connectionString, builder.Configuration);

            var app = builder.Build();

            // 3. Configuration du pipeline HTTP
            ConfigureMiddleware(app);

            // 4. Initialisation de la base de données et des données par défaut
            await InitializeDatabaseAsync(app);

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services, string connectionString, IConfiguration configuration)
        {
            // 2.1 Configuration des repositories (Repository Pattern)
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITicketCommentRepository, TicketCommentRepository>();
            services.AddScoped<ITicketHistoryRepository, TicketHistoryRepository>();
            services.AddScoped<IAttachmentRepository, AttachmentRepository>();
            services.AddScoped<ISupportTeamRepository, SupportTeamRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
            services.AddScoped<IEscalationRuleRepository, EscalationRuleRepository>();
            services.AddScoped<IAssignmentRuleRepository, AssignmentRuleRepository>();

            // 2.2 Configuration des services (Service Layer)
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ITicketCommentService, TicketCommentService>();
            services.AddScoped<ITicketHistoryService, TicketHistoryService>();
            services.AddScoped<IAttachmentService, AttachmentService>();
            services.AddScoped<ISupportTeamService, SupportTeamService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITeamMemberService, TeamMemberService>();
            services.AddScoped<IEscalationRuleService, EscalationRuleService>();
            services.AddScoped<IAssignmentRuleService, AssignmentRuleService>();

            // 2.3 Services d'arrière-plan
            services.AddHostedService<EscalationBackgroundService>();

            // 2.4 Configuration de la base de données
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // 2.5 Configuration de l'identité
            services.AddDefaultIdentity<User>(options =>
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

            // 2.6 Configuration des Razor Pages et MVC
            services.AddRazorPages(options =>
            {
                options.Conventions.AddPageRoute("/Identity/Account/Register", "/Register");
            });
            services.AddControllersWithViews();

            // 2.7 Configuration de Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "QuantumDesk API",
                    Version = "v1",
                    Description = "API pour le système de ticketing QuantumDesk"
                });
            });

            // 2.8 Configuration générale
            services.AddSingleton<IConfiguration>(configuration);
        }

        private static void ConfigureMiddleware(WebApplication app)
        {
            // 3.1 Gestion des erreurs et sécurité
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuantumDesk API v1"));
            }

            // 3.2 Middleware HTTP
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // 3.3 Middleware de routage
            app.UseRouting();

            // 3.4 Middleware d'authentification et d'autorisation
            app.UseAuthentication();
            app.UseAuthorization();

            // 3.5 Mapping des routes
            // Ajoutez mapControllers avant mapRazorPages
            app.MapControllers();
            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }

        private static async Task InitializeDatabaseAsync(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await dbContext.Database.MigrateAsync();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

            // 4.1 Création des rôles
            var roles = new[] { "Admin", "SupportAgent", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new Role { Name = role });
                }
            }

            // 4.2 Création des utilisateurs par défaut
            await CreateDefaultUserAsync(userManager, "admin@admin.com", "Admin@123", "Admin", "User", "Admin");
            await CreateDefaultUserAsync(userManager, "system@quantumdesk.com", "SystemPassword123!", "System", "Automated", "Admin");
            await CreateDefaultUserAsync(userManager, "agent@quantumdesk.com", "Agent123!", "Support", "Agent", "SupportAgent");

            // 4.3 Création des données par défaut
            await CreateDefaultSupportTeamAsync(dbContext, userManager, "admin@admin.com", "agent@quantumdesk.com");
            await CreateDefaultAssignmentRuleAsync(dbContext);
        }

        private static async Task CreateDefaultUserAsync(UserManager<User> userManager, string email, string password, string firstName, string lastName, string role)
        {
            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new User
                {
                    UserName = email,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    EmailConfirmed = true,
                    IsActive = true
                };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }

        private static async Task CreateDefaultSupportTeamAsync(ApplicationDbContext dbContext, UserManager<User> userManager, string adminEmail, string agentEmail)
        {
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
        }

        private static async Task CreateDefaultAssignmentRuleAsync(ApplicationDbContext dbContext)
        {
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
    }
}
