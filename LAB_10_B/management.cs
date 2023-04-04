using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_10_B
{
    public  static class management
    {
        public static List<regular_Users> arr_students = new List<regular_Users>();

        public static List<Librarian> arr_librarian = new List<Librarian>();

        public static List<int> borrower_id= new List<int>();

        public static List<book> library_books= new List<book>();

        public static int capacity { get; set; } = 100;
        public static int total_earned_fines { get; set; }
    }
}
