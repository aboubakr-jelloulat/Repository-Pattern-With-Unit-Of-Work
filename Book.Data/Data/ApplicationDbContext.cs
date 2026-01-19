using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Book.Models;

namespace Book.Data.Data;



/*
    db context in c# is a session with the database 
        the context object allow querying(for example linq methods )
        and saving data (CRUD operation ....).  
        its like a The manager between your C# code and the database 
        our application never talks directly to the database.
        It talks to DbContext, and DbContext talks to the database.

*/

// DbContext :=>   dotnet add package Microsoft.EntityFrameworkCore.SqlServer

// Migrations :=> dotnet add package Microsoft.EntityFrameworkCore.Tools
/*
    This is needed for:

        dotnet ef migrations
        dotnet ef database update

*/


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }


    public DbSet<Books> Books { get; set; }
    public DbSet<Author> Authors { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed Authors
        modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, Name = "J.K. Rowling" },
            new Author { Id = 2, Name = "J.R.R. Tolkien" }
        );

        // Seed Books
        modelBuilder.Entity<Books>().HasData(
            new Books { Id = 1, Title = "Harry Potter", Price = 20m, AuthorId = 1 },
            new Books { Id = 2, Title = "LOTR", Price = 25m, AuthorId = 2 }
        );
    }



}


