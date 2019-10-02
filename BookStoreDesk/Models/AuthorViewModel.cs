using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreDesk.Models
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yy}")]
        public DateTime Birthday { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<Book> Books { get; set; }

        public AuthorViewModel()
        {
            //this.Books = new HashSet<Book>();
        }
    }
}