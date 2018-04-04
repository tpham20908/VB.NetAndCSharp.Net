using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPeople
{
    class PeopleDbContext : DbContext
    {
        public PeopleDbContext() : base("name=EFPeopleDatabase")
        {

        }
        public virtual DbSet<Person> People { get; set; }
    }
}
