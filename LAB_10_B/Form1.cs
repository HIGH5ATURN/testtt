using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_10_B
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //to drag the form//not necessary to understand OOP question
        private bool dragg = false;
        private Point StartPoint = new Point(0, 0);
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            dragg = true;
            StartPoint = new Point(e.X, e.Y);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            dragg = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragg)
            {

                Point p = PointToScreen(e.Location);

                Location = new Point(p.X - this.StartPoint.X, p.Y - this.StartPoint.Y);

            }
        }
        //to drag the form//not necessary to understand OOP question
        //the blend-in effect//not necessary to understand the code//(UI design Purpose)
        private void Form1_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 500, WinAPI.BLEND);
        }
        //the blend-in effect//not necessary to understand the code//(UI design Purpose)






        private void Add_user_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(add_u_ID_textBox.Text);
                if (add_user_type_comboBox.Text == "Student")
                {
                    regular_Users student = new regular_Users(Convert.ToInt32(add_u_ID_textBox.Text), add_u_Name_textBox.Text, add_u_Address_textBox.Text);

                    management.arr_students.Add(student);
                    MessageBox.Show("st ADded!");
                }
                else
                {
                    Librarian librarian = new Librarian(Convert.ToInt32(add_u_ID_textBox.Text), add_u_Name_textBox.Text, add_u_Address_textBox.Text);

                    management.arr_librarian.Add(librarian);

                    curr_u_comboBox.Items.Add(Convert.ToInt32(add_u_ID_textBox.Text));
                }
                rent_uid_comboBox.Items.Add(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                add_u_ID_textBox.Clear();
            }
        }

        private void Add_Book_Button_Click(object sender, EventArgs e)
        {
            try
            {
                book add_this_book = new book(Convert.ToInt32(add_book_Id_textBox.Text), add_b_title_textBox.Text, add_b_author_textBox.Text, add_b_genre_textBox.Text, Convert.ToInt32(add_b_quantity_textBox.Text));

                for (int i = 0; i < management.arr_librarian.Count; i++)
                {
                    if (management.arr_librarian[i].id == Convert.ToInt32(curr_u_comboBox.Text))
                    {
                        management.arr_librarian[i].AddBook(add_this_book);
                    }

                }

                rent_book_id_comboBox.Items.Add(Convert.ToInt32(add_book_Id_textBox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Delete_Book_Button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < management.arr_librarian.Count; i++)
            {
                if (management.arr_librarian[i].id == Convert.ToInt32(curr_u_comboBox.Text))
                {

                    for (int j = 0; j < management.library_books.Count; j++)
                    {
                        if (Convert.ToInt32(add_book_Id_textBox.Text) == management.library_books[j].id)
                        {
                            management.arr_librarian[i].RemoveBook(Convert.ToInt32(add_book_Id_textBox.Text));
                        }
                    }
                }

            }
        }

        private void Rent_Book_Button_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < management.arr_students.Count; i++)
                {
                    if (management.arr_students[i].id == Convert.ToInt32(rent_book_id_comboBox.Text))
                    {

                        management.arr_students[i].borrow_book(Convert.ToInt32(rent_book_id_comboBox.Text), Convert.ToInt32(duration_comboBox.Text));
                    }
                }
                for (int i = 0; i < management.arr_students.Count; i++)
                {
                    if (management.arr_librarian[i].id == Convert.ToInt32(rent_book_id_comboBox.Text))
                    {

                        management.arr_librarian[i].borrow_book(Convert.ToInt32(rent_book_id_comboBox.Text), Convert.ToInt32(duration_comboBox.Text));
                    }
                }
            }
            catch
            {
                MessageBox.Show("Either the book is stocked out, else u have borrowed upto limit!");
            }
        }

        private void gunaGradientTileButton1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < management.arr_students.Count; i++)
                {
                    if (management.arr_students[i].id == Convert.ToInt32(return_u_id_textBox.Text))
                    {
                        management.arr_students[i].return_book(Convert.ToInt32(rent_book_id_comboBox.Text), Convert.ToInt32(Return_date_textBox.Text));

                    }
                }
                for (int i = 0; i < management.arr_students.Count; i++)
                {
                    if (management.arr_librarian[i].id == Convert.ToInt32(return_u_id_textBox.Text))
                    {

                        management.arr_librarian[i].return_book(Convert.ToInt32(rent_book_id_comboBox.Text), Convert.ToInt32(Return_date_textBox.Text));
                    }
                }
            }
            catch
            {
                MessageBox.Show("The book was never borrowed by you!");
            }
        }

        private void Show_Book_Button_Click(object sender, EventArgs e)
        {
            book_listBox.Items.Clear();
            for (int i = 0; i < management.library_books.Count; i++)
            {
                string s = $"{management.library_books[i].id}\t {management.library_books[i].title}\t{management.library_books[i].author}\t{management.library_books[i].genre}\t{management.library_books[i].quantity}";

                book_listBox.Items.Add(s);
            }
        }

        private void show_borrower_button_Click(object sender, EventArgs e)
        {
            borrower_ListBox.Items.Clear();
            string s = "{management.arr_students[i].id}\t";
            for (int i = 0; i < management.borrower_id.Count; i++)
            {
                for (int j = 0; j < management.arr_students.Count; i++)
                {
                    s += $"";
                    if (management.borrower_id[i] == management.arr_students[j].id)
                    {
                        for (int q = 0; q < management.arr_students[j].books.Count; q++)
                        {
                            s += $"{management.arr_students[j].books[q].booky.id}\t";
                        }

                    }
                    s += $"{management.arr_students[i].fine}";
                    borrower_ListBox.Items.Add(s);
                }
                
            }
        }
    }
}
