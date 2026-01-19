using Book.Data.Data;
using Book.Data.Repository.IRepository;
using Book.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Data.Repository.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        //private readonly ApplicationDbContext _db;


        // we need ctor because Repository<Author> need a ApplicationDbContext db via Dependency Injection (DI)
        public AuthorRepository(ApplicationDbContext db) : base(db)
        {
            //_db = db;
        }

        
    }
}
