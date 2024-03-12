using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibraryCataloger.Data
{
    public class BookEntity
    {
        [Key] public int BookID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public string Description { get; set; }
        public string Isbn {  get; set; }
        public bool ToBeReadList { get; set; }
        public bool InLibrary { get; set; }

    }
}
