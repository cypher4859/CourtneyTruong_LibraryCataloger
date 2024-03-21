using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibraryCataloger.Data;

public class BookEntity
{
    [Key] public int BookID { get; set; }
    [Required]
    [MinLength(1)]
    public string Title { get; set; }
    [Required]
    [MinLength(1)]
    public string Author { get; set; }
    [MaxLength(200)]
    public string Description { get; set; }
    public string Isbn {  get; set; }
    public bool ToBeReadList { get; set; }
    public bool InLibrary { get; set; }

}
