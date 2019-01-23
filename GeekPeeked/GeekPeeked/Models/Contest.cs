using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekPeeked.Models
{
    public enum ContestType
    {
        BoxOffice,
        AcademyAwardsBallot
    }

    public class Contest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public ContestType ContestType { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Objective { get; set; } = string.Empty;
        public string Rules { get; set; } = string.Empty;

        public DateTime Signup { get; set; }
        public DateTime SignupEnd { get; set; }
        public DateTime Start { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}