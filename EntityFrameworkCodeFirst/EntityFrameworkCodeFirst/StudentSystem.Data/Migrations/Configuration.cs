namespace StudentSystem.Data.Migrations
{
    using StudentSystem.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            this.SeedCourses(context);
            this.SeedStudents(context);
        }

        private void SeedStudents(StudentSystemDbContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            context.Students.Add(new Student
            {
                Name = "Pesho1"
            });

            context.Students.Add(new Student
            {
                Name = "Pesho2"
            });

            context.Students.Add(new Student
            {
                Name = "Pesho3"
            });
        }

        private void SeedCourses(StudentSystemDbContext context)
        {
            if (context.Courses.Any())
            {
                return;
            }

            context.Courses.Add(new Course
            {
                Name = "CourseName1",
                Description = "Description1"
            });

            context.Courses.Add(new Course
            {
                Name = "CourseName2",
                Description = "Description2"
            });

            context.Courses.Add(new Course
            {
                Name = "CourseName3",
                Description = "Description3"
            });
        }
    }
}
