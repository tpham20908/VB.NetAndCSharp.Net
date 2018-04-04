using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPeople
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Person p1 = new Person() { Name = "Peter", Age = r.Next(1, 150) };
            Person p2 = new Person() { Name = "Felix", Age = r.Next(1, 150) };
            Person p3 = new Person() { Name = "Caroline", Age = r.Next(1, 150) };
            

            using (PeopleDbContext ctx = new PeopleDbContext())
            {
                ctx.People.Add(p1);  // persist - schedule Person to be inserted into databse table
                ctx.People.Add(p2);
                ctx.People.Add(p3);

                ctx.SaveChanges();  // flush - force all scheduled operations to be carried out in database

                Console.WriteLine("Person persitsted");

                var people = (from record in ctx.People select record).ToList();
                foreach (var pp in people)
                {
                    Console.WriteLine("P{0}: Name {1}, Age {2}", pp.PersonId, pp.Name, pp.Age);
                }

                Console.ReadLine();
            }
        }
    }
}
