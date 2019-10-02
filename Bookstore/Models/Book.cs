using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Published { get; set; }
        public int CategoryId { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Category Category { get; set; }
        [JsonIgnore]
        public virtual ICollection<Review> Reviews { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Author Author { get; set; }

        public Book()
        {
            this.Reviews = new HashSet<Review>();
        }

    }
}