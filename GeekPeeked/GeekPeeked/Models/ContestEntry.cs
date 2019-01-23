using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GeekPeeked.Models
{
    public class ContestEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int ContestId { get; set; }

        public DateTime Created { get; set; }

        //public virtual ICollection<ContestCategorySelection> ContestCategorySelections { get; set; }
    }
}