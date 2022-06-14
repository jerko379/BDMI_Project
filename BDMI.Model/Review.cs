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
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public double Rating { get; set; }

        [ForeignKey(nameof(Movie))]
        public int? MovieId { get; set; }
        public Movie? Movie { get; set; }

        public string? CreatedByUserId { get; set; }
        public string? CreatedByUserNickname { get; set; }
    }
}
