using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Testing.Models
{
    public partial class FlightTicketDbContext : DbContext
    {
        public FlightTicketDbContext()
        {
        }

        public FlightTicketDbContext(DbContextOptions<FlightTicketDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AirlineTbl> AirlineTbls { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<BookflightTbl> BookflightTbls { get; set; }
        public virtual DbSet<FlightDetail> FlightDetails { get; set; }
        public virtual DbSet<InventoryTbl> InventoryTbls { get; set; }
        public virtual DbSet<TesTbl> TesTbls { get; set; }
        public virtual DbSet<UserDetailTbl> UserDetailTbls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CTSDOTNET022;Initial Catalog=FlightTicketDb;Persist Security Info=True;User ID=sa;Password=pass@word1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AirlineTbl>(entity =>
            {
                entity.HasKey(e => e.AirlineNo);

                entity.ToTable("airlineTbls");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<BookflightTbl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("bookflightTbl");

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.FlightNumber).HasMaxLength(50);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Meal).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PersonId).HasColumnName("personId");

                entity.Property(e => e.Pnr).HasMaxLength(50);
            });

            modelBuilder.Entity<FlightDetail>(entity =>
            {
                entity.ToTable("flightDetail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.SeatNo).HasColumnName("seatNo");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<InventoryTbl>(entity =>
            {
                entity.HasKey(e => e.FlightNumber);

                entity.ToTable("inventoryTbls");

                entity.HasIndex(e => e.AirlineNo, "IX_inventoryTbls_AirlineNo");

                entity.Property(e => e.AirlineNo).IsRequired();

                entity.Property(e => e.TicketCost).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.AirlineNoNavigation)
                    .WithMany(p => p.InventoryTbls)
                    .HasForeignKey(d => d.AirlineNo);
            });

            modelBuilder.Entity<TesTbl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TesTbl");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<UserDetailTbl>(entity =>
            {
                entity.HasKey(e => e.PeopleId);

                entity.ToTable("UserDetailTbl");

                entity.Property(e => e.Age)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Class).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
