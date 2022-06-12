using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMI.Model
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int YearOfRelease { get; set; }

        public string? Poster { get; set; }

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
