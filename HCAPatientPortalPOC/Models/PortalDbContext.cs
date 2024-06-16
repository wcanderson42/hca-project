namespace HCAPatientPortalPOC.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class PortalDbContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Provider> Providers { get; set; }

    public string DbPath { get; }

    public PortalDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "portal.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}