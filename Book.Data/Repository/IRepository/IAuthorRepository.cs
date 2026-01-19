using Book.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Data.Repository.IRepository
{
    public interface IAuthorRepository : IRepository<Author>
    {
        /*
         * you can add custom methods only for Author like:
                GetAuthorsWithBooks()
                GetAuthorByName(string name)
        */


    }
}
