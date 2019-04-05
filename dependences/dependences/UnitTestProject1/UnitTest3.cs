using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dependences.Models;
using System.Linq;
using Moq;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest3
    {
        Book[] books =
          {
            new Book{Autor="Shakespiere",Title="Hamlet",Category=BookCategory.Gexarvestakan,Price=1000 },
            new Book{Autor="Troelsen",Title="C#7",Category=BookCategory.Programming,Price=20 },
            new Book{Autor="Sevak",Title="Anlreli zangakatun",Category=BookCategory.Gexarvestakan,Price=1 },
            new Book{Autor="Steven Hawking",Title="Black Holes",Category=BookCategory.Gitakan,Price=30 }
        };



        [TestMethod]
        public void TestMethod1()
        {
            IDiscount disc = new MinDiscount();
            TotalValueCalculator ttcar = new TotalValueCalculator(disc);
            decimal truresult = books.Sum(x => x.Price);
            decimal realResult= ttcar.SumOfPrice(books);

            Assert.AreEqual(truresult, realResult, "Error value 100");


        }


        public void TestBymoq()
        {
            Mock<IDiscount> mock = new Mock<IDiscount>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);
                      

            IDiscount disc = new MinDiscount();
            TotalValueCalculator ttcar = new TotalValueCalculator(mock.Object);
            decimal truresult = books.Sum(x => x.Price);
            decimal realResult = ttcar.SumOfPrice(books);

            Assert.AreEqual(truresult, realResult, "Error value 100");
        }

        public Book[] CeteBook( int val)
        {
            return new[] { new Book {Price=val },new Book {Price=0 } };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SecondTestMyMoq()
        {
            Mock<IDiscount> mock = new Mock<IDiscount>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Throws(new ArgumentOutOfRangeException());
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(x => x > 100))).Returns<decimal>(y => y / 2m);
            mock.Setup(m => m.ApplyDiscount(It.IsInRange<decimal>(10, 100, Range.Exclusive))).Returns<decimal>(total => total - 5);
            mock.Setup(m => m.ApplyDiscount(It.IsInRange<decimal>(0, 10, Range.Exclusive))).Returns<decimal>(total => total);
            TotalValueCalculator calc = new TotalValueCalculator(mock.Object);

            decimal minusefive = calc.SumOfPrice(CeteBook(-1));
            decimal five = calc.SumOfPrice(CeteBook(5));
            decimal ten = calc.SumOfPrice(CeteBook(10));
            decimal fifty = calc.SumOfPrice(CeteBook(50));
            decimal fifthanri = calc.SumOfPrice(CeteBook(500));

            Assert.AreEqual(5, five, "from 5");
            Assert.AreEqual(5, ten,"from 10");
            Assert.AreEqual(45, fifty, "from 45");
            Assert.AreEqual(250, fifthanri, "from 250");


        }

    }
}
