using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDB_TeacherVersion
{
    class Database
    {
        private SqlConnection conn;

        public Database()
        {
            //conn = new SqlConnection(@"");
            conn = new SqlConnection(@"Server = den1.mssql3.gear.host;
            Database = jac; User Id = jac; Password = tp%ipd12");
            conn.Open();
        }

        public int AddPerson(Person p)
        {
            string sql = "INSERT INTO People (Name, Age, Height) VALUES (@Name, @Age, @Height);  " +
                "SELECT CONVERT(int, SCOPE_IDENTITY());";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Age", p.Age);
                cmd.Parameters.AddWithValue("@Height", p.Height);
                int id = (int)cmd.ExecuteScalar();
                return id;
            }
        }

        public List<Person> GetAllPeople()
        {
            List<Person> result = new List<Person>();
            using (SqlCommand command = new SqlCommand("SELECT * FROM People", conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    string name = (string)reader["Name"];
                    int age = (int)reader["Age"];
                    double height = (double)reader["Height"];
                    Person p = new Person(id, name, age, height);
                    result.Add(p);
                }
            }
            return result;
        }


        internal void UpdatePerson(Person p)
        {
            string sql = "UPDATE People SET Name = @Name, Age = @Age, Height = @Height WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", p.Id);
            cmd.Parameters.AddWithValue("@Name", p.Name);
            cmd.Parameters.AddWithValue("@Age", p.Age);
            cmd.Parameters.AddWithValue("@Height", p.Height);
            cmd.ExecuteNonQuery();
        }

        internal void DeletePersonById(int id)
        {
            string sql = "DELETE FROM People WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
