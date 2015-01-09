using LinqPlayground.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Linq;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LinqPlaygroundTests
{
    [TestClass]
    public class IEnumerableVsIQueryableTests
    {
        #region IEnumerable Tests
        /*[TestMethod]
        public void IEnumerableGetPeople1()
        {
            long executionMilliseconds = 0L;
            IEnumerable<object> people = LinqPlayground.IEnumerableQueries.GetPeople(out executionMilliseconds, 1);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }

        [TestMethod]
        public void IEnumerableGetPeople2()
        {
            long executionMilliseconds = 0L;
            IEnumerable<object> people = LinqPlayground.IEnumerableQueries.GetPeople(out executionMilliseconds, 1);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }

        [TestMethod]
        public void IEnumerableGetPeople3()
        {
            long executionMilliseconds = 0L;
            IEnumerable<object> people = LinqPlayground.IEnumerableQueries.GetPeople(out executionMilliseconds, 1);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }

        [TestMethod]
        public void IEnumerableGetPeople4()
        {
            long executionMilliseconds = 0L;
            IEnumerable<object> people = LinqPlayground.IEnumerableQueries.GetPeople(out executionMilliseconds, 1);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }

        [TestMethod]
        public void IEnumerableGetPeople5()
        {
            long executionMilliseconds = 0L;
            IEnumerable<object> people = LinqPlayground.IEnumerableQueries.GetPeople(out executionMilliseconds, 1);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }*/

        [TestMethod]
        public void IEnumerableGetPeopleWholeRecord1()
        {
            string executionMilliseconds = "";
            IEnumerable<object> people = LinqPlayground.IEnumerableQueries.GetPeopleWholeRecord(out executionMilliseconds, 1);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }

        [TestMethod]
        public void IEnumerableGetPeopleWholeRecord2()
        {
            string executionMilliseconds = "";
            IEnumerable<object> people = LinqPlayground.IEnumerableQueries.GetPeopleWholeRecord(out executionMilliseconds, 1);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }

        [TestMethod]
        public void IEnumerableGetPeopleWholeRecord3()
        {
            string executionMilliseconds = "";
            IEnumerable<object> people = LinqPlayground.IEnumerableQueries.GetPeopleWholeRecord(out executionMilliseconds, 1);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }

        [TestMethod]
        public void IEnumerableGetPeopleWholeRecord4()
        {
            string executionMilliseconds = "";
            IEnumerable<object> people = LinqPlayground.IEnumerableQueries.GetPeopleWholeRecord(out executionMilliseconds, 1);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }

        [TestMethod]
        public void IEnumerableGetPeopleWholeRecord5()
        {
            string executionMilliseconds = "";
            IEnumerable<object> people = LinqPlayground.IEnumerableQueries.GetPeopleWholeRecord(out executionMilliseconds, 1);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }
        #endregion

        /*[TestMethod]
        public void IQueryableGetPeople1()
        {
            long executionMilliseconds = 0L;
            IEnumerable<object> people = LinqPlayground.IQueryableQueries.GetPeople(out executionMilliseconds, 1);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }

        [TestMethod]
        public void IQueryableGetPeople2()
        {
            long executionMilliseconds = 0L;
            IEnumerable<object> people = LinqPlayground.IQueryableQueries.GetPeople(out executionMilliseconds, 1);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }

        [TestMethod]
        public void IQueryableGetPeople3()
        {
            long executionMilliseconds = 0L;
            IEnumerable<object> people = LinqPlayground.IQueryableQueries.GetPeople(out executionMilliseconds, 1);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }

        [TestMethod]
        public void IQueryableGetPeople4()
        {
            long executionMilliseconds = 0L;
            IEnumerable<object> people = LinqPlayground.IQueryableQueries.GetPeople(out executionMilliseconds, 1);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }

        [TestMethod]
        public void IQueryableGetPeople5()
        {
            long executionMilliseconds = 0L;
            IEnumerable<object> people = LinqPlayground.IQueryableQueries.GetPeople(out executionMilliseconds, 1);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }*/

        [TestMethod]
        public void IQueryableGetPeopleWholeRecord1()
        {
            string executionMilliseconds = "";
            IEnumerable<object> people = LinqPlayground.IQueryableQueries.GetPeopleWholeRecord(out executionMilliseconds, 1);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }

        [TestMethod]
        public void IQueryableGetPeopleWholeRecord2()
        {
            string executionMilliseconds = "";
            IEnumerable<object> people = LinqPlayground.IQueryableQueries.GetPeopleWholeRecord(out executionMilliseconds, 1);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }

        [TestMethod]
        public void IQueryableGetPeopleWholeRecord3()
        {
            string executionMilliseconds = "";
            IEnumerable<object> people = LinqPlayground.IQueryableQueries.GetPeopleWholeRecord(out executionMilliseconds, 1);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }

        [TestMethod]
        public void IQueryableGetPeopleWholeRecord4()
        {
            string executionMilliseconds = "";
            IEnumerable<object> people = LinqPlayground.IQueryableQueries.GetPeopleWholeRecord(out executionMilliseconds, 1);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }

        [TestMethod]
        public void IQueryableGetPeopleWholeRecord5()
        {
            string executionMilliseconds = "";
            IEnumerable<object> people = LinqPlayground.IQueryableQueries.GetPeopleWholeRecord(out executionMilliseconds, 1);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }
    }
}
