using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_10_B
{
    public abstract class User
    {
        public int id { get; set; }//private int id;
                                   //public void get()
                                   //{ return id;}
        public string name { get; set; }
        public string address { get; set; }
        public int fine { get; set; } = 0;
        public int book_count { get; set; } = 0; 
        
        public List<Borrowed_Book> books = new List<Borrowed_Book>();

        public  abstract void borrow_book(int id,int days);
        public abstract void return_book( int id,int return_day);
    }

    //child class
    public class regular_Users : User
    {
       
        public regular_Users(int id, string name, string address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }
        
        public override void borrow_book(int b_id, int days)
        { 

           
                if (book_count < 3)
                {
                    book bookie;

                    for (int i = 0; i < management.library_books.Count; ++i)
                    {
                        if (b_id == management.library_books[i].id && management.library_books[i].quantity>0)
                        {
                        management.borrower_id.Add(id);
                            bookie = management.library_books[i];
                            management.library_books[i].quantity -= 1;
                            Borrowed_Book b = new Borrowed_Book(bookie, days);
                            books.Add(b);
                        book_count++;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }

                }
                else
                {
                    throw new Exception();
                }
            

        }
        public override void return_book(int b_id, int return_Days)
        {
            for(int i=0;i<books.Count;i++)
            {
                if(books[i].booky.id== b_id)
                {
                    if ((return_Days-books[i].days)>0)
                    {
                        fine += 5 * (return_Days - books[i].days);
                       
                        management.total_earned_fines += fine;
                    }
                    for(int j=0;j<management.library_books.Count;j++)
                    {
                        if (management.library_books[i].id== b_id)
                        {
                            management.library_books[i].quantity += 1;
                        }
                    }
                    for(int f=0;f<management.borrower_id.Count;f++)
                    {
                        if (id == management.borrower_id[i])
                        {
                            management.borrower_id.Remove(id);
                            break;
                        }
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
        }
    }


    //child class
    public class Librarian : User
    {

        public void AddBook(book book)
        {
            management.library_books.Add(book);
        }
        public void RemoveBook(int ind)
        {
            management.library_books.RemoveAt(ind);
        }

        //constructor
        public Librarian(int id, string name, string address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }
        public override void borrow_book(int b_id, int days)
        {
            if (book_count < 5)
            {
                book bookie;
                management.borrower_id.Add(id);
                for (int i=0;i<management.library_books.Count;++i)
                {
                    if(b_id == management.library_books[i].id)
                    {
                        bookie= management.library_books[i];
                        management.library_books[i].quantity -= 1;
                        Borrowed_Book b = new Borrowed_Book(bookie, days);
                        books.Add(b);
                        book_count++;
                    }
                }
                
            }
            else
            {
                throw new Exception();
            }
        }

        public override void return_book(int b_id, int return_Days)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].booky.id == b_id)
                {
                    if ((return_Days - books[i].days) > 0)
                    {
                        fine += 3 * (return_Days - books[i].days);

                        management.total_earned_fines += fine;
                    }
                    for (int j = 0; j < management.library_books.Count; j++)
                    {
                        if (management.library_books[i].id == b_id)
                        {
                            management.library_books[i].quantity += 1;
                        }
                    }
                    for (int f = 0; f < management.borrower_id.Count; f++)
                    {
                        if (id == management.borrower_id[i])
                        {
                            management.borrower_id.Remove(id);
                            break;
                        }
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
        }
    }
}
