using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace truck_maintenance_schedule_api.Models;

public partial class ScheduleMaintenanceContext : DbContext
{
    public ScheduleMaintenanceContext()
    {
    }

    public ScheduleMaintenanceContext(DbContextOptions<ScheduleMaintenanceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Maintenance> Maintenances { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Truck> Trucks { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=schedule_maintenance;user id= sa; password=sa123456;Encrypt=False;");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Maintenance>(entity =>
        {
            entity.ToTable("maintenance");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Maintenance1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("maintenance");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.ToTable("schedule");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dispatcher)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dispatcher");
            entity.Property(e => e.Driver)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("driver");
            entity.Property(e => e.Duedate)
                .HasColumnType("date")
                .HasColumnName("duedate");
            entity.Property(e => e.Mechanic)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mechanic");
            entity.Property(e => e.Truck)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("truck");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Truck>(entity =>
        {
            entity.ToTable("truck");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Truck1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("truck");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
