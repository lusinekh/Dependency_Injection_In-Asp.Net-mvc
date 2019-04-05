using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dependences.Models
{
    public class DiscountSize : IDiscountSize
    {
        public decimal Size { get; set ; }
    }
}