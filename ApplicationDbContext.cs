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

        // DbSet des entités du système de ticketing
        public DbSet<SupportTeam> SupportTeams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketComment> TicketComments { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<TicketHistory> TicketHistories { get; set; }
        public DbSet<AssignmentRule> AssignmentRules { get; set; }
        public DbSet<EscalationRule> EscalationRules { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<KnowledgeBaseArticle> KnowledgeBaseArticles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // IMPORTANT : Appeler d'abord la configuration d’Identity
            base.OnModelCreating(modelBuilder);

            // --------------------------
            // Configuration des relations
            // --------------------------

            modelBuilder.Entity<TeamMember>()
            .HasOne(tm => tm.Team)
            .WithMany(st => st.TeamMembers)
            .HasForeignKey(tm => tm.TeamID)
            .OnDelete(DeleteBehavior.Restrict);

            // SupportTeam -> TeamMembers
            modelBuilder.Entity<SupportTeam>()
                .HasMany(st => st.TeamMembers)
                .WithOne(tm => tm.Team)
                .HasForeignKey(tm => tm.TeamID)
                .OnDelete(DeleteBehavior.NoAction);

            // SupportTeam -> AssignedTickets
            modelBuilder.Entity<SupportTeam>()
                .HasMany(st => st.AssignedTickets)
                .WithOne(t => t.AssignedToTeam)
                .HasForeignKey(t => t.AssignedToTeamID)
                .OnDelete(DeleteBehavior.NoAction);

            // User -> CreatedTickets
            modelBuilder.Entity<User>()
                .HasMany(u => u.CreatedTickets)
                .WithOne(t => t.CreatedByUser)
                .HasForeignKey(t => t.CreatedByUserId)
                .OnDelete(DeleteBehavior.NoAction);

            // User -> AssignedTickets
            modelBuilder.Entity<User>()
                .HasMany(u => u.AssignedTickets)
                .WithOne(t => t.AssignedToUser)
                .HasForeignKey(t => t.AssignedToUserId)
                .OnDelete(DeleteBehavior.NoAction);

            // User -> ManagedTeams
            modelBuilder.Entity<User>()
                .HasMany(u => u.ManagedTeams)
                .WithOne(st => st.Manager)
                .HasForeignKey(st => st.ManagerId)
                .OnDelete(DeleteBehavior.NoAction);

            // User -> TeamMemberships
            modelBuilder.Entity<User>()
                .HasMany(u => u.TeamMemberships)
                .WithOne(tm => tm.User)
                .HasForeignKey(tm => tm.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // User -> Comments (TicketComments)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(tc => tc.User)
                .HasForeignKey(tc => tc.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // User -> Attachments
            modelBuilder.Entity<User>()
                .HasMany(u => u.Attachments)
                .WithOne(a => a.Uploader)
                .HasForeignKey(a => a.UploaderUserId)
                .OnDelete(DeleteBehavior.NoAction);

            // User -> KnowledgeBaseArticles
            modelBuilder.Entity<User>()
                .HasMany(u => u.Articles)
                .WithOne(kba => kba.Author)
                .HasForeignKey(kba => kba.AuthorID)
                .OnDelete(DeleteBehavior.NoAction);

            // User -> Notifications
            modelBuilder.Entity<User>()
                .HasMany(u => u.Notifications)
                .WithOne(n => n.User)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Ticket -> TicketComments
            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.TicketComments)
                .WithOne(tc => tc.Ticket)
                .HasForeignKey(tc => tc.TicketID)
                .OnDelete(DeleteBehavior.NoAction);

            // Ticket -> TicketAttachments (ici, la DbSet Attachments correspond aux pièces jointes)
            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.TicketAttachments)
                .WithOne(a => a.Ticket)
                .HasForeignKey(a => a.TicketID)
                .OnDelete(DeleteBehavior.NoAction);

            // AssignmentRule -> AssignToTeam
            modelBuilder.Entity<AssignmentRule>()
                .HasOne(ar => ar.AssignToTeam)
                .WithMany()
                .HasForeignKey(ar => ar.AssignToTeamID)
                .OnDelete(DeleteBehavior.NoAction);

            // AssignmentRule -> AssignToUser
            modelBuilder.Entity<AssignmentRule>()
                .HasOne(ar => ar.AssignToUser)
                .WithMany()
                .HasForeignKey(ar => ar.AssignToUserID)
                .OnDelete(DeleteBehavior.NoAction);

            // EscalationRule -> EscalateToTeam
            modelBuilder.Entity<EscalationRule>()
                .HasOne(er => er.EscalateToTeam)
                .WithMany()
                .HasForeignKey(er => er.EscalateToTeamID)
                .OnDelete(DeleteBehavior.NoAction);

            // EscalationRule -> EscalateToUser
            modelBuilder.Entity<EscalationRule>()
                .HasOne(er => er.EscalateToUser)
                .WithMany()
                .HasForeignKey(er => er.EscalateToUserID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
