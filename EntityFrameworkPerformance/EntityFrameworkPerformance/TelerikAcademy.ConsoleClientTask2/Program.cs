using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.Models;

namespace TelerikAcademy.ConsoleClientTask2
{
    class Program
    {
        static void Main()
        {
            TelerikAcademyEntities context = new TelerikAcademyEntities();

            context.Towns.Add(new Town { Name = "Pesho" });

            context.SaveChanges();

            Stopwatch sw = new Stopwatch();

            sw.Start();
            //bad performance
            var allEmployees = context.Employees.ToList().Select(e => e.Address).ToList()
                .Select(t => t.Town).ToList().Select(t => t.Name == "Sofia");

            Console.WriteLine("The first query ended in:  {0} time", sw.Elapsed);

            sw.Restart();

            //good performance
            allEmployees = context.Employees.Select(e => e.Address)
                .Select(t => t.Town).Select(t => t.Name == "Sofia");

            Console.WriteLine("The second query ended in: {0} time", sw.Elapsed);
        }
    }
}
