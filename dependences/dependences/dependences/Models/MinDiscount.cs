using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dependences.Models
{
    public class MinDiscount : IDiscount
    {
        public decimal ApplyDiscount(decimal total)
        {
            if (total >= 100) return total / 2m;
            if (total >= 10) return total - 5;
            if (total > 0) return total;
            throw new ArgumentOutOfRangeException();
        }
    }
}