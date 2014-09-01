using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.Models;

namespace TelerikAcademy.ConsoleClient
{
    class Program
    {
        static void Main()
        {
            TelerikAcademyEntities context = new TelerikAcademyEntities();

            context.Towns.Add(new Town { Name = "Pesho" });

            context.SaveChanges();

            Stopwatch stopWatchWithoutInclude = new Stopwatch();
            stopWatchWithoutInclude.Start();
            using (context)
            {
                foreach (var employee in context.Employees)
                {
                    Console.WriteLine("Name: {0} - Town: {1} - Department: {2}",
                        employee.FirstName, employee.Address.Town.Name, employee.Department.Name);
                }
            }

            stopWatchWithoutInclude.Stop();

            Console.WriteLine(new string('-', 50));

            context = new TelerikAcademyEntities();

            Stopwatch stopWatchWithInclude = new Stopwatch();
            stopWatchWithInclude.Start();

            using (context)
            {
                foreach (var employee in context.Employees.Include("Address").Include("Department"))
                {
                    Console.WriteLine("Name: {0} - Town: {1} - Department: {2}",
                        employee.FirstName, employee.Address.Town.Name, employee.Department.Name);
                }
            }

            stopWatchWithInclude.Stop();

            Console.WriteLine("Time without include: {0}", stopWatchWithoutInclude.Elapsed);
            Console.WriteLine("Time with include:    {0}", stopWatchWithInclude.Elapsed);
        }
    }
}
