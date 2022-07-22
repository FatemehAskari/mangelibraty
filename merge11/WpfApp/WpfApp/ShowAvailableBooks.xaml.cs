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
    public partial class ShowAvailableBooks : Window
    {
        public List<Book> AvailableBooks { get; set; }
        public ShowAvailableBooks()
        {
            InitializeComponent();

            AvailableBooks = new List<Book>();
            SqlConnection con = new SqlConnection(
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string command;
            command = "select * from book";
            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                string name = data.Rows[i][0].ToString();
                string writer = data.Rows[i][1].ToString();
                int number = Convert.ToInt32(data.Rows[i][2]);
                bool borrowed = Convert.ToBoolean(data.Rows[i][3]);
                //when the borrowed is false, it means the book is available
                if (borrowed == false)
                {
                    Book b = new Book(name, writer, number, borrowed);
                    AvailableBooks.Add(b);
                }
            }
            SqlCommand com = new SqlCommand(command, con);
            com.BeginExecuteNonQuery();
            con.Close();

            DataContext = this;
        }

        private void ShowAvailable_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
