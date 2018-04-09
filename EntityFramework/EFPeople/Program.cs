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
            Random rand = new Random();
            Person p1 = new Person() { Name = "Peter", Age = rand.Next(1, 150) };
            Person p2 = new Person() { Name = "Felix", Age = rand.Next(1, 150) };
            Person p3 = new Person() { Name = "Caroline", Age = rand.Next(1, 150) };
            

            using (PeopleDbContext ctx = new PeopleDbContext())
            {
                
                ctx.People.Add(p1);  // persist - schedule Person to be inserted into databse table
                ctx.People.Add(p2);
                ctx.People.Add(p3);
                
                Console.WriteLine("Person persitsted");
                

                // update (select then update)
                var people2 = (from r in ctx.People where r.PersonId >= 7 select r).ToList();
                if (people2.Count == 0)
                {
                    Console.WriteLine("Record for update not found.");
                } else
                {
                    //Person p = people2[0];
                    foreach (Person p in people2)
                    {
                        Console.WriteLine("This person will be updated:");
                        Console.WriteLine("P{0}: Name {1}, Age {2}", p.PersonId, p.Name, p.Age);
                        p.Name += "ito";
                        p.Age = rand.Next(1, 100);
                    }
                }

                /*
                Person p33 = new Person { PersonId = 33 };
                Console.WriteLine("Deletion before attaching: P({0}): {1}, {2}", p33.PersonId, p33.Name, p33.Age);
                ctx.People.Attach(p33);
                Console.WriteLine("Deletion after attaching: P({0}): {1}, {2}", p33.PersonId, p33.Name, p33.Age);
                ctx.People.Remove(p33);
                if (ctx.Entry(p33).State != System.Data.Entity.EntityState.Deleted)
                { // success
                    ctx.SaveChanges();
                    Console.WriteLine("Record #3 delected");
                } else
                { // failed - record to delete not found
                    Console.WriteLine("Record #3 to delete - not found, not deleted");
                }
                */

                // select then delete
                Console.WriteLine("Delection method 2");
                var people3 = (from r in ctx.People where r.PersonId == 9 select r).ToList();
                if (people3.Count == 0)
                {
                    Console.WriteLine("Record for deletion not found");
                }
                else
                {
                    Person p = people3[0];
                    ctx.People.Remove(p);
                    ctx.SaveChanges();
                    Console.WriteLine("Delection method 2 succedded.");
                }

                var people = (from record in ctx.People select record).ToList();
                foreach (var pp in people)
                {
                    Console.WriteLine("P{0}: Name {1}, Age {2}", pp.PersonId, pp.Name, pp.Age);
                }
                ctx.SaveChanges();  // flush - force all scheduled operations to be carried out in database
                Console.ReadLine();
            }
        }
    }
}
