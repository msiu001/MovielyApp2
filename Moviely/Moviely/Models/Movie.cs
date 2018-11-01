using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Moviely.Models
{
    public class Movie
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Name of Movie is Required!")]
        [StringLength(255)]
        public string Name { get; set; }

        
        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Genre is Required!")]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Required(ErrorMessage = "Date Added is Required!")]
        [Display(Name="Date Added")]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "Release Date is Required!")]
        [Display(Name="Released Date")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Number of Movies in Stock Required!")]
        [Display(Name="Number in Stock")]
        [Range(1, 100)]
        public byte NumberInStock { get; set; }


    }
}