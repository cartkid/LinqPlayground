using LinqPlayground.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;

namespace LinqPlayground
{
    public class ExtensionMethods
    {
        public static IEnumerable<object> GetEmployeesByMonth(int month)
        {
            IEnumerable<object> returnResults = new List<object>();
            using (var context = new AdventureWorksEntities())
            {
                ConsoleManager.Show();
                context.Database.Log = Console.Write;
                var results = context.Employees.Select(e =>
                    new
                    {
                        BirthDate = e.BirthDate,
                        FirstName = e.Person.FirstName,
                        LastName = e.Person.LastName
                    });
                results = results.Where(e => e.BirthDate.Month == month);
                returnResults = results.ToList();
            }
            return returnResults;
        }

        public static IEnumerable<object> ExecuteGroupBySumQuery()
        {
            IEnumerable<object> returnResults = new List<object>();
            using (var context = new AdventureWorksEntities())
            {
                ConsoleManager.Show();
                context.Database.Log = Console.Write;
                var results = from o in context.SalesOrderDetails
                              group (o.UnitPrice - o.UnitPriceDiscount) by o.SalesOrderID into g
                              select new { SalesOrderID = g.Key, Total = g.Sum() };
                returnResults = results.ToList();
            }
            return returnResults;
        }

        public static IEnumerable<object> ExecuteGroupBySumLambdaQuery()
        {
            IEnumerable<object> returnResults = new List<object>();
            using (var context = new AdventureWorksEntities())
            {
                ConsoleManager.Show();
                context.Database.Log = Console.Write;
                var results = context.SalesOrderDetails.GroupBy(o => o.SalesOrderID, o => (o.UnitPrice - o.UnitPriceDiscount),
                                        (key, g) => new { SalesOrderID = key, Total = g.Sum() });
                returnResults = results.ToList();
            }
            return returnResults;
        }
    }
}
