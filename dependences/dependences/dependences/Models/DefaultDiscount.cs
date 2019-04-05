using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dependences.Models
{
    public class DefaultDiscount : IDiscount
    {
        IDiscountSize discountSize;

        public DefaultDiscount(IDiscountSize discountSize)
        {
            this.discountSize = discountSize;
        }

        public decimal ApplyDiscount(decimal total)
        {
            return total *(1-discountSize.Size/100);
        }
    }
}