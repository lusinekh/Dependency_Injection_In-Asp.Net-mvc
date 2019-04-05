using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dependences.Models;
namespace UnitTestProject1
{





    [TestClass]
    public class UnitTest1
    {
        IDiscount GetObject()
        {
            return new MinDiscount();
        }

        [TestMethod]
        public void Above_100()
        {

            //arrange
            IDiscount target = GetObject();
            decimal result_200 = 100;
            decimal result_500 = 250;
            //act
            decimal result1 = target.ApplyDiscount(200);
            decimal result2 = target.ApplyDiscount(500);

            //assert
            Assert.AreEqual(result_200, result1, "Error value 100");
            Assert.AreEqual(result_500, result2, "Error value 500");



        }
        [TestMethod]
        public void Between_100_10()
        {

            //arrange
            IDiscount target = GetObject();
            decimal result_100 = 95;
            decimal result_10 = 5;
            decimal result_50 = 45;

            //act
            decimal result1 = target.ApplyDiscount(100);
            decimal result2 = target.ApplyDiscount(10);
            decimal result3 = target.ApplyDiscount(50);

            //assert
            Assert.AreEqual(result_100, result1, "Error value 100");
            Assert.AreEqual(result_10, result2, "Error value 10");
            Assert.AreEqual(result_50, result2, "Error value 50");

        }
        [TestMethod]
        public void Less_Than_10()
        {
            //arrange
            IDiscount target = GetObject();            
            //assert
            Assert.AreEqual(5, target.ApplyDiscount(5), "Error value 100");
            Assert.AreEqual(0, target.ApplyDiscount(0), "Error value 10");
           
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NegativeVal()
        {
            //arrange
            IDiscount target = GetObject();
            target.ApplyDiscount(-10); 
        }
    }
}
