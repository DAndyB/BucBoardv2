using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace bucboardv2.Models.Entities
{
    public partial class BucboardContext : DbContext
    {
        public BucboardContext()
        {
        }

        public BucboardContext(DbContextOptions<BucboardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calendar> Calendar { get; set; }
        public virtual DbSet<CustomEvents> CustomEvents { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Premade> Premade { get; set; }
        public virtual DbSet<Recurring> Recurring { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calendar>(entity =>
            {
                entity.Property(e => e.CalendarId).HasColumnName("calendarID");

                entity.Property(e => e.Month)
                    .HasColumnName("month")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Calendar)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Calendar__userID__4BAC3F29");
            });

            modelBuilder.Entity<CustomEvents>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.Property(e => e.EventId)
                    .HasColumnName("eventID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EventType).HasColumnName("eventType");

                entity.Property(e => e.IsAvalible).HasColumnName("isAvalible");

                entity.HasOne(d => d.Event)
                    .WithOne(p => p.CustomEvents)
                    .HasForeignKey<CustomEvents>(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomEve__event__571DF1D5");
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.Property(e => e.EventId).HasColumnName("eventID");

                entity.Property(e => e.CalendarId).HasColumnName("calendarID");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.EndTime)
                    .HasColumnName("endTime")
                    .HasColumnType("date");

                entity.Property(e => e.EventName)
                    .HasColumnName("eventName")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .HasColumnName("startTime")
                    .HasColumnType("date");

                entity.HasOne(d => d.Calendar)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CalendarId)
                    .HasConstraintName("FK__Events__calendar__4E88ABD4");
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.Property(e => e.MessageId).HasColumnName("messageID");

                entity.Property(e => e.Body)
                    .HasColumnName("body")
                    .HasColumnType("text");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.EventId).HasColumnName("eventID");

                entity.Property(e => e.Reciever)
                    .HasColumnName("reciever")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Sender)
                    .HasColumnName("sender")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__Messages__eventI__59FA5E80");
            });

            modelBuilder.Entity<Premade>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.Property(e => e.EventId)
                    .HasColumnName("eventID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EventType).HasColumnName("eventType");

                entity.HasOne(d => d.Event)
                    .WithOne(p => p.Premade)
                    .HasForeignKey<Premade>(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Premade__eventID__5441852A");
            });

            modelBuilder.Entity<Recurring>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.Property(e => e.EventId)
                    .HasColumnName("eventID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IsAvalible).HasColumnName("isAvalible");

                entity.HasOne(d => d.Event)
                    .WithOne(p => p.Recurring)
                    .HasForeignKey<Recurring>(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Recurring__event__5165187F");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.OfficeNumber).HasColumnName("officeNumber");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });
        }
    }
}
