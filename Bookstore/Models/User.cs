 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
 using Newtonsoft.Json;

 namespace Bookstore.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [JsonIgnore]
        public virtual ICollection<Review> Reviews { get; set; }

        public User()
        {
            this.Reviews = new HashSet<Review>();
        }

    }
}
