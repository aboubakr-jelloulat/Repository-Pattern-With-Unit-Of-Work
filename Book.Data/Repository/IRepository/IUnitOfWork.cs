using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IBookRepository     Book { get; }
        IAuthorRepository   Author { get; }


        void Save();
        Task Saveasync();

        /*
         Think of UnitOfWork as a transaction manager.

            It collects changes from multiple repositories.
            It saves all changes at once to the database.
            Makes sure everything succeeds or fails together
         */



        /*
         Without UnitOfWork:

            authorRepo.Add(author);
            bookRepo.Add(book);
            dbContext.SaveChanges(); // two separate operations


            If one fails, you might leave the DB in an inconsistent state.

            With UnitOfWork:

            _unitOfWork.Author.Add(author);
            _unitOfWork.Book.Add(book);
            _unitOfWork.Save(); // saves both in one transaction


            Cleaner, safer, and professional.
         */
    }
}
