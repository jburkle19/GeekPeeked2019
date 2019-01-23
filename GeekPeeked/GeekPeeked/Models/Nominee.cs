using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekPeeked.Models
{
    public class Nominee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int? MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public int? PersonId { get; set; }
        public virtual Person Person { get; set; }

        public string SongTitle { get; set; }
        public int SortOrder { get; set; }

        public bool IsWinner { get; set; }
    }
}