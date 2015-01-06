using LinqPlayground.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static List<Person> GetPeople()
        {
            List<Person> allPeople = new List<Person>();

            using (var context = new AdventureWorksEntities())
            {
                allPeople = context.People.ToList<Person>();
            }

            return allPeople;
        }

        public static List<Person> GetPeopleWithFirstName(string nameToMatch)
        {
            List<Person> peopleWithFirstName = new List<Person>();
            using (var context = new AdventureWorksEntities())
            {
                peopleWithFirstName = context.People.Where(p => p.FirstName == nameToMatch).ToList<Person>();
            }
            return peopleWithFirstName;
        }

        public static long GetNumPeople()
        {
            long numPeople = 0L;
            using (var context = new AdventureWorksEntities())
            {
                numPeople = context.People.Count();
            }
            return numPeople;
        }

        public static long GetNumPeopleWithFirstName(string nameToMatch)
        {
            long numPeople = 0L;
            using (var context = new AdventureWorksEntities())
            {
                numPeople = context.People.Count(p => p.FirstName == nameToMatch);
            }
            return numPeople;
        }
    }
}
