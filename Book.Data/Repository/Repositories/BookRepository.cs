using Book.Data.Data;
using Book.Data.Repository.IRepository;
using Book.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Data.Repository.Repositories
{
    public class BookRepository : Repository<Books>, IBookRepository
    {
        public BookRepository(ApplicationDbContext db) : base(db)
        {
        }

        // you need IBookRepository if you add a custom methode like : GetAuthorsWithBooks();
    }
}
