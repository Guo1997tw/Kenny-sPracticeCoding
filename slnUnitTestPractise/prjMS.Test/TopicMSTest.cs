using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjMS.Test
{
    [TestClass]
    public class TopicMSTest
    {
        [DataTestMethod]
        [DataRow(3, 4, 7)]
        [DataRow(1, 4, 5)]
        [DataRow(6, 0, 6)]
        [DataRow(-2, 3, 1)]
        public void AddNumberTest(int num1, int num2, int expected)
        {
            // Act
            int result = AddNumberMethod(num1, num2);

            // Assert
            Assert.AreEqual(expected, result);
        }

        public int AddNumberMethod(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}