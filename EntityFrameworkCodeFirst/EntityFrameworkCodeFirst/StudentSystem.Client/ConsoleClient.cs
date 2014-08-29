using StudentSystem.Data;
using StudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Client
{
    public class ConsoleClient
    {
        public static void Main()
        {
            var data = new StudentSystemDbContext();

            data.Courses.Add(new Course
            {
                Name = "Repo Pattern 2",
                Description = "Cool"
            });

            data.SaveChanges();

            var courses = data.Courses.Where(x => x.Description == "Cool");

            foreach (var course in courses)
            {
                Console.WriteLine(course.Name);
            }
        }
    }
}
