using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CMP307ProjectTests
{
    [TestClass]
    public class SimpleTest
    {
        [TestMethod]
        public void SimpleAdditionTest()
        {
            // Arrange
            int a = 1;
            int b = 2;

            // Act
            int result = a + b;

            // Assert
            Assert.AreEqual(3, result);
        }
    }
}