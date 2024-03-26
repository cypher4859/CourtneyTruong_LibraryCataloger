using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibraryCataloger.Data;

//Open/Closed Principle: BookEntity is an example of this because it is open for extension but closed for modification because if i wanted to add a feature
//for the user to review a book after reading I could inherit the properties of BookEntity because in order to know what book the review is for you would also need all the
//info that is stored in the BookEntity but the Review class would hold extra properties that the parent class, BookEntity does not have, such as Review,
//Rating, etc.
public class BookEntity
{
    [Key] public int BookID { get; set; }
    [Required]
    [MinLength(1)]
    public string Title { get; set; }
    [Required]
    [MinLength(1)]
    public string Author { get; set; }
    public string? Description { get; set; }
    public string? Isbn {  get; set; }
    public bool ToBeReadList { get; set; }
    public bool InLibrary { get; set; }

}
