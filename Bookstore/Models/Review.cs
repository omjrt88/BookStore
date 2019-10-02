using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Common;
using Newtonsoft.Json;

namespace Bookstore.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        //[JsonIgnore]
        public User User { get; set; }

        [Required]
        public int BookId { get; set; }
        //[JsonIgnore]
        public Book Book { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public int Qualification { get; set; }

        [Required]
        public string Comment { get; set; }

        public Review()
        {
            this.Qualification = DictionaryData.Reviews["Excellent"];
        }
    }
}
