using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Moviely.Models
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        
        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Required]
        [Display(Name="Date Added")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name="Released Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name="Number in Stock")]
        public byte NumberInStock { get; set; }


    }
}