using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dependences.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        IDiscount GetObject()
        {
            return new FlexiableDiscount();
        }

        [TestMethod]
        public void Greate_100()
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
        public void las_100()
        {

            //arrange
            IDiscount target = GetObject();
            decimal result_50 = 45;
            decimal result_95 = 90;
            //act
            decimal result1 = target.ApplyDiscount(200);
            decimal result2 = target.ApplyDiscount(500);

            //assert
            Assert.AreEqual(result_50, result1, "Error value 100");
            Assert.AreEqual(result_95, result2, "Error value 500");

        }










    }
}
