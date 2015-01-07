using LinqPlayground.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
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

        public static IEnumerable<object> GetPeople(int? maxToReturn = null)
        {
            IEnumerable<object> allPeople = new List<object>();

            using (var context = new AdventureWorksEntities())
            {
                ConsoleManager.Show();
                context.Database.Log = Console.Write;

                var tempAllPeople = context.People.Select(p => new { FirstName = p.FirstName, LastName = p.LastName });
                
                if (maxToReturn.HasValue)
                {
                    tempAllPeople = tempAllPeople.Take(maxToReturn.Value);
                }
                allPeople = tempAllPeople.ToList();
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

    [SuppressUnmanagedCodeSecurity]
    public static class ConsoleManager
    {
        private const string Kernel32_DllName = "kernel32.dll";

        [DllImport(Kernel32_DllName)]
        private static extern bool AllocConsole();

        [DllImport(Kernel32_DllName)]
        private static extern bool FreeConsole();

        [DllImport(Kernel32_DllName)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport(Kernel32_DllName)]
        private static extern int GetConsoleOutputCP();

        public static bool HasConsole
        {
            get { return GetConsoleWindow() != IntPtr.Zero; }
        }

        /// <summary>
        /// Creates a new console instance if the process is not attached to a console already.
        /// </summary>
        public static void Show()
        {
            //#if DEBUG
            if (!HasConsole)
            {
                AllocConsole();
                InvalidateOutAndError();
            }
            //#endif
        }

        /// <summary>
        /// If the process has a console attached to it, it will be detached and no longer visible. Writing to the System.Console is still possible, but no output will be shown.
        /// </summary>
        public static void Hide()
        {
            //#if DEBUG
            if (HasConsole)
            {
                SetOutAndErrorNull();
                FreeConsole();
            }
            //#endif
        }

        public static void Toggle()
        {
            if (HasConsole)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }

        static void InvalidateOutAndError()
        {
            Type type = typeof(System.Console);

            System.Reflection.FieldInfo _out = type.GetField("_out",
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            System.Reflection.FieldInfo _error = type.GetField("_error",
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            System.Reflection.MethodInfo _InitializeStdOutError = type.GetMethod("InitializeStdOutError",
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            Debug.Assert(_out != null);
            Debug.Assert(_error != null);

            Debug.Assert(_InitializeStdOutError != null);

            _out.SetValue(null, null);
            _error.SetValue(null, null);

            _InitializeStdOutError.Invoke(null, new object[] { true });
        }

        static void SetOutAndErrorNull()
        {
            Console.SetOut(TextWriter.Null);
            Console.SetError(TextWriter.Null);
        }
    }
}
