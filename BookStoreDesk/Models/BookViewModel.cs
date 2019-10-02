using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;
using BookStoreDesk.Models;

namespace BookStoreDesk.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yy}")]
        public DateTime Published { get; set; }
        public int CategoryId { get; set; }
        //[JsonIgnore]
        public CategoryViewModel Category { get; set; }
        //[JsonIgnore]
        public virtual ICollection<ReviewViewModel> Reviews { get; set; }
        [Required]
        public int AuthorId { get; set; }
        //[JsonIgnore]
        public AuthorViewModel Author { get; set; }

        public int ReviewsSum { get; set; }

        public BookViewModel()
        {
            this.Reviews = new HashSet<ReviewViewModel>();
        }

    }
}