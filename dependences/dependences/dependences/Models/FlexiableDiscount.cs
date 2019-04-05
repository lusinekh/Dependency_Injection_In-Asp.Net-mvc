using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dependences.Models
{
    public class FlexiableDiscount : IDiscount
    {
        public decimal ApplyDiscount(decimal total)
        {
            return total > 100 ? total * 0.5m : total - 5;
        }
    }
}