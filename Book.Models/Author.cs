using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Book.Models;
public class Author
{
    [Key]
    public int Id { get; set; }


    public required string Name { get; set; } = null!;

    public ICollection<Books>? Books { get; set; }
}

