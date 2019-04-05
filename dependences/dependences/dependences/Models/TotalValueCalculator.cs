using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dependences.Models
{
    public class TotalValueCalculator : ITotalValueCalculator
    {
        IDiscount discount;
        public TotalValueCalculator(IDiscount discount)
        {
            this.discount = discount;
        }
        public decimal SumOfPrice(IEnumerable<Book> books)
        {
            return books.Sum(x => discount.ApplyDiscount(x.Price));
        }

    }
}