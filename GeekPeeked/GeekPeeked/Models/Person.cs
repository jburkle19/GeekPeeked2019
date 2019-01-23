using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekPeeked.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}