using Book.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Data.Repository.IRepository
{
    public interface IBookRepository : IRepository<Books>
    {
        /*
         * you can add custom methods only for Book like:
                GetBookByAuthor(string name)
        */
    }
}
