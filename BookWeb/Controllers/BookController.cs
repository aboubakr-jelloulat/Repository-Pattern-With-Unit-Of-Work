using Book.Data.Repository.IRepository;
using Book.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookWeb.Controllers;


[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public BookController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public IActionResult Create([FromBody] Books book)
    {
        _unitOfWork.Book.Add(book);
        _unitOfWork.Save();

        return Ok(book);
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        var books = _unitOfWork.Book.GetAll(includeProperties: "Author"); // include Author

        return Ok(books);
    }


    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var book = _unitOfWork.Book.Get(b => b.Id == id, includeProperties: "Author", tracked: false);

        if (book is null)
            return NotFound();
        return Ok(book);
    }


    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Books updatedBook)
    {
        if (id != updatedBook.Id)
            return BadRequest("ID mismatch");

        var book = _unitOfWork.Book.Get(b => b.Id == id, tracked: true);
        if (book is null)
            return NotFound();

        book.Title = updatedBook.Title;
        book.Price = updatedBook.Price;
        book.AuthorId = updatedBook.AuthorId;

        _unitOfWork.Save();

        return NoContent();
    }



    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var book = _unitOfWork.Book.Get(b => b.Id == id, tracked: true);
        if (book is null) 
            return NotFound();

        _unitOfWork.Book.Remove(book);
        _unitOfWork.Save();

        return NoContent();
    }
}
