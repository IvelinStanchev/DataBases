using EntityFrameworkLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_CallsProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                var totalIncome = GetTotalIncomes("Exotic Liquids", new DateTime(1990, 1, 1), new DateTime(2000, 1, 1));

                Console.WriteLine("The total sum is: {0}", totalIncome);
            }
        }

        static decimal? GetTotalIncomes(string supplierName, DateTime? startDate, DateTime? endDate)
        {
            using (NorthwindEntities northwindEntites = new NorthwindEntities())
            {
                var totalIncomeSet = northwindEntites.usp_GetTotalIncomes(supplierName, startDate, endDate);

                foreach (var totalIncome in totalIncomeSet)
                {
                    return totalIncome;
                }
            }

            return null;
        }
    }
}
