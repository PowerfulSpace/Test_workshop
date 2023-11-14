using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Test_ConnectToDb;

public partial class TestBaseProjectDbContext : DbContext
{
    public TestBaseProjectDbContext()
    {
    }

    public TestBaseProjectDbContext(DbContextOptions<TestBaseProjectDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Test_BaseProject_DB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
