using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ticketing_System.Models;

namespace Ticketing_System
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TicketCategory> TicketCategories { get; set; }
        public DbSet<TicketPriority> TicketPriorities { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<SupportTeam> SupportTeams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketComment> TicketComments { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<TicketHistory> TicketHistory { get; set; }
        public DbSet<AssignmentRule> AssignmentRules { get; set; }
        public DbSet<EscalationRule> EscalationRules { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<KnowledgeBaseArticle> KnowledgeBaseArticles { get; set; }
        public DbSet<UserPreference> UserPreferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurer les clés composites
            modelBuilder.Entity<TeamMember>()
                .HasKey(tm => new { tm.TeamID, tm.UserID });

            // Configurer les relations
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.CreatedByUser)
                .WithMany(u => u.CreatedTickets)
                .HasForeignKey(t => t.CreatedByUserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.AssignedToUser)
                .WithMany(u => u.AssignedTickets)
                .HasForeignKey(t => t.AssignedToUserID)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            modelBuilder.Entity<TicketCategory>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.ChildCategories)
                .HasForeignKey(c => c.ParentCategoryID)
                .IsRequired(false);

            modelBuilder.Entity<Attachment>()
                .HasOne(a => a.Comment)
                .WithMany(c => c.Attachments)
                .HasForeignKey(a => a.CommentID)
                .IsRequired(false);

            modelBuilder.Entity<AssignmentRule>()
                .HasKey(ar => ar.RuleID);

            modelBuilder.Entity<EscalationRule>()
                .HasKey(ar => ar.RuleID);

            modelBuilder.Entity<KnowledgeBaseArticle>()
               .HasKey(ar => ar.ArticleID);

            modelBuilder.Entity<SupportTeam>()
                .HasKey(st => st.TeamID);

            

            modelBuilder.Entity<TicketPriority>()
                .HasKey(tp => tp.PriorityID);

            modelBuilder.Entity<TicketStatus>()
                .HasKey(ts => ts.StatusID);

            modelBuilder.Entity<TicketComment>()
                .HasKey(ts => ts.CommentID);

            modelBuilder.Entity<TicketHistory>()
                .HasKey(th => th.HistoryID);

            modelBuilder.Entity<Notification>()
                .HasKey(n => n.NotificationID);

            modelBuilder.Entity<UserPreference>()
                .HasKey(up => up.UserID);

           



            // Index
            modelBuilder.Entity<Ticket>()
                .HasIndex(t => t.StatusID);

            modelBuilder.Entity<Ticket>()
                .HasIndex(t => t.PriorityID);

            modelBuilder.Entity<Ticket>()
                .HasIndex(t => t.CategoryID);

            modelBuilder.Entity<Ticket>()
                .HasIndex(t => t.AssignedToUserID);

            modelBuilder.Entity<Ticket>()
                .HasIndex(t => t.AssignedToTeamID);

            modelBuilder.Entity<Ticket>()
                .HasIndex(t => t.CreatedDate);

            modelBuilder.Entity<Ticket>()
                .HasIndex(t => t.DueDate);

            modelBuilder.Entity<TicketComment>()
                .HasIndex(tc => tc.TicketID);

            modelBuilder.Entity<TicketHistory>()
                .HasIndex(th => th.TicketID);

            modelBuilder.Entity<Notification>()
                .HasIndex(n => n.UserID);

            modelBuilder.Entity<Notification>()
                .HasIndex(n => n.IsRead);

            // Configuration des données initiales
            SeedInitialData(modelBuilder);
        }

        private void SeedInitialData(ModelBuilder modelBuilder)
        {
            // Initialiser les statuts des tickets
            modelBuilder.Entity<TicketStatus>().HasData(
                new TicketStatus { StatusID = 1, StatusName = "New", Description = "Ticket nouvellement créé", IsClosedStatus = false },
                new TicketStatus { StatusID = 2, StatusName = "In Progress", Description = "Ticket en cours de traitement par un agent", IsClosedStatus = false },
                new TicketStatus { StatusID = 3, StatusName = "On Hold", Description = "Ticket en attente d'information ou d'action", IsClosedStatus = false },
                new TicketStatus { StatusID = 4, StatusName = "Resolved", Description = "Ticket résolu mais en attente de confirmation", IsClosedStatus = false },
                new TicketStatus { StatusID = 5, StatusName = "Closed", Description = "Ticket fermé et complété", IsClosedStatus = true },
                new TicketStatus { StatusID = 6, StatusName = "Cancelled", Description = "Ticket annulé", IsClosedStatus = true }
            );

            // Initialiser les priorités des tickets
            modelBuilder.Entity<TicketPriority>().HasData(
                new TicketPriority { PriorityID = 1, PriorityName = "Low", Description = "Problème mineur sans impact significatif", SLAResponseHours = 24, SLAResolutionHours = 72 },
                new TicketPriority { PriorityID = 2, PriorityName = "Medium", Description = "Problème avec impact limité", SLAResponseHours = 12, SLAResolutionHours = 48 },
                new TicketPriority { PriorityID = 3, PriorityName = "High", Description = "Problème avec impact important", SLAResponseHours = 4, SLAResolutionHours = 24 },
                new TicketPriority { PriorityID = 4, PriorityName = "Critical", Description = "Problème urgent avec impact majeur", SLAResponseHours = 1, SLAResolutionHours = 8 }
            );
        }

    }
}
    
