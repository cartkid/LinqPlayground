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
    public class ExtensionMethodsTests
    {
        [TestMethod]
        public void GetEmployeesByBirthMonth1()
        {
            IEnumerable<object> people = 
                LinqPlayground.ExtensionMethods.GetEmployeesByMonth(9);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }

        [TestMethod]
        public void GetEmployeesByBirthMonth2()
        {
            IEnumerable<object> people =
                LinqPlayground.ExtensionMethods.GetEmployeesByMonth(5);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }

        [TestMethod]
        public void GetEmployeesByBirthMonth3()
        {
            IEnumerable<object> people =
                LinqPlayground.ExtensionMethods.GetEmployeesByMonth(1);
            int numPeople = people.Count();
            Assert.IsTrue(numPeople > 0);
        }

        [TestMethod]
        public void GetGroupedOrdersLambdaSyntax()
        {
            IEnumerable<object> results =
                LinqPlayground.ExtensionMethods.ExecuteGroupBySumLambdaQuery();
            int resultsNum = results.Count();
            Assert.IsTrue(resultsNum > 0);
        }

        [TestMethod]
        public void GetGroupedOrdersLinqSyntax()
        {
            IEnumerable<object> results =
                LinqPlayground.ExtensionMethods.ExecuteGroupBySumQuery();
            int resultsNum = results.Count();
            Assert.IsTrue(resultsNum > 0);
        }

        [TestMethod]
        public void LambdaAndLinqSyntaxGroupAreEqual()
        {
            List<object> lambdaResults = LinqPlayground.ExtensionMethods.ExecuteGroupBySumLambdaQuery().ToList();
            List<object> linqSyntaxResults = LinqPlayground.ExtensionMethods.ExecuteGroupBySumQuery().ToList();

            bool resultsAreEqual = true;
            if (linqSyntaxResults.Count != lambdaResults.Count)
                resultsAreEqual = false;

            for (int i = 0; i < lambdaResults.Count(); i++)
            {
                if (lambdaResults[i].ToString() != linqSyntaxResults[i].ToString())
                {
                    resultsAreEqual = false;
                    break;
                }
            }
            Assert.IsTrue(resultsAreEqual);
        }
    }
}
