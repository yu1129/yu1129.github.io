using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CatchTimeTable.DataModel;

public partial class TimeDataContext : DbContext
{
    public TimeDataContext()
    {
    }

    public TimeDataContext(DbContextOptions<TimeDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TimeTable> TimeTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Database=TimeData;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TimeTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TimeTable_1");

            entity.ToTable("TimeTable");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Car)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.RouteId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("RouteID");
            entity.Property(e => e.Stop)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Time)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
