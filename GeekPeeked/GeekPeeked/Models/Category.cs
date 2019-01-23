using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekPeeked.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ContestId { get; set; }
        public virtual Contest Contests { get; set; }

        public string Title { get; set; } = string.Empty;
        public int PointValue { get; set; } = 0;
        public int SortOrder { get; set; } = 0;

        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}