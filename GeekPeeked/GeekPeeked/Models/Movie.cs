using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekPeeked.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}