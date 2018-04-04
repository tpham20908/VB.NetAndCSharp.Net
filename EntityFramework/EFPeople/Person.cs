using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EFPeople
{
    class Person
    {
        [Key]
        public int PersonId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
