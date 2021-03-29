using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediaregister.model
{
    class Film : Media
    {
        private string directer;
        private int length;

        public Film(string title, string director, int length)
        {
            Title = title;
            directer = director;
            this.length = length;
        }

        public override string ToString()
        {
            return Title + $" ({directer}, {length} minuter)";
        }
    }
}
