using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_10_B
{
    public class Borrowed_Book
    {
        public book booky { get; set; }

        public int days { get; set; }
        public Borrowed_Book(book booky, int days)
        {
            this.booky = booky;
            this.days = days;
        }
    }
}
