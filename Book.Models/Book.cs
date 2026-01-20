using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Book.Models;

public class Books
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }

    public int AuthorId { get; set; }
    public Author? Author { get; set; }
}

