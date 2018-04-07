using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPeopleAgain
{
    class Person
    {
        [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        [Column("NameOfPerson")]
        public string Name { get; set; }
        [Required]
        [Column("AgeOfPerson")]
        public int Age { get; set; }
        [Required]
        [Column("HeightOfPerson")]
        public double Height { get; set; }

        public override string ToString()
        {
            return string.Format("Person #{0}: Name {1}, Age {2}, Height {3:0.00}", Id, Name, Age, Height);
        }
    }
}
