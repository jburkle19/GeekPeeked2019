using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekPeeked.Models
{
    public class ContestCategorySelection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ContestEntryId { get; set; }

        public int CategoryId { get; set; }

        public int NomineeId { get; set; }
    }
}