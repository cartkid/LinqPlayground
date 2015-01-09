using LinqPlayground.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;

namespace LinqPlayground
{
    public class Queries
    {
        public Queries()
        {

        }

        public static bool IsDatabaseConnected()
        {
            using (var context = new AdventureWorksEntities())
            {
                DbConnection connection = context.Database.Connection;
                try
                {
                    connection.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static IEnumerable<object> GetPeople(out long executionMilliSeconds, int? maxToReturn = null)
        {
            executionMilliSeconds = 0L;
            IEnumerable<object> allPeople = new List<object>();

            using (var context = new AdventureWorksEntities())
            {
                ConsoleManager.Show();
                context.Database.Log = Console.Write;

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var tempAllPeople = context.People.Select(p => new { FirstName = p.FirstName, LastName = p.LastName });
                
                if (maxToReturn.HasValue)
                {
                    tempAllPeople = tempAllPeople.Take(maxToReturn.Value);
                }
                allPeople = tempAllPeople.ToList();
                stopwatch.Stop();
                executionMilliSeconds = stopwatch.ElapsedMilliseconds;
            }

            return allPeople;
        }

        public static IEnumerable<object> GetPeopleWithFirstName(string nameToMatch, int? maxToReturn = null)
        {
            IEnumerable<object> peopleWithFirstName = new List<object>();
            using (var context = new AdventureWorksEntities())
            {
                ConsoleManager.Show();
                context.Database.Log = Console.Write;

                var tempPeopleWithFirstName = context.People.Where(p => p.FirstName == nameToMatch).Select(p => new { FirstName = p.FirstName, LastName = p.LastName });
                if (maxToReturn.HasValue)
                    tempPeopleWithFirstName = tempPeopleWithFirstName.Take(maxToReturn.Value);
                peopleWithFirstName = tempPeopleWithFirstName.ToList();
            }
            return peopleWithFirstName;
        }

        public static long GetNumPeople()
        {
            long numPeople = 0L;
            using (var context = new AdventureWorksEntities())
            {
                ConsoleManager.Show();
                context.Database.Log = Console.Write;

                var tempPeople = context.People;
                numPeople = tempPeople.Count();
            }
            return numPeople;
        }

        public static long GetNumPeopleWithFirstName(string nameToMatch)
        {
            long numPeople = 0L;
            using (var context = new AdventureWorksEntities())
            {
                ConsoleManager.Show();
                context.Database.Log = Console.Write;

                var tempPeople = context.People;
                numPeople = tempPeople.Count(p => p.FirstName == nameToMatch);
            }
            return numPeople;
        }

        public static IEnumerable<object> GetFirstNamesAndCount()
        {
            List<object> firstNames = new List<object>();
            using (var context = new AdventureWorksEntities())
            {
                ConsoleManager.Show();
                context.Database.Log = Console.Write;

                var tempFirstNames = from n in context.People
                                     group n by n.FirstName into g
                                     select new
                                     {
                                         FirstName = g.Key,
                                         Count = g.Count()
                                     };

                firstNames = tempFirstNames.ToList<object>();
            }
            return firstNames;
        }

        public static IEnumerable<object> GetNamesAndTotalPay()
        {
            List<object> namesAndPay = new List<object>();
            using (var context = new AdventureWorksEntities())
            {
                ConsoleManager.Show();
                context.Database.Log = Console.Write;

                var peopleAndPay = from p in context.Employees
                                   group p by p.Person into g
                                   select new
                                   {
                                       Name = g.Key.FirstName + " " + g.Key.LastName,
                                       MaxRate = g.Max(m => m.EmployeePayHistories.Max(x => x.Rate))
                                   };
                peopleAndPay = peopleAndPay.OrderBy(x => x.Name);
                namesAndPay = peopleAndPay.ToList<object>();
            }
            return namesAndPay;
        }

        public static IEnumerable<object> GetDuplicateNames()
        {
            List<object> names = new List<object>();
            using (var context = new AdventureWorksEntities())
            {
                ConsoleManager.Show();
                context.Database.Log = Console.Write;

                var tempNames = from n in context.People
                                     group n by n.FirstName + " " + n.LastName into g
                                     select new
                                     {
                                         FullName = g.Key,
                                         Count = g.Count()
                                     };

                names = tempNames.ToList<object>();
            }
            return names;
        }
    }
}
