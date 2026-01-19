using Book.Data.Data;
using Book.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Data.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;


        public IBookRepository Book { get; private set; }

        public IAuthorRepository Author { get; private set; }


        public UnitOfWork(ApplicationDbContext db)
        {
            _db     = db;

            Book    = new BookRepository(_db);
            Author = new AuthorRepository(_db); 
        }
        public void Save() => _db.SaveChanges();


        public Task Saveasync() => _db.SaveChangesAsync();

        
    }
}
