using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BooksSeller.WebApi.Models
{
    [Table("books")]
    public class Book
    {
        [Key]
        [Index(IsUnique = true)]
        [Required (ErrorMessage = "Code cannot be null or empty", AllowEmptyStrings =false)]
        //TODO - Write a Implementation to AutoFixture supports regex
        //[RegularExpression(pattern: "/^[A-Z]{3}[-][0-9]{4}$/", ErrorMessage = "The Code must be provided on the format ABC-1234")]
        public string Code { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Title cannot be null or empty")]
        [MaxLength(100,ErrorMessage = "The limit of characters to create a book title is 100, please, provide a shorter title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author cannot be null or empty", AllowEmptyStrings = false)]
        public string Author { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Rating { get; set; }

    }
}