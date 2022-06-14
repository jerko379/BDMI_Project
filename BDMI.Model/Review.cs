using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMI.Model
{
    public class Review
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Title should be at least 10 characters long")]
        [MaxLength(50 , ErrorMessage = "Title should be maximum  5 characters long")]
        public string Title { get; set; }

        [Required]
        [MinLength(20, ErrorMessage = "Content should be at least 20 characters long")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Rating should be between 0 and 10")]
        [Range(0.0, 10.0, ErrorMessage = "Rating should be between 0 and 10")]
        public double Rating { get; set; }

        [ForeignKey(nameof(Movie))]
        public int? MovieId { get; set; }
        public Movie? Movie { get; set; }

        public string? CreatedByUserId { get; set; }
        public string? CreatedByUserNickname { get; set; }
    }
}
