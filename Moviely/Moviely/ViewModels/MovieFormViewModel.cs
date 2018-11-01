using Moviely.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Moviely.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }


        public int? Id { get; set; }

        [Required(ErrorMessage = "Name of Movie is Required!")]
        [StringLength(255)]
        public string Name { get; set; }
        

        [Required(ErrorMessage = "Genre is Required!")]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }
    

        [Required(ErrorMessage = "Release Date is Required!")]
        [Display(Name = "Released Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "Number of Movies in Stock Required!")]
        [Display(Name = "Number in Stock")]
        [Range(1, 100)]
        public byte? NumberInStock { get; set; }



        public string Title
        {
            get
            {
                //OR return Id != 0 ? "Edit Movie" : "New Movie";
                if(Id != 0)
                {
                    return "Edit Movie";
                }
                else
                {
                    return "New Movie";

                }
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}