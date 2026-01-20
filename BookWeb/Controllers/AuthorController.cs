namespace BookWeb.Controllers;


using Book.Models;
using Book.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public AuthorController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public IActionResult Create([FromBody] Author author)
    {
        _unitOfWork.Author.Add(author);
        _unitOfWork.Save();

        return Ok(author);
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        var authors = _unitOfWork.Author.GetAll(includeProperties: "Books"); // include Books

        return Ok(authors);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var author = _unitOfWork.Author.Get(a => a.Id == id, includeProperties: "Books", tracked: false);
        if (author is null)
            return NotFound();

        return Ok(author);
    }


    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Author updatedAuthor)
    {
        var author = _unitOfWork.Author.Get(a => a.Id == id, tracked: true); // tracked: true
        if (author is null) 
            return NotFound();

        author.Name = updatedAuthor.Name;

        _unitOfWork.Save();

        return Ok(author);
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var author = _unitOfWork.Author.Get(a => a.Id == id, tracked: true);
        if (author is null) 
            return NotFound();

        _unitOfWork.Author.Remove(author);
        _unitOfWork.Save();
        return NoContent();
    }
}


