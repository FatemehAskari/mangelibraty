using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    public partial class Borrowed : Window
    {
        public List<BorrowedBooks> BorrowedItems { get; set; }
        public Borrowed()
        {
            InitializeComponent();
            BorrowedItems = new List<BorrowedBooks>();
            SqlConnection con = new SqlConnection(
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string command;
            command = "select * from bookList1";
            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                int id = Convert.ToInt32(data.Rows[i][0]);
                string MemberEmail = data.Rows[i][1].ToString();
                string bookName = data.Rows[i][2].ToString();
                DateTime BorrowedDate = Convert.ToDateTime(data.Rows[i][3]);
                BorrowedBooks bb = new BorrowedBooks(MemberEmail, bookName, BorrowedDate, id);
                BorrowedItems.Add(bb);
            }
            SqlCommand com = new SqlCommand(command, con);
            com.BeginExecuteNonQuery();
            con.Close();

            DataContext = this;
            
        }

        private void Borrowed_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    //a class to store the borrowed books data
    public class BorrowedBooks
    {
        public string email { get; set; }
        public string bookName { get; set; }
        public DateTime date { get; set; }
        public int id { get; set; }
        public BorrowedBooks(string email, string BookName, DateTime date, int id)
        {
            this.email = email;
            this.bookName = BookName;
            this.date = date;
            this.id = id;
        }
    }
}
