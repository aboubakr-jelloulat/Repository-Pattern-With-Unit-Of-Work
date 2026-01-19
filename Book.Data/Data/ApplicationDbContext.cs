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



}


