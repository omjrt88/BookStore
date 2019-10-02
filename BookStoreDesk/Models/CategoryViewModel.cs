using System.ComponentModel.DataAnnotations;

namespace BookStoreDesk.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<Book> Books { get; set; }

        public CategoryViewModel()
        {
            //this.Books = new HashSet<Book>();
        }
    }
}
