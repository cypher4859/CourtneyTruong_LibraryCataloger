using LibraryCataloger.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;



public class BookDbContext : DbContext
{
    public DbSet<BookEntity> Books { get; set; }

    public string DbPath { get; }

    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "Books.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}