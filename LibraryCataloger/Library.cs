using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCataloger
{
     public class Library : Book
    {
        public bool InLibrary { get; set; }
        public string Isbn {  get; set; }
        public string Description { get; set; }
    }
}
