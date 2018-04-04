using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDB_TeacherVersion
{
    class Person
    {
        public Person(int id, string name, int age, double height)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Height = height;
        }

        public int Id;
        public string Name;
        public int Age;
        public double Height;

        public override string ToString()
        {
            return string.Format("{0}: {1} is {2} y/o, {3:0.0}cm heigh", Id, Name, Age, Height);
        }
    }
}
