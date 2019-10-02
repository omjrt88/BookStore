using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BookStoreDesk.Models;
using BookStoreDesk.Utils;
using Newtonsoft.Json;

namespace Bookstore.Models
{
    public class ReviewViewModel
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public UserViewModel User { get; set; }

        [Required]
        public int BookId { get; set; }

        public BookViewModel Book { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yy}")]
        public DateTime Created { get; set; }

        [Required]
        public int Qualification { get; set; }

        public string QualificationDefinition
        {
            get
            {
                return Common.Reviews.FirstOrDefault(x => x.Value == this.Qualification).Key;
            }
        }

        [Required]
        public string Comment { get; set; }

        public ReviewViewModel()
        {
            this.Qualification = Common.Reviews["Excellent"];
        }

    }
}
