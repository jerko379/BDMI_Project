using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace BDMI.Model
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year of release should be between 1900 and 2100")]
        [Range(1900, 2100, ErrorMessage = "Year of release should be between 1900 and 2100")]
        public int YearOfRelease { get; set; }

        public string? Poster { get; set; }

        [Required (ErrorMessage = "IMDB rating should be between 0 and 10")]
        [Range (0.0, 10.0, ErrorMessage = "IMDB rating should be between 0 and 10")]
        public double? ImdbRating { get; set; }

        public double? AverageRating { get; set; }

        public string? Link { get; set; }


        [ForeignKey(nameof(Director))]
        public int? DirectorId { get; set; }
        public Director? Director { get; set; }

        [ForeignKey(nameof(Genre))]
        public int? GenreId { get; set; }
        public Genre? Genre { get; set; }

    }
}
