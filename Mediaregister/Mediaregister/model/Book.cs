using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediaregister.model
{
    class Book : Media
    {
        private string auther;
        private int pages;

        public Book(string title, string author, int pages)
        {
            Title = title;
            auther = author;
            this.pages = pages;
        }

        public override string ToString()
        {
            return Title + $" ({auther}, {pages} sidor)";
        }
    }
}
