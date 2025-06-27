using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KursProjectISP31.Model;

public partial class KursovayaContext : DbContext
{
    public KursovayaContext()
    {
        Database.EnsureCreated();
    }

    public KursovayaContext(DbContextOptions<KursovayaContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<RouteSheet> RouteSheets { get; set; }
    public virtual DbSet<FlightData> FlightData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=Kursovaya.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RouteSheet>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("RouteSheet");
        });

        modelBuilder.Entity<FlightData>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("FlightData");

            entity.HasIndex(e => e.FlightNumber, "IX_FlightData_FlightNumber");

            entity.HasOne(d => d.RouteSheet)
                .WithMany(p => p.FlightData)
                .HasForeignKey(d => d.FlightNumber)
                .HasPrincipalKey(p => p.FlightNumber)
                .OnDelete(DeleteBehavior.Restrict);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}