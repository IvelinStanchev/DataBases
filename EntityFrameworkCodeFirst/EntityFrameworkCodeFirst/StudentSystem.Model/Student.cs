using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Model
{
    public class Student
    {
        public Student()
        {
            this.Homeworks = new HashSet<Homework>();
            this.Courses = new HashSet<Course>();
        }

        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; }

        public int Number { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
