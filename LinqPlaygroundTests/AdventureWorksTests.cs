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
    public class AdventureWorksTests
    {
        [TestMethod]
        public void IsDatabaseConnected()
        {
            bool isDatabaseConnected = LinqPlayground.Queries.IsDatabaseConnected();
            Assert.IsTrue(isDatabaseConnected);
        }

        [TestMethod]
        public void GetPeople()
        {
            IEnumerable<object> people = LinqPlayground.Queries.GetPeople(1);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }

        [TestMethod]
        public void GetAllErics()
        {
            IEnumerable<object> allErics = LinqPlayground.Queries.GetPeopleWithFirstName("Eric");
            int actualCountErics = allErics.Count();
            int expectedCountErics = 63;
            Assert.AreEqual(actualCountErics, expectedCountErics);
        }

        [TestMethod]
        public void GetAllAlyssas()
        {
            IEnumerable<object> allErics = LinqPlayground.Queries.GetPeopleWithFirstName("Alyssa");
            int actualCountErics = allErics.Count();
            int expectedCountErics = 67;
            Assert.AreEqual(actualCountErics, expectedCountErics);
        }

        [TestMethod]
        public void GetCountErics()
        {
            long numErics = LinqPlayground.Queries.GetNumPeopleWithFirstName("Eric");
            long expectedCountErics = 63;
            Assert.AreEqual(numErics, expectedCountErics);
        }

        [TestMethod]
        public void GetCountAlyssas()
        {
            long numAlyssas = LinqPlayground.Queries.GetNumPeopleWithFirstName("Alyssa");
            long expectedCountAlyssas = 67;
            Assert.AreEqual(numAlyssas, expectedCountAlyssas);
        }
    }
}
