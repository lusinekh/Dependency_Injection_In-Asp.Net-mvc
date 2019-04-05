using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dependences.Models
{
    public enum BookCategory { None,Gexarvestakan,Programming,Gitakan}
    public class Book
    {

        public string Autor { get; set; }
        public string Title { get; set; }
        public BookCategory Category { get; set; }
        public decimal Price { get; set; }
        public override string ToString()
        {
            return Autor + "    " + Title + "    " + Category + "    " + Price.ToString("C");
        }
    }
}