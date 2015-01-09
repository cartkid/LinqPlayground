using LinqPlayground.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;

namespace LinqPlayground
{
    public class IEnumerableQueries
    {
        public static IEnumerable<object> GetPeople(out string executionMilliSeconds, int? maxToReturn = null)
        {
            executionMilliSeconds = "";
            IEnumerable<object> allPeople = new List<object>();

            using (var context = new AdventureWorksEntities())
            {
                ConsoleManager.Show();
                context.Database.Log = Console.Write;
                string msg = "";
                context.Database.Log = message => msg += message;
                IEnumerable<object> tempAllPeople = context.People.Select(p => new { FirstName = p.FirstName, LastName = p.LastName });

                if (maxToReturn.HasValue)
                {
                    tempAllPeople = tempAllPeople.Take(maxToReturn.Value);
                }
                allPeople = tempAllPeople.ToList();
                executionMilliSeconds = msg;
            }

            return allPeople;
        }

        public static IEnumerable<object> GetPeopleWholeRecord(out string executionMilliSeconds, int? maxToReturn = null)
        {
            executionMilliSeconds = "";
            IEnumerable<object> allPeople = new List<object>();

            using (var context = new AdventureWorksEntities())
            {
                ConsoleManager.Show();
                context.Database.Log = Console.Write;
                string msg = "";
                context.Database.Log = message => msg += message;
                IEnumerable<object> tempAllPeople = context.People;

                if (maxToReturn.HasValue)
                {
                    tempAllPeople = tempAllPeople.Take(maxToReturn.Value);
                }
                allPeople = tempAllPeople.ToList();
                executionMilliSeconds = msg;
            }

            return allPeople;
        }

        public static string GetPeopleWholeRecordQuick(int? maxToReturn = null)
        {
            string executionMilliseconds;
            using (var context = new AdventureWorksEntities())
            {
                ConsoleManager.Show();
                context.Database.Log = Console.Write;
                string msg = "";
                context.Database.Log = message => msg += message;
                IEnumerable<object> tempAllPeople = context.People;

                if (maxToReturn.HasValue)
                {
                    tempAllPeople = tempAllPeople.Take(maxToReturn.Value);
                }
                foreach (var p in tempAllPeople)
                {
                    break;
                }
                executionMilliseconds = msg;
            }

            return executionMilliseconds;
        }

        public static IEnumerable<object> GetPeopleWithFirstName(string nameToMatch, out string executionMilliseconds, int? maxToReturn = null)
        {
            executionMilliseconds = "";
            IEnumerable<object> peopleWithFirstName = new List<object>();
            using (var context = new AdventureWorksEntities())
            {
                ConsoleManager.Show();
                context.Database.Log = Console.Write;
                string msg = "";
                context.Database.Log = message => msg += message;
                IEnumerable<object> tempPeopleWithFirstName = 
                    context.People.Where(p => p.FirstName == nameToMatch).Select(p => 
                        new { FirstName = p.FirstName, LastName = p.LastName });

                if (maxToReturn.HasValue)
                    tempPeopleWithFirstName = tempPeopleWithFirstName.Take(maxToReturn.Value);
                peopleWithFirstName = tempPeopleWithFirstName.ToList();
                executionMilliseconds = msg;
            }
            return peopleWithFirstName;
        }

        public static IEnumerable<object> GetIEnumerableExecutionResults(out long totalExecutionTime)
        {
            totalExecutionTime = 0L;
            List<StringStringObject> results = new List<StringStringObject>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            results.Add(ExecuteGetPeopleWholeRecord(1));
            results.Add(ExecuteGetPeopleWholeRecord(2));
            results.Add(ExecuteGetPeopleWholeRecord(3));
            results.Add(ExecuteGetPeopleWholeRecord(4));
            results.Add(ExecuteGetPeopleWholeRecord(5));

            stopwatch.Stop();
            totalExecutionTime = stopwatch.ElapsedMilliseconds;
            return results;
        }

        private static StringStringObject ExecuteGetPeopleWholeRecord(int count)
        {
            string elapsedTime = "";
            IEnumerableQueries.GetPeopleWholeRecord(out elapsedTime).ToString();
            StringStringObject sso = new StringStringObject(
                string.Format("GetPeopleWholeRecord{0}: ", count.ToString()), 
                string.Format("{0}", elapsedTime));
            return sso;
        }
    }    
}
